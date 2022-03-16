using System;
namespace mis221_pa5_Dnsavage
{
    public class SaveToFileMenu
    {
        private string number;
        //No args constructor for SaveToFileMenu
        public SaveToFileMenu()
        {

        }
        //Constructor fo rSaveToFileMenu
        public SaveToFileMenu(string number)
        {
            this.number = number;
        }
        //Displays the save to file menu
        public int DisplaySaveToFileOption()
        {
            Prompts[] saveReportMenuDisplays = new Prompts[1];
            MenuDisplays[] saveReportMenuOptions = new MenuDisplays[2];
            MenuDisplays.SetMenuType(14);

            DisplaysFile saveReportMenu = new DisplaysFile(saveReportMenuDisplays, saveReportMenuOptions);
            saveReportMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(saveReportMenuDisplays, saveReportMenuOptions);
            displayCurrent.DisplayText();

            if (GetSaveToFileChoice(saveReportMenuOptions) == 2)
            {
                Prompts.MainMenuPrompt();
                return -1;
            }
            else
            {
                Console.Clear();
                return 1;
            }
        }
        //Null/unexpected error handling for the save to file menu
        public int GetSaveToFileChoice(MenuDisplays[] saveReportMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(saveReportMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu saveToFile = new Menu();
            saveToFile = new Menu();
            saveToFile.SetNumOptions(saveReportMenuOptions.Length);
            saveToFile.SetOptions(options);
            int menuChoice = saveToFile.GetValidMenuChoice();
            return menuChoice;
        }
    }
}