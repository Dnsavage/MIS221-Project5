using System;
namespace mis221_pa5_Dnsavage
{
    public class CompleteActivityMenu
    {
        private string number;
        //No args constructor for CompleteActivityMenu
        public CompleteActivityMenu()
        {

        }
        //Constructor for CompleteActivityMenu
        public CompleteActivityMenu(string number)
        {
            this.number = number;
        }
        //Returns an error handled ID
        public string GetValidID()
        {
            int userNum = 0;
            number = Console.ReadLine();
            if (number.ToLower() == "stop")
            {
                return "-1";
            }
            bool goodInput = (int.TryParse(number, out userNum));
            while (goodInput != true)
            {
                Prompts.PromptValidID();
                number = Console.ReadLine();
                if (number.ToLower() == "stop")
                {
                    return "-1";
                }
                goodInput = (int.TryParse(number, out userNum));
            }
            return userNum.ToString();
        }
        //Display menu for completion rating
        public string ProcessRatingMenu()
        {
            Prompts[] ratingMenuDisplays = new Prompts[1];
            MenuDisplays[] ratingMenuOptions = new MenuDisplays[5];
            MenuDisplays.SetMenuType(15);

            DisplaysFile ratingMenu = new DisplaysFile(ratingMenuDisplays, ratingMenuOptions);
            ratingMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(ratingMenuDisplays, ratingMenuOptions);
            displayCurrent.DisplayText();

            return Prompts.AssignRating(GetProcessRating(ratingMenuOptions));
        }
        //Error check completion rating selection
        public int GetProcessRating(MenuDisplays[] ratingMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(ratingMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu processRatingMenu = new Menu();
            processRatingMenu = new Menu();
            processRatingMenu.SetNumOptions(ratingMenuOptions.Length);
            processRatingMenu.SetOptions(options);
            int menuChoice = processRatingMenu.GetValidMenuChoice();
            return menuChoice;
        }
        //Display menu for completion recommendation
        public string ProcessRecommendMenu()
        {
            Prompts[] recommendMenuDisplays = new Prompts[1];
            MenuDisplays[] recommendMenuOptions = new MenuDisplays[2];
            MenuDisplays.SetMenuType(16);

            DisplaysFile recommendMenu = new DisplaysFile(recommendMenuDisplays, recommendMenuOptions);
            recommendMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(recommendMenuDisplays, recommendMenuOptions);
            displayCurrent.DisplayText();

            return Prompts.AssignRecommend(GetProcessRecommendation(recommendMenuOptions));
        }
        //Error check completion recommendation
        public int GetProcessRecommendation(MenuDisplays[] recommendMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(recommendMenuOptions);
            string[] options = convertOptions.ToArray();
            
            Menu processRecommendMenu = new Menu();
            processRecommendMenu = new Menu();
            processRecommendMenu.SetNumOptions(recommendMenuOptions.Length);
            processRecommendMenu.SetOptions(options);
            int menuChoice = processRecommendMenu.GetValidMenuChoice();
            return menuChoice;
        }
    }
}