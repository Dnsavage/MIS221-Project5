using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class BigPicture
    {
        //Returns exit message path based on current language
        public static string GetExitMessagePath()
        {
            switch (Prompts.languageID)
            {
                case 1: return "ExitMessages/EnglishExit.txt";
                case 2: return "ExitMessages/SpanishExit.txt";
                case 3: return "ExitMessages/FrenchExit.txt";
                default: return "ExitMessages/GermanExit.txt";
            }
        }
        //Displays an ASCII exit message based on the current user language
        public static void DisplayExitMessage()
        {
            StreamReader inFile = new StreamReader(GetExitMessagePath());
            string line = inFile.ReadLine();

            while (line != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(line);
                line = inFile.ReadLine();
            }
            Console.ResetColor();
            Console.WriteLine();

            inFile.Close();
        }
        //Generates a random number 1-5
        public static int GetRandomNum()
        {
            Random imageGen = new Random();
            return (imageGen.Next(4)+1);
        }
        //Returns exit image path based on randomly generated number
        public static string GetExitImagePath()
        {
            switch (GetRandomNum())
            {
                case 1: return "ExitImages/TajMahal.txt";
                case 2: return "ExitImages/EiffelTower.txt";
                case 3: return "ExitImages/StatueLiberty.txt";
                case 4: return "ExitImages/Stonehenge.txt";
                default: return "ExitImages/SpaceNeedle.txt";
            }
        }
        //Displays a random ASCII exit image
        public static void DisplayExitImage()
        {
            StreamReader inFile = new StreamReader(GetExitImagePath());
            string line = inFile.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);
                line = inFile.ReadLine();
            }
            Console.ResetColor();
            Console.WriteLine();

            inFile.Close();
        }
    }
}