using System;
namespace mis221_pa5_Dnsavage
{
    public class ActivityUtil
    {
        private Activity[] activities;
        //No Args constructor for ActivityUtil
        public ActivityUtil()
        {

        }
        //Constructor for ActivityUtil
        public ActivityUtil(Activity[] activities)
        {
            this.activities = activities;
        }
        //Assigns category names based on the current language
        public void AssignCategory(int catChoice, Activity[] activities)
        {
            activities[Activity.GetCount()].SetCategory(Prompts.AssignCatLanguage(catChoice));
        }
        //Checks for null user input and provides error if null
        public string GetValidInteger()
        {
            int number = 0;
            string userNumber = Console.ReadLine();
            bool goodInput = (int.TryParse(userNumber, out number));
            while (goodInput != true)
            {
                Prompts.PromptValidInt();
                userNumber = Console.ReadLine();
                goodInput = (int.TryParse(userNumber, out number));
            }
            return number.ToString();
        }
        //Error handles the max price entered by the user
        public string CheckMaxPrice(string userMax, Activity[] activities)
        {
            bool goodInput = true;
            int tempNum = 0;
            while (int.Parse(userMax) < int.Parse(activities[Activity.GetCount()].GetPriceMin()))
            {
                Prompts.PromptValidMaxPrice();
                userMax = Console.ReadLine();
                goodInput = int.TryParse(userMax, out tempNum);
                while (!goodInput)
                {
                    Prompts.PromptValidInt();
                    userMax = Console.ReadLine();
                    goodInput = int.TryParse(userMax, out tempNum);
                }
            }
            return userMax;
        }
        //Assigns a concatenated version of both activity time queries
        public void AssignTime(string timeChoice, string timeTaken, Activity[] activities)
        {
            if (int.Parse(timeTaken) > 1)
            {
                timeChoice = timeChoice + "s";
            }
            activities[Activity.GetCount()].SetTimeNeeded($"{timeTaken}-{timeChoice}");
        }
        //Assings the user's selected time category in the current language
        public string GetTimeChoice(int timeMenuChoice)
        {
            string[] timeChoice = new string[1];
            switch (timeMenuChoice)
            {
                case 1: timeChoice[0] = Prompts.AssignMinuteLanguage();
                    break;
                case 2: timeChoice[0] = Prompts.AssignHourLanguage();
                    break;
                default: timeChoice[0] = Prompts.AssignDayLanguage();
                    break;
            }
            return timeChoice[0];
        }
        //Assigns the user's selected ticket necessity in the current language
        public void AssignTicket(int ticketMenuChoice, Activity[] activities)
        {
            if (ticketMenuChoice == 1)
            {
                activities[Activity.GetCount()].SetTicketNeeded(Prompts.AssignYesLanguage());
            }
            else
            {
                activities[Activity.GetCount()].SetTicketNeeded(Prompts.AssignNoLanguage());
            }
        }
        //Directs flow of control for activity editing
        public void EditActivityField(int fieldEditChoice, int lineToEdit, Activity[] activities)
        {
            switch (fieldEditChoice)
            {
                case 1: Prompts.PromptEnterName();
                    string newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        activities[lineToEdit].SetName(newField);
                    }
                    break;
                case 2: 
                    Prompts[] catMenuEditDisplays = new Prompts[1];
                    MenuDisplays[] catMenuEditOptions = new MenuDisplays[9];
                    MenuDisplays.SetMenuType(6);

                    DisplaysFile activityMenu = new DisplaysFile(catMenuEditDisplays, catMenuEditOptions);
                    activityMenu.GetMenuDisplay();

                    DisplaysReports displayCurrent = new DisplaysReports(catMenuEditDisplays, catMenuEditOptions);
                    displayCurrent.DisplayText();

                    MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(catMenuEditOptions);
                    string[] options = convertOptions.ToArray();

                    Menu categoryMenu = new Menu();
                    categoryMenu = new Menu();
                    categoryMenu.SetNumOptions(catMenuEditOptions.Length);
                    categoryMenu.SetOptions(options);
                    AssignCategory(categoryMenu.GetValidMenuChoice(), activities);

                    break;
                case 3: Prompts.PromptMinPriceEdit();
                    newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        bool goodInput = false;
                        int tempNum = 0;
                        goodInput = int.TryParse(newField, out tempNum);
                        while (int.Parse(newField) > int.Parse(activities[lineToEdit].GetPriceMax()))
                        {
                            Prompts.PromptValidMinPrice();
                            newField = Console.ReadLine();
                            while (!goodInput)
                            {
                                Prompts.PromptValidInt();
                                newField = Console.ReadLine();
                                goodInput = int.TryParse(newField, out tempNum);
                            }
                        }
                        activities[lineToEdit].SetPriceMin(newField);
                    }
                    break;
                case 4: Prompts.PromptMaxPriceEdit();
                    newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        bool goodInput = true;
                        int tempNum = 0;
                        while (int.Parse(newField) < int.Parse(activities[lineToEdit].GetPriceMin()))
                        {
                            Prompts.PromptValidMaxPrice();
                            newField = Console.ReadLine();
                            goodInput = int.TryParse(newField, out tempNum);
                            while (!goodInput)
                            {
                                Prompts.PromptValidInt();
                                newField = Console.ReadLine();
                                goodInput = int.TryParse(newField, out tempNum);
                            }
                        }
                        activities[lineToEdit].SetPriceMax(newField);
                    }
                    break;
                case 5: 
                    Prompts[] editTimeMenuDisplays = new Prompts[1];
                    MenuDisplays[] editTimeMenuOptions = new MenuDisplays[3];
                    MenuDisplays.SetMenuType(7);

