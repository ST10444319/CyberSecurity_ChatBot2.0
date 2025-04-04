using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity_ChatBot
{
    internal class ResponseHandler
    {
        public static void DisplayInfo(int category, int subCategory)
        {
            string info = GetInformation(category, subCategory);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n📖 {info}");
            Console.ResetColor();

            Console.WriteLine("\nWhat would you like to do next?");
            Console.WriteLine("0. Return to Main Menu");
            Console.WriteLine("1. Choose a New Category");
            Console.WriteLine("2. Select a Different Sub-Category");

            string choice = Console.ReadLine();
            if (choice == "0") return;
            if (choice == "1") Program.Main(new string[0]);
            if (choice == "2") CategoryManager.ShowSubCategories(category);
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
                    case 4: return "Do not reuse the same passwords across different platforms. It increases the risk of security breaches";
                    case 5: return "Immediately compromised passwords, if a website or platform you use has been breached change the password to reduce risk.";
                    case 6: return "Use a password manager, generates complex";
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

    }
}
