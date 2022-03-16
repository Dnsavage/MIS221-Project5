namespace mis221_pa5_Dnsavage
{
    public class MenuDisplays
    {
        private string options;
        public static int count;
        public static int menuType;
        //No args constructor for MenuDisplays
        public MenuDisplays()
        {

        }
        //Constructor for MenuDisplays
        public MenuDisplays(string options)
        {
            this.options = options;
        }
        //Sets the menu options
        public void SetOptions(string options)
        {
            this.options = options;
        }
        //Returns the menu options when called
        public string GetOptions()
        {
            return options;
        }
        //Sets the menu type
        public static void SetMenuType(int menuType)
        {
            MenuDisplays.menuType = menuType;
        }
        //Returns the menu type when called
        public static int GetMenuType()
        {
            return menuType;
        }
        //Returns the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            MenuDisplays.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
    }
}