                    DisplaysFile pullTimeMenu = new DisplaysFile(editTimeMenuDisplays, editTimeMenuOptions);
                    pullTimeMenu.GetMenuDisplay();

                    DisplaysReports displayTimePrompt = new DisplaysReports(editTimeMenuDisplays, editTimeMenuOptions);
                    displayTimePrompt.DisplayText();

                    MenuDisplaysUtil convertTimeOptions = new MenuDisplaysUtil(editTimeMenuOptions);
                    string[] timeOptions = convertTimeOptions.ToArray();
                    
                    Menu timeMenu = new Menu();
                    timeMenu = new Menu();
                    timeMenu.SetNumOptions(editTimeMenuOptions.Length);
                    timeMenu.SetOptions(timeOptions);
                    int timeMenuChoice = timeMenu.GetValidMenuChoice();

                    Prompts.PromptAmountTime();
                    Menu time = new Menu();
                    string timeTaken = time.GetValidInt();
                    string timeChoice = GetTimeChoice(timeMenuChoice);
                    AssignTime(timeChoice, timeTaken, activities);

                    break;
                case 6: 
                    Prompts[] editTicketMenuDisplays = new Prompts[1];
                    MenuDisplays[] editTicketMenuOptions = new MenuDisplays[2];
                    MenuDisplays.SetMenuType(8);

                    DisplaysFile pullTicketMenu = new DisplaysFile(editTicketMenuDisplays, editTicketMenuOptions);
                    pullTicketMenu.GetMenuDisplay();

                    DisplaysReports displayTicketPrompt = new DisplaysReports(editTicketMenuDisplays, editTicketMenuOptions);
                    displayTicketPrompt.DisplayText();

                    MenuDisplaysUtil convertTicketOptions = new MenuDisplaysUtil(editTicketMenuOptions);
                    string[] ticketOptions = convertTicketOptions.ToArray();

                    Menu ticketMenu = new Menu();
                    ticketMenu = new Menu();
                    ticketMenu.SetNumOptions(editTicketMenuOptions.Length);
                    ticketMenu.SetOptions(ticketOptions);
                    int ticketMenuChoice = ticketMenu.GetValidMenuChoice();
                    AssignTicket(ticketMenuChoice, activities);

                    break;
                default: break;
            }
        }
    }
}