using System;
namespace mis221_pa5_Dnsavage
{
    public class DisplaysReports
    {
        private Prompts[] displays;
        private MenuDisplays[] menuOptions;
        //no args constructor for DisplaysReports
        public DisplaysReports()
        {

        }
        //Constructor fo DisplaysReports
        public DisplaysReports(Prompts[] displays, MenuDisplays[] menuOptions)
        {
            this.displays = displays;
            this.menuOptions = menuOptions;
        }
        //Displays the selected menu
        public void DisplayText()
        {
            for (int i = 0; i < Prompts.GetCount(); i++)
            {
                Console.WriteLine($"{displays[i].GetPrompts()}");
            }
            for (int i = 0; i < MenuDisplays.GetCount(); i++)
            {
                Console.WriteLine($"{menuOptions[i].GetOptions()}");
            }
        }
    }
}