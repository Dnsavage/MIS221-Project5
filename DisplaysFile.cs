using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class DisplaysFile
    {
        private Prompts[] displays;
        private MenuDisplays[] menuOptions;
        //No args constructor 
        public DisplaysFile()
        {

        }
        //Constructor for DisplaysFile
        public DisplaysFile(Prompts[] displays, MenuDisplays[] menuOptions)
        {
            this.displays = displays;
            this.menuOptions = menuOptions;
        }
        //Pulls the appropriate menu display in the current language
        public void GetMenuDisplay()
        {
            Prompts.SetCount(0);
            MenuDisplays.SetCount(0);

            string fileToOpen = GetMenuFilePath();

            StreamReader inFile = new StreamReader(fileToOpen);
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                if (int.Parse(tempArray[0]) == Prompts.GetLanguageID())//If file ID matches what's on record
                {
                    if (int.Parse(tempArray[1]) == Prompts.GetDisplayID())//If this is a display line
                    {
                        displays[Prompts.GetCount()] = new Prompts (tempArray[2]);
                        Prompts.IncCount();
                    }
                    
                    else if (int.Parse(tempArray[1]) == Prompts.GetOptionsID())//If this is an options line
                    {
                        menuOptions[MenuDisplays.GetCount()] = new MenuDisplays(tempArray[2]);
                        MenuDisplays.IncCount();
                    }
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        //Gets the appropriate menu file path based on the current menu
        public string GetMenuFilePath()
        {
            StreamReader pathIn = new StreamReader("MenuFilePaths.txt");
            string line = pathIn.ReadLine();
            int count = 0;

            while (line != null)
            {
                if (count != MenuDisplays.GetMenuType())
                {
                    count++;
                    line = pathIn.ReadLine();
                }
                else
                {
                    break;
                }
                
            }
            pathIn.Close();
            return line;
        }
    }
}