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
        public static void Main(string[] args)
        {
            AsciiArt.PlayVoiceGreeting();

            AsciiArt.ShowAsciiArt();

            Console.WriteLine("");

            AnimatedText("Hi I'm Pupet your Cyber Chatbot Friend and I'm here to help you stay safe in the fast advancing world of technology.\n" +
                "What's your name & Welcome to the Cyber Security Awareness Bot!", 30);
            Console.ResetColor();

            string userName = Console.ReadLine();

            AnimatedText($"\nHello, {userName}! Let's learn about cyber security.\n", 30);
            Thread.Sleep(500);

            while (true)
            {
                DisplayMenu();
                Console.Write("\nSelect a category (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    AnimatedText("\nThank you for using the Cyber Security Awareness Bot. Stay safe online!", 30);
                    break;
                }

                if (int.TryParse(input, out int categorychoice) && categorychoice >= 1 && categorychoice <= 6)
                {
                    CategoryManager.ShowSubCategories(categorychoice);
                }
                else
                {
                    AnimatedText("\nInvalid selection! Please enter a number between 1 and 6.", 20);
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