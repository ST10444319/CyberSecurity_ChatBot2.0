using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurity_ChatBot
{
    internal class Greeting
    {
        public static void AskUserName()
        {

            AnimatedText("Hi there I'm Pupet, What's your name & Welcome to the Cyber Security Awareness Bot!", 30);
            Console.ResetColor();
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Friend";
            }

            AnimatedText($"\nHello, {name}! Let's learn about cyber security.\n", 30);
            Thread.Sleep(500);
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
