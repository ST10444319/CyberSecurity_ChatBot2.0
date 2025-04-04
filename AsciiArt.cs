using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity_ChatBot
{
    internal class AsciiArt
    {
        public static void ShowAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"

                 ____  _   _ ____  _____ _____   ___ ____    _   _ _____ ____  _____ 
                |  _ \| | | |  _ \| ____|_   _| |_ _/ ___|  | | | | ____|  _ \| ____|
                | |_) | | | | |_) |  _|   | |    | |\___ \  | |_| |  _| | |_) |  _|  
                |  __/| |_| |  __/| |___  | |    | | ___) | |  _  | |___|  _ <| |___ 
                |_|    \___/|_|   |_____| |_|   |___|____/  |_| |_|_____|_| \_\_____|

                     _____ ___    _   _ _____ _     ____   __   _____  _   _   _ _ 
                    |_   _/ _ \  | | | | ____| |   |  _ \  \ \ / / _ \| | | | | | |
                      | || | | | | |_| |  _| | |   | |_) |  \ V / | | | | | | | | |
                      | || |_| | |  _  | |___| |___|  __/    | || |_| | |_| | |_|_|
                      |_| \___/  |_| |_|_____|_____|_|       |_| \___/ \___/  (_|_)

");
            Console.ResetColor();
        }

        public static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play(); // Play audio synchronously

            }
            catch (Exception e)
            {
                Console.WriteLine("Error playing audio: " + e.Message);
            }
        }

        public static void ShowArtWithAudio()
        {
            Task.Run(() => PlayVoiceGreeting()); // Play audio in background
            ShowAsciiArt(); // Show ASCII art simultaneously
        }

    }

}

