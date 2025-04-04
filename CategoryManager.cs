using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurity_ChatBot
{
    internal class CategoryManager
    {
        // Main cybersecurity categories
        public static Dictionary<int, string> GetCategories()
        {
            return new Dictionary<int, string>
            {

                { 1, " --Password Security"},
                { 2, " --Phishing & Scams"},
                { 3, " --Mobile & Device Safety"},
                { 4, " --Data & Identity Theft"},
                { 5, " --Safe Browsing"},
                { 6, " --Firewalls & Network Security"}
            };
        }

        public static void ShowSubCategories(int categoryChoice)
        {
            Dictionary<int, string> subCategories = GetSubCategories(categoryChoice);

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n========================================");
                Console.WriteLine("|        SELECT A SUB-CATEGORY         |");
                Console.WriteLine("========================================");
                foreach (var sub in subCategories)
                {
                    Console.WriteLine($"| {sub.Key}. {sub.Value}           ");
                }
                Console.WriteLine("| 0. Go Back to Main Menu              |");
                Console.WriteLine("========================================\n");
                Console.ResetColor();

                Console.Write("Choose a sub-category: ");
                string subInput = Console.ReadLine();

                if (subInput == "0")
                    return;

                if (int.TryParse(subInput, out int subCategory) && subCategories.ContainsKey(subCategory))
                {
                    Console.Clear();
                    AnimatedText("\n" + GetInformation(categoryChoice, subCategory), 20);
                    Thread.Sleep(1000);

                    Console.Write("\n(0) Main Menu | (1) Select New Category | (2) Choose Another Topic: ");
                    string nextAction = Console.ReadLine();

                    if (nextAction == "0")
                        return;
                    else if (nextAction == "1")
                        break;
                }
                else
                {
                    AnimatedText("\nInvalid selection! Please try again.", 20);
                }
            }
        }

        private static string GetInformation(int category, int subCategory)
        {
            if (category == 1) //Passwaord Security
            {
                switch (subCategory)
                {
                    case 1: return "Strong passwords should be at least 12-16 characters long and include letters, numbers, and symbols.";
                    case 2: return "Two-factor authentication adds an extra layer of security by requiring an additional code or method beyond your password.";
                    case 3: return "Password managers help securely store and manage complex passwords.";
                    case 4: return "Always log out of accounts when using public or shared computers to prevent unauthorized access.";
                    default: return "Unknown topic";
                }
            }
            else if (category == 2) //Phishing & scams
            {
                switch (subCategory)
                {
                    case 1: return "Phishing is an attempt to trick you into revealing personal information, usually via fake emails or websites.";
                    case 2: return "Common scam tactics include fake job offers, lottery winnings, and impersonation scams.";
                    case 3: return "To avoid phishing, never click suspicious links and verify the sender's identity.";
                    default: return "Unknown topic";
                }
            }
            else if (category == 3) // Mobile & Device Safety
            {
                switch (subCategory)
                {
                    case 1: return "Keep your phone safe by using strong passwords, enabling remote wipe features, and updating your OS regularly.";
                    case 2: return "Only install apps from official stores (Google Play, Apple Store), and review app permissions before installing.";
                    case 3: return "Avoid using public Wi-Fi for sensitive transactions, disable Bluetooth when not in use, and be cautious of untrusted networks.";
                    default: return "Unknown topic";
                }
            }
            else if (category == 4) // Data & Identity Theft
            {
                switch (subCategory)
                {
                    case 1: return "Identity theft occurs when someone steals your personal data to commit fraud. Protect yourself by using strong passwords and monitoring your accounts.";
                    case 2: return "If you've been hacked, immediately change your passwords, enable multi-factor authentication, and report suspicious activity.";
                    case 3: return "The dark web is a hidden part of the internet where stolen data is often sold. Be cautious of where you share personal information.";
                    default: return "Unknown topic";
                }
            }
            else if (category == 5) // Safe Browsing
            {
                switch (subCategory)
                {
                    case 1: return "To browse safely, avoid clicking on unknown links, clear cookies regularly, and ensure your browser is updated.";
                    case 2: return "HTTPS (Hypertext Transfer Protocol Secure) ensures that the website encrypts your data, making it safer to browse and enter information.";
                    case 3: return "Malicious ads, also known as malvertising, can deliver malware. Use ad blockers and avoid clicking on pop-up ads.";
                    default: return "Unknown topic";
                }
            }
            else if (category == 6) // Network Security
            {
                switch (subCategory)
                {
                    case 1: return "Firewalls help block unauthorized access to your computer by filtering incoming and outgoing network traffic.";
                    case 2: return "Public Wi-Fi can be insecure. Avoid using it for banking or personal transactions, and use a VPN when possible.";
                    case 3: return "A VPN (Virtual Private Network) encrypts your internet traffic, protecting your online identity and data from hackers.";
                    default: return "Unknown topic";
                }
            }

            return "No information available.";
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

        private static Dictionary<int, string> GetSubCategories(int category)
        {
            switch (category)
            {
                case 1:
                    return new Dictionary<int, string>
            {
                { 1, "Why strong passwords?" },
                { 2, "2FA & Multi-factor authentication" },
                { 3, "Password Managers" },
                { 4, "Shared Devices" }
            };
                case 2:
                    return new Dictionary<int, string>
            {
                { 1, "What is Phishing?" },
                { 2, "Common Scam Tactics" },
                { 3, "How to Avoid Phishing" }
            };
                case 3:
                    return new Dictionary<int, string>
            {
                { 1, "Phone Security Tips" },
                { 2, "Safe Mobile Apps" },
                { 3, "Bluetooth & Wi-Fi Risks" }
            };
                case 4:
                    return new Dictionary<int, string>
            {
                { 1, "Preventing Identity Theft" },
                { 2, "What to do if hacked?" },
                { 3, "Dark Web Threats" }
            };
                case 5:
                    return new Dictionary<int, string>
            {
                { 1, "Safe Internet Practices" },
                { 2, "HTTPS & Secure Sites" },
                { 3, "Avoiding Malicious Ads" }
            };
                case 6:
                    return new Dictionary<int, string>
            {
                { 1, "What is a Firewall?" },
                { 2, "Public Wi-Fi Risks" },
                { 3, "How VPNs Protect You" }
            };
                default:
                    return new Dictionary<int, string>();
            }
        }


    }
}