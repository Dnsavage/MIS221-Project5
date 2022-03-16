namespace mis221_pa5_Dnsavage
{
    public class MenuDisplaysUtil
    {
        private MenuDisplays[] menuOptions;
        //No args constructor for MenuDisplayUtil
        public MenuDisplaysUtil()
        {

        }
        //Constructor for MenuDisplayUtil
        public MenuDisplaysUtil(MenuDisplays[] menuOptions)
        {
            this.menuOptions = menuOptions;
        }
        //Stores menu options in an array
        public string[] ToArray()
        {
            string[] optionsArray= new string[MenuDisplays.GetCount()];
            for (int i = 0; i < MenuDisplays.GetCount(); i++)
            {
                optionsArray[i] = menuOptions[i].GetOptions();
            }
            return optionsArray;
        }
    }
}