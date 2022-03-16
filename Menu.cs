using System;
namespace mis221_pa5_Dnsavage
{
    public class Menu
    {
        private int menuChoice;
        private string menuChoiceIn;
        private bool goodInput;
        private int numOptions;
        private string[] options;
        private string number;

        static private int count;
        //No args constructor
        public Menu()
        {

        }
        //Constructor for Menu
        public Menu(int menuChoice, string menuChoiceIn, bool goodInput, int numOptions, string[] options)
        {
            this.menuChoice = menuChoice;
            this.menuChoiceIn = menuChoiceIn;
            this.goodInput = goodInput;
            this.numOptions = numOptions;
            this.options = options;
        }
        //Sets the menu choice
        public void SetMenuChoice(int menuChoice)
        {
            this.menuChoice = menuChoice;
        }
        //Returns the menu choice when called
        public int GetMenuChoice()
        {
            return menuChoice;
        }
        //Sets the menu choice input
        public void SetMenuChoiceIn(string menuChoiceIn)
        {
            this.menuChoiceIn = menuChoiceIn;
        }
        //Returns the menu choice input
        public string GetMenuChoiceIn()
        {
            return menuChoiceIn;
        }
        //Sets good input
        public void SetGoodInput(bool goodInput)
        {
            this.goodInput = goodInput;
        }
        //Returns goodInput when called
        public bool GetGoodInput()
        {
            return goodInput;
        }
        //Sets the number of options
        public void SetNumOptions(int numOptions)
        {
            this.numOptions = numOptions;
        }
        //Returns the number of options when called
        public int GetNumOptions()
        {
            return numOptions;
        }
        //Sets the menu options
        public void SetOptions(string[] options)
        {
            this.options = options;
        }
        //Returns the menu options when called
        public string[] GetOptions()
        {
            return options;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            Menu.count = count;
        }
        //Increments the count by 1
        public static void IncCount()
        {
            count++;
        }
        //Returns the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the number to be error handled
        public void SetNumber(string number)
        {
            this.number = number;
        }
        //Returns the number to be error handled
        public string GetNumber()
        {
            return number;
        }
        //Null/unexpected error handling for menus
        public int GetValidMenuChoice()
        {
            menuChoice = 0;
            menuChoiceIn = Console.ReadLine();
            goodInput = (int.TryParse(menuChoiceIn, out menuChoice));
            while (goodInput != true || (menuChoice < 1 || menuChoice > numOptions))
            {
                Prompts.PromptValidOption();
                for (int i = 0; i < numOptions; i++)
                {
                    Console.WriteLine(options[i]);
                }
                menuChoiceIn = Console.ReadLine();
                goodInput = (int.TryParse(menuChoiceIn, out menuChoice));
            }
            return menuChoice;
        }
        //Null/unexpected error handling for integers
        public string GetValidInt()
        {
            int userNum = 0;
            number = Console.ReadLine();
            goodInput = (int.TryParse(number, out userNum));
            while (goodInput != true || userNum < 1)
            {
                Prompts.PromptValidInt();
                number = Console.ReadLine();
                goodInput = (int.TryParse(number, out userNum));
            }
            return userNum.ToString();
        }
    }
}