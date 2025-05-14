using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurity_ChatBot
{
    internal class Program
    {
        private static string userName = "Friend";
        private static string userInterest = "";
        private static readonly Random random = new Random();

        private delegate string KeywordResponder();

        private static string RespondToPassword() => GetRandomResponse("password");
        private static string RespondToScam() => GetRandomResponse("scam");
        private static string RespondToPrivacy() => GetRandomResponse("privacy");

        private static readonly Dictionary<string, KeywordResponder> keywordResponders = new Dictionary<string, KeywordResponder>()
        {
            { "password", RespondToPassword },
            { "scam", RespondToScam },
            { "privacy", RespondToPrivacy }
        };

        private static readonly Dictionary<string, string> synonymMap = new Dictionary<string, string>()
        {
            { "passwords", "password" },
            { "pw", "password" },
            { "two factor", "2fa" },
            { "2-factor", "2fa" },
            { "scams", "scam" },
            { "fraud", "scam" },
            { "social", "social media" },
            { "firewalls", "firewall" },
            { "bluetooths", "bluetooth" }
        };

        private static readonly Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            { "password", new List<string>() {
                "Use strong passwords with 12+ characters including symbols.",
                "Avoid using the same password across platforms.",
                "Use a password manager to securely store your credentials."
            }},
            { "scam", new List<string>() {
                "Be cautious of emails that request personal information.",
                "If it sounds too good to be true, it probably is.",
                "Avoid clicking on suspicious links."
            }},
            { "privacy", new List<string>() {
                "Regularly review app permissions.",
                "Limit what you share on social media.",
                "Use end-to-end encrypted messaging apps."
            }},
            { "phishing", new List<string> {
                "Check for typos in email addresses and URLs.",
                "Avoid clicking unknown links.",
                "Verify sender identity before responding."
            }},
            { "vpn", new List<string> {
                "A VPN encrypts your internet connection and hides your IP address.",
                "Use a trusted VPN to stay anonymous online, especially on public Wi-Fi.",
                "VPNs help you access region-locked content while maintaining privacy."
            }},
            { "malware", new List<string> {
                "Install reliable antivirus software and keep it up to date.",
                "Avoid downloading files from untrusted sources.",
                "Be wary of attachments in unsolicited emails—they might carry malware."
            }},
            { "ransomware", new List<string> {
                "Regularly back up your data to an offline location.",
                "Avoid clicking links in emails from unknown senders.",
                "Keep your operating system and software updated to patch vulnerabilities."
            }},
            { "firewall", new List<string> {
                "Enable your firewall to block unauthorized access to your computer.",
                "Firewalls monitor and filter incoming and outgoing network traffic.",
                "A good firewall is your first line of defense in network security."
            }},
            { "social media", new List<string> {
                "Be cautious about what you share online—cybercriminals can use personal info.",
                "Review privacy settings on your social media accounts regularly.",
                "Avoid accepting friend requests from people you don’t know."
            }},
            { "2fa", new List<string> {
                "Enable two-factor authentication for all your important accounts.",
                "2FA adds an extra layer of security, making it harder for hackers to access your data.",
                "Use authenticator apps instead of SMS for better security."
            }},
            { "encryption", new List<string> {
                "Encryption scrambles your data so only authorized parties can access it.",
                "Use encrypted messaging apps to protect your conversations.",
                "Always ensure websites use HTTPS for secure communication."
            }},
            { "cookies", new List<string> {
                "Clear cookies regularly to avoid tracking and protect your privacy.",
                "Some cookies can collect your browsing behavior—review and limit them.",
                "Adjust your browser settings to block third-party cookies."
            }},
            { "updates", new List<string> {
                "Always install updates—they often fix security vulnerabilities.",
                "Outdated software can be an entry point for cyberattacks.",
                "Enable auto-updates to stay protected without the hassle."
            }},
            { "backup", new List<string> {
                "Back up your data regularly to avoid losing important files.",
                "Use both cloud and physical backups for better protection.",
                "Test your backups periodically to make sure they work."
            }},
            { "bluetooth", new List<string> {
                "Turn off Bluetooth when you're not using it to avoid unauthorized access.",
                "Only pair with trusted devices in secure environments.",
                "Disable Bluetooth in public places unless necessary."
            }}
        };

        private static readonly Dictionary<string, string> sentimentResponses = new Dictionary<string, string>()
        {
            { "worried", "It's okay to feel worried. Let's explore how you can stay safe online." },
            { "frustrated", "I understand your frustration. Cybersecurity can be tricky, but I'm here to help." },
            { "curious", "Curiosity is great! Let's explore some cybersecurity tips together." }
        };


        public static void Main(string[] args)
        {
            AsciiArt.PlayVoiceGreeting();
            AsciiArt.ShowAsciiArt();

            Console.WriteLine("");
            userName = Greeting.AskUserName();

            while (true)
            {
                Console.Write($"\n{userName}, how can I assist you with cybersecurity today? (type 'menu' for topics or 'exit' to quit): ");
                string input = Console.ReadLine().ToLower();

                if (input.Contains("exit"))
                {
                    Console.WriteLine("\nThank you for chatting! Stay safe online.");
                    break;
                }

                if (input.Contains("menu"))
                {
                    DisplayMenu();
                    Console.Write("\nSelect a category (or type 'exit' to quit): ");
                    string menuInput = Console.ReadLine();

                    if (menuInput.ToLower() == "exit")
                    {
                        Console.WriteLine("\nThank you for using the Cyber Security Awareness Bot. Stay safe online!");
                        break;
                    }

                    if (int.TryParse(menuInput, out int categorychoice) && categorychoice >= 1 && categorychoice <= 6)
                    {
                        CategoryManager.ShowSubCategories(categorychoice);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid selection! Please enter a number between 1 and 6.");
                    }
                    continue;
                }

                var words = new HashSet<string>(input.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries));
                bool understood = false;

                foreach (var sentiment in sentimentResponses.Keys)
                {
                    if (input.Contains(sentiment))
                    {
                        Console.WriteLine($"\n{sentimentResponses[sentiment]}");
                        understood = true;
                    }
                }

                foreach (var word in words)
                {
                    string normalized = synonymMap.ContainsKey(word) ? synonymMap[word] : word;

                    if (keywordResponders.TryGetValue(normalized, out var responder))
                    {
                        if (userInterest == "" && normalized == "privacy")
                        {
                            userInterest = "privacy";
                            Console.WriteLine("\nGreat! I'll remember that you're interested in privacy.");
                        }

                        if (!string.IsNullOrEmpty(userInterest) && normalized == userInterest)
                        {
                            Console.WriteLine($"\nAs someone interested in {userInterest}, here's a helpful tip:");
                        }

                        Console.WriteLine($"\n🔐 {responder()}");
                        understood = true;
                    }
                    else if (keywordResponses.TryGetValue(normalized, out var responses))
                    {
                        Console.WriteLine($"\n🔐 {responses[random.Next(responses.Count)]}");
                        understood = true;
                    }
                }

                if (!understood)
                {
                    Console.WriteLine("\n🤖 I'm not sure I understand. Could you rephrase that?");
                }
            }
        }


        static void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===========================================");
            Console.WriteLine("|         CYBER SECURITY TOPICS           |");
            Console.WriteLine("===========================================");
            Console.WriteLine("| 1. Passwords                            |");
            Console.WriteLine("| 2. Phishing & Scams                     |");
            Console.WriteLine("| 3. Mobile & Device Safety               |");
            Console.WriteLine("| 4. Data & Identity Theft                |");
            Console.WriteLine("| 5. Safe Browsing                        |");
            Console.WriteLine("| 6. Network Security                     |");
            Console.WriteLine("===========================================");
            Console.ResetColor();
        }



        static void AnimatedText(string text, int delay = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

    }

}