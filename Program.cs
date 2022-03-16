using System;

namespace mis221_pa5_Dnsavage
{
    class Program
    {
        static void Main(string[] args)
        {
            VerifyFile.DisplayMissingFiles();
            DisplayLanguageMenu();
            DisplayMainMenu();
        }
        
        //Flow of control to fabricate a Main Menu in the selected language
        static void DisplayMainMenu()
        {
            Prompts[] mainMenuDisplays = new Prompts[2];
            MenuDisplays[] mainMenuOptions = new MenuDisplays[7];
            MenuDisplays.SetMenuType(0);

            DisplaysFile mainMenu = new DisplaysFile(mainMenuDisplays, mainMenuOptions);
            mainMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(mainMenuDisplays, mainMenuOptions);
            displayCurrent.DisplayText();
            
            int menuChoice = GetMainMenuChoice(mainMenuOptions);
            RouteMainMenu(menuChoice);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetMainMenuChoice(MenuDisplays[] mainMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(mainMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu mainMenu = new Menu();
            mainMenu = new Menu();
            mainMenu.SetNumOptions(mainMenuOptions.Length);
            mainMenu.SetOptions(options);
            int menuChoice = mainMenu.GetValidMenuChoice();
            return menuChoice;
        }
        //Direct flow of control for user's Main Menu decision
        static void RouteMainMenu(int menuChoice)
        {
            
            switch (menuChoice)
            {
                case 1: DisplayVacationMenu();
                    break;
                case 2: DisplayActivityMenu();
                    break;
                case 3: DisplayRemainingMenu();
                    break;
                case 4: DisplayCompleteMenu();
                    break;
                case 5: DisplayTripReportMenu();
                    break;
                case 6: DisplayLanguageMenu();
                    break;
                default: Prompts.ThankUser();
                    BigPicture.DisplayExitMessage();
                    BigPicture.DisplayExitImage();
                    Environment.Exit(0);
                    break;
            }
        }

        //Display Program Language Options
        static void DisplayLanguageMenu()
        {
            Prompts.LanguageMenu();
            int menuChoice = GetLanguageChoice();
            Prompts.SetLanguageID(menuChoice);
            Console.Clear();
            DisplayMainMenu();
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetLanguageChoice()
        {
            string[] options = Prompts.LanguageOptions();

            Menu languageMenu = new Menu();
            languageMenu = new Menu();
            languageMenu.SetNumOptions(options.Length);
            languageMenu.SetOptions(options);
            int menuChoice = languageMenu.GetValidMenuChoice();
            return menuChoice;
        }
        
        static void DisplayVacationMenu()
        {
            Console.Clear();
            Vacation[] vacations = new Vacation[3];
            Prompts[] vacationMenuDisplays = new Prompts[1];
            MenuDisplays[] vacationMenuOptions = new MenuDisplays[3];
            MenuDisplays.SetMenuType(1);

            DisplaysFile vacationMenu = new DisplaysFile(vacationMenuDisplays, vacationMenuOptions);
            vacationMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(vacationMenuDisplays, vacationMenuOptions);
            displayCurrent.DisplayText();

            int vacMenuChoice = GetVacMenuChoice(vacationMenuOptions);
            RouteVacMenuChoice(vacMenuChoice, vacations);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetVacMenuChoice(MenuDisplays[] vacationMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(vacationMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu vacationMenu = new Menu();
            vacationMenu = new Menu();
            vacationMenu.SetNumOptions(vacationMenuOptions.Length);
            vacationMenu.SetOptions(options);
            int menuChoice = vacationMenu.GetValidMenuChoice();
            return menuChoice;
        }
        //Direct flow of control for user's Vacation Menu decision
        static void RouteVacMenuChoice(int vacMenuChoice, Vacation[] vacations)
        {
            
            switch (vacMenuChoice)
            {
                case 1: VacationFile newVacation = new VacationFile(vacations);
                    newVacation.GetAllVacations();
                    if (Vacation.GetCount() < 1)
                    {
                        newVacation.GetNewVacationInfo(vacations);
                    }
                    else
                    {
                        Prompts.PromptCantAddVacation();
                    }
                    DisplayVacationMenu();
                    break;
                case 2: DisplayEditVacMenu(vacations);
                    break;
                default: Console.Clear();
                    DisplayMainMenu();
                    break;
            }
        }
        
        static void DisplayEditVacMenu(Vacation[] vacations)
        {
            Console.Clear();
            VacationFile editVacMenu = new VacationFile(vacations);
            editVacMenu.GetAllVacations();

            VacationReport checkForVacations = new VacationReport();
            if (checkForVacations.CheckIfAnyVacations(vacations) < 0)
            {
                DisplayVacationMenu();
            }

            Prompts.PromptForVacID();
            string vacEditID = Console.ReadLine();

            if (vacEditID.ToLower() == "stop")
            {
                DisplayVacationMenu();
            }

            int lineToEdit = editVacMenu.GetUserLineToEdit(vacEditID);
            if (lineToEdit < 0)
            {
                Prompts.DisplayAbortEditMessage();
                Console.ReadLine();
                DisplayVacationMenu();
            }

            Prompts.EditingMessage();
            VacationReport singleLine = new VacationReport(vacations);
            singleLine.DisplayOneVacation(lineToEdit);

            VacEditOrDeleteMenu(lineToEdit, vacations, singleLine);
            
        }
        
        static void VacEditOrDeleteMenu(int lineToEdit, Vacation[] vacations, VacationReport singleLine)
        {
            Prompts[] vacEditOrDeleteMenuDisplays = new Prompts[1];
            MenuDisplays[] vacEditOrDeleteMenuOptions = new MenuDisplays[3];
            MenuDisplays.SetMenuType(2);

            DisplaysFile vacationMenu = new DisplaysFile(vacEditOrDeleteMenuDisplays, vacEditOrDeleteMenuOptions);
            vacationMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(vacEditOrDeleteMenuDisplays, vacEditOrDeleteMenuOptions);
            displayCurrent.DisplayText();

            int editOrDeleteChoice = GetEditOrDeleteChoice(vacEditOrDeleteMenuOptions);
            RouteEditOrDelete(editOrDeleteChoice, lineToEdit, vacations, singleLine);

        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetEditOrDeleteChoice(MenuDisplays[] vacEditOrDeleteMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(vacEditOrDeleteMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu editOrDelete = new Menu();
            editOrDelete = new Menu();
            editOrDelete.SetNumOptions(vacEditOrDeleteMenuOptions.Length);
            editOrDelete.SetOptions(options);
            int menuChoice = editOrDelete.GetValidMenuChoice();
            return menuChoice;
        }
        //Direct flow of control for user's edit/delete decision
        static void RouteEditOrDelete(int editOrDeleteChoice, int lineToEdit, Vacation[] vacations, 
        VacationReport singleLine)
        {
            switch (editOrDeleteChoice)
            {
                case 1: DisplayEditFieldMenu(lineToEdit, vacations, singleLine);
                    break;
                case 2: DeleteVacationChoice(lineToEdit, vacations, singleLine);
                    break;
                default: DisplayVacationMenu();
                    break;
            }
        }
        
        static void DisplayEditFieldMenu(int lineToEdit, Vacation[] vacations, VacationReport singleLine)
        {
            Prompts.EditingMessage();
            singleLine.DisplayOneVacation(lineToEdit);

            Prompts[] editFieldMenuDisplays = new Prompts[1];
            MenuDisplays[] editFieldMenuOptions = new MenuDisplays[5];
            MenuDisplays.SetMenuType(3);

            DisplaysFile vacationMenu = new DisplaysFile(editFieldMenuDisplays, editFieldMenuOptions);
            vacationMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(editFieldMenuDisplays, editFieldMenuOptions);
            displayCurrent.DisplayText();

            int fieldEditChoice = GetEditVacFieldChoice(editFieldMenuOptions);
            EditVacationField(lineToEdit, fieldEditChoice, vacations);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetEditVacFieldChoice(MenuDisplays[] editFieldMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(editFieldMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu editVacationField = new Menu();
            editVacationField = new Menu();
            editVacationField.SetNumOptions(editFieldMenuOptions.Length);
            editVacationField.SetOptions(options);
            int menuChoice = editVacationField.GetValidMenuChoice();
            return menuChoice;
        }
        //Direct the flow of control based on which field is selected
        static void EditVacationField(int lineToEdit, int fieldEditChoice, Vacation[] vacations)
        {
            if (fieldEditChoice == 6)
            {
                DisplayMainMenu();
            }
            else
            {
                VacationUtil newEdit = new VacationUtil(vacations);
                newEdit.EditVacationField(fieldEditChoice, lineToEdit);
                VacationFile.EditVacationToFile(vacations);
                DisplayVacationMenu();
            }
        }
        //Flow of control to ask user if they are sure they want to delete the selected vacation
        static void DeleteVacationChoice(int lineToEdit, Vacation[] vacations, VacationReport singleLine)
        {
            Prompts.DeletingMessage();
            singleLine.DisplayOneVacation(lineToEdit);

            Prompts[] deleteVacMenuDisplays = new Prompts[3];
            MenuDisplays[] deleteVacMenuOptions = new MenuDisplays[2];
            MenuDisplays.SetMenuType(4);

            DisplaysFile vacationMenu = new DisplaysFile(deleteVacMenuDisplays, deleteVacMenuOptions);
            vacationMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(deleteVacMenuDisplays, deleteVacMenuOptions);
            displayCurrent.DisplayText();

            int deleteVerify = GetDeleteVerify(deleteVacMenuOptions);
            RouteDeleteChoice(deleteVerify, lineToEdit, vacations);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetDeleteVerify(MenuDisplays[] deleteVacMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(deleteVacMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu verifyDeleteVacation = new Menu();
            verifyDeleteVacation = new Menu();
            verifyDeleteVacation.SetNumOptions(deleteVacMenuOptions.Length);
            verifyDeleteVacation.SetOptions(options);
            int menuChoice = verifyDeleteVacation.GetValidMenuChoice();
            return menuChoice;
        }
        //Direct flow of control for user's vacation deletion decision
        static void RouteDeleteChoice(int deleteVerify, int lineToEdit, Vacation[] vacations)
        {
            if (deleteVerify == 1)
            {
                //Your current report files will be saved until a new one is generated. 
                //All other files will be cleared.
                CompleteActivityFile.DeleteAllCompletionsFromFile();
                ActivityFile.DeleteAllActivitiesFromFile();
                VacationFile.DeleteVacationFromFile(lineToEdit, vacations);
                Prompts.DeleteVacMessage();
                DisplayVacationMenu();
            }
            else
            {
                Prompts.AbortVacDeletionMessage();
                DisplayVacationMenu();
            }
        }

        static void DisplayActivityMenu()
        {
            Console.Clear();
            Prompts[] activityMenuDisplays = new Prompts[1];
            MenuDisplays[] activityMenuOptions = new MenuDisplays[4];
            MenuDisplays.SetMenuType(5);

            DisplaysFile activityMenu = new DisplaysFile(activityMenuDisplays, activityMenuOptions);
            activityMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(activityMenuDisplays, activityMenuOptions);
            displayCurrent.DisplayText();

            int actMenuChoice = GetActMenuChoice(activityMenuOptions);
            RouteActMenuChoice(actMenuChoice);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetActMenuChoice(MenuDisplays[] activityMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(activityMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu activityMenu = new Menu();
            activityMenu = new Menu();
            activityMenu.SetNumOptions(activityMenuOptions.Length);
            activityMenu.SetOptions(options);
            int menuChoice = activityMenu.GetValidMenuChoice();
            return menuChoice;
        }
        //Directs flow of control based on user's Activity Menu choice
        static void RouteActMenuChoice(int actMenuChoice)
        {
            Activity[] activities = new Activity[50];
            switch (actMenuChoice)
            {
                case 1: ViewActivities(activities);
                    break;
                case 2: NewActivity(activities);
                    break;
                case 3: DisplayEditActMenu(activities);
                    break;
                default: Console.Clear();
                    DisplayMainMenu();
                    break;
            }
        }
        //Flow of control to display all activities previously entered by user
        static void ViewActivities(Activity[] activities)
        {
            Console.Clear();
            ActivityFile activityFill = new ActivityFile(activities);
            activityFill.GetAllActivities();
            ActivityReport checkForVacations = new ActivityReport();
            if (checkForVacations.CheckIfAnyActivities(activities) < 0)
            {
                DisplayActivityMenu();
            }
            Prompts.PromptReturnToActMenu();
            DisplayActivityMenu();
        }
        //Flow of control to display the new activity menu
        static void NewActivity(Activity[] activities)
        {
            Vacation[] indexVac = new Vacation[3];
            VacationFile countVac = new VacationFile(indexVac);
            countVac.GetAllVacations();
            if (Vacation.GetCount() < 1)
            {
                Prompts.PromptNeedVacation();
                DisplayMainMenu();
            }

            Prompts.PromptActDetails();
            ActivityFile newID = new ActivityFile(activities);
            newID.GetAllActivities();
            activities[Activity.GetCount()] = new Activity();
            activities[Activity.GetCount()].SetActID(newID.GenActivityID());

            Prompts.PromptName();
            string activityDetail = Console.ReadLine();
            activities[Activity.GetCount()].SetName(activityDetail);

            DisplayCategoryMenu(activities);

            Prompts.PromptMinPrice();
            ActivityUtil newActivityCheck = new ActivityUtil();
            activityDetail = newActivityCheck.GetValidInteger();
            activities[Activity.GetCount()].SetPriceMin(activityDetail);

            Prompts.PromptMaxPrice();
            activityDetail = newActivityCheck.GetValidInteger();
            activityDetail = newActivityCheck.CheckMaxPrice(activityDetail, activities);
            activities[Activity.GetCount()].SetPriceMax(activityDetail);

            DisplayTimeMenu(activities);

            DisplayTicketMenu(activities);

            ActivityFile.NewActivityToFile(activities);
            Activity.IncCount();
            DisplayActivityMenu();
        }

        static void DisplayCategoryMenu(Activity[] activities)
        {
            Prompts[] catMenuDisplays = new Prompts[1];
            MenuDisplays[] catMenuOptions = new MenuDisplays[9];
            MenuDisplays.SetMenuType(6);

            DisplaysFile vacationMenu = new DisplaysFile(catMenuDisplays, catMenuOptions);
            vacationMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(catMenuDisplays, catMenuOptions);
            displayCurrent.DisplayText();

            int catMenuChoice = GetCatMenuChoice(catMenuOptions);
            ActivityUtil catAssign = new ActivityUtil();
            catAssign.AssignCategory(catMenuChoice, activities);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetCatMenuChoice(MenuDisplays[] catMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(catMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu categoryMenu = new Menu();
            categoryMenu = new Menu();
            categoryMenu.SetNumOptions(catMenuOptions.Length);
            categoryMenu.SetOptions(options);
            int menuChoice = categoryMenu.GetValidMenuChoice();
            return menuChoice;
        }

        static void DisplayTimeMenu(Activity[] activities)
        {
            Prompts[] timeMenuDisplays = new Prompts[1];
            MenuDisplays[] timeMenuOptions = new MenuDisplays[3];
            MenuDisplays.SetMenuType(7);

            DisplaysFile getTimeMenu = new DisplaysFile(timeMenuDisplays, timeMenuOptions);
            getTimeMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(timeMenuDisplays, timeMenuOptions);
            displayCurrent.DisplayText();

            int timeMenuChoice = GetTimeMenuChoice(timeMenuOptions);
            Prompts.PromptAmountTime();
            Menu time = new Menu();
            string timeTaken = time.GetValidInt();
            ActivityUtil timeAssign = new ActivityUtil();
            string timeChoice = timeAssign.GetTimeChoice(timeMenuChoice);
            timeAssign.AssignTime(timeChoice, timeTaken, activities);
            
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetTimeMenuChoice(MenuDisplays[] timeMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(timeMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu timeMenu = new Menu();
            timeMenu = new Menu();
            timeMenu.SetNumOptions(timeMenuOptions.Length);
            timeMenu.SetOptions(options);
            int menuChoice = timeMenu.GetValidMenuChoice();
            return menuChoice;
        }

        static void DisplayTicketMenu(Activity[] activities)
        {
            Prompts[] ticketMenuDisplays = new Prompts[1];
            MenuDisplays[] ticketMenuOptions = new MenuDisplays[2];
            MenuDisplays.SetMenuType(8);

            DisplaysFile ticketMenu = new DisplaysFile(ticketMenuDisplays, ticketMenuOptions);
            ticketMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(ticketMenuDisplays, ticketMenuOptions);
            displayCurrent.DisplayText();

            int ticketMenuChoice = GetTicketMenuChoice(ticketMenuOptions);
            ActivityUtil ticketAssign = new ActivityUtil();
            ticketAssign.AssignTicket(ticketMenuChoice, activities);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetTicketMenuChoice(MenuDisplays[] ticketMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(ticketMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu ticketMenu = new Menu();
            ticketMenu = new Menu();
            ticketMenu.SetNumOptions(ticketMenuOptions.Length);
            ticketMenu.SetOptions(options);
            int menuChoice = ticketMenu.GetValidMenuChoice();
            return menuChoice;
        }

        static void DisplayEditActMenu(Activity[] activities)
        {
            Console.Clear();
            ActivityFile editActMenu = new ActivityFile(activities);
            editActMenu.GetAllActivities();

            ActivityReport checkForActivities = new ActivityReport();
            if (checkForActivities.CheckIfAnyActivities(activities) < 0)
            {
                DisplayActivityMenu();
            }

            Prompts.PromptForActIDEdit();
            string actEditID = Console.ReadLine();

            int lineToEdit = editActMenu.GetUserLineToEdit(actEditID, activities);
            if (lineToEdit < 0)
            {
                Prompts.AbortActEditMessage();
                DisplayActivityMenu();
            }

            Prompts.EditingMessage();
            ActivityReport singleLine = new ActivityReport(activities);
            singleLine.DisplayOneActivity(lineToEdit);

            ActEditOrDeleteMenu(lineToEdit, activities, singleLine, actEditID);
        }

        static void ActEditOrDeleteMenu(int lineToEdit, Activity[] activities, ActivityReport singleLine, string actEditID)
        {
            Prompts[] actEditMenuDisplays = new Prompts[1];
            MenuDisplays[] actEditMenuOptions = new MenuDisplays[3];
            MenuDisplays.SetMenuType(9);

            DisplaysFile editOrDeleteMenu = new DisplaysFile(actEditMenuDisplays, actEditMenuOptions);
            editOrDeleteMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(actEditMenuDisplays, actEditMenuOptions);
            displayCurrent.DisplayText();

            int editOrDeleteChoice = GetActEditOrDeleteChoice(actEditMenuOptions);
            RouteActEditOrDelete(editOrDeleteChoice, lineToEdit, activities, singleLine, actEditID);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetActEditOrDeleteChoice(MenuDisplays[] actEditMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(actEditMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu actEditOrDelete = new Menu();
            actEditOrDelete = new Menu();
            actEditOrDelete.SetNumOptions(actEditMenuOptions.Length);
            actEditOrDelete.SetOptions(options);
            int menuChoice = actEditOrDelete.GetValidMenuChoice();
            return menuChoice;
        }
        //Direct flow of control based on user's Activity Edit or Delete Menu selection
        static void RouteActEditOrDelete(int editOrDeleteChoice, int lineToEdit, Activity[] activities, 
        ActivityReport singleLine, string actEditID)
        {
            switch (editOrDeleteChoice)
            {
                case 1: DisplayEditActFieldMenu(lineToEdit, activities, singleLine);
                    break;
                case 2: DeleteActivityChoice(lineToEdit, activities, singleLine, actEditID);
                    break;
                default: DisplayActivityMenu();
                    break;
            }
        }

        static void DisplayEditActFieldMenu(int lineToEdit, Activity[] activities, ActivityReport singleLine)
        {
            Prompts.EditingMessage();
            singleLine.DisplayOneActivity(lineToEdit);
            Prompts[] actEditFieldMenuDisplays = new Prompts[1];
            MenuDisplays[] actEditFieldMenuOptions = new MenuDisplays[7];
            MenuDisplays.SetMenuType(10);

            DisplaysFile actEditMenu = new DisplaysFile(actEditFieldMenuDisplays, actEditFieldMenuOptions);
            actEditMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(actEditFieldMenuDisplays, actEditFieldMenuOptions);
            displayCurrent.DisplayText();
            int fieldEditChoice = GetEditActFieldChoice(actEditFieldMenuOptions);
            EditActivityField(lineToEdit, fieldEditChoice, activities);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetEditActFieldChoice(MenuDisplays[] actEditFieldMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(actEditFieldMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu editActivityField = new Menu();
            editActivityField = new Menu();
            editActivityField.SetNumOptions(actEditFieldMenuOptions.Length);
            editActivityField.SetOptions(options);
            int menuChoice = editActivityField.GetValidMenuChoice();
            return menuChoice;
        }
        //Directs flow of control based on user's Edit Activity Field Menu selection
        static void EditActivityField(int lineToEdit, int fieldEditChoice, Activity[] activities)
        {
            if (fieldEditChoice == 7)
            {
                DisplayActivityMenu();
            }
            else
            {
                ActivityUtil newEdit = new ActivityUtil(activities);
                newEdit.EditActivityField(fieldEditChoice, lineToEdit, activities);
                ActivityFile newCount = new ActivityFile(activities);
                ActivityFile.EditActivityToFile(activities);
                DisplayActivityMenu();
            }
        }
        //Flow of control to ask user if they are sure they want to delete the selected activity
        static void DeleteActivityChoice(int lineToEdit, Activity[] activities, ActivityReport singleLine, string actEditID)
        {
            Prompts.DeletingMessage();
            singleLine.DisplayOneActivity(lineToEdit);
            Prompts[] deleteActMenuDisplays = new Prompts[1];
            MenuDisplays[] deleteActMenuOptions = new MenuDisplays[2];
            MenuDisplays.SetMenuType(11);

            DisplaysFile deleteActMenu = new DisplaysFile(deleteActMenuDisplays, deleteActMenuOptions);
            deleteActMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(deleteActMenuDisplays, deleteActMenuOptions);
            displayCurrent.DisplayText();

            int deleteVerify = GetDeleteActVerify(deleteActMenuOptions);
            RouteDeleteActChoice(deleteVerify, lineToEdit, activities, actEditID);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetDeleteActVerify(MenuDisplays[] deleteActMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(deleteActMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu verifyDeleteActivity = new Menu();
            verifyDeleteActivity = new Menu();
            verifyDeleteActivity.SetNumOptions(deleteActMenuOptions.Length);
            verifyDeleteActivity.SetOptions(options);
            int menuChoice = verifyDeleteActivity.GetValidMenuChoice();
            return menuChoice;
        }
        //Direct flow of control for user's vacation deletion decision
        static void RouteDeleteActChoice(int deleteVerify, int lineToEdit, Activity[] activities, string actEditID)
        {
            if (deleteVerify == 1)
            {
                ActivityFile.DeleteActivityFromFile(lineToEdit, activities);
                CompleteActivity[] deleteComplete = new CompleteActivity[50];
                CompleteActivityFile deleteActivity = new CompleteActivityFile(deleteComplete);
                deleteActivity.GetCompletedActivities();
                CompleteActivityFile.DeleteCompletionWithActivity(actEditID, deleteComplete);
                Prompts.DeleteActMessage();
                DisplayActivityMenu();
            }
            else
            {
                Prompts.AbortActDeletionMessage();
                DisplayActivityMenu();
            } 
        }

        static void DisplayCompleteMenu()
        {
            Console.Clear();
            Prompts[] completeMenuDisplays = new Prompts[1];
            MenuDisplays[] completeActMenuOptions = new MenuDisplays[4];
            MenuDisplays.SetMenuType(17);

            DisplaysFile completeMenu = new DisplaysFile(completeMenuDisplays, completeActMenuOptions);
            completeMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(completeMenuDisplays, completeActMenuOptions);
            displayCurrent.DisplayText();

            int completeChoice = GetCompleteMenuChoice(completeActMenuOptions);
            RouteCompleteMenu(completeChoice);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetCompleteMenuChoice(MenuDisplays[] completeActMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(completeActMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu completeMenu = new Menu();
            completeMenu = new Menu();
            completeMenu.SetNumOptions(completeActMenuOptions.Length);
            completeMenu.SetOptions(options);
            int menuChoice = completeMenu.GetValidMenuChoice();
            return menuChoice;
        }
        //Directs flow of control based on user's Complete Menu selection
        static void RouteCompleteMenu(int completeChoice)
        {
            switch (completeChoice)
            {
                case 1: CompleteActivities();
                    break;
                case 2: EditCompletions();
                    break;
                case 3: DeleteCompletions();
                    break;
                default: Console.Clear();
                    DisplayMainMenu();
                    break;
            }
        }
        //Flow of control for the Add Completion Process
        static void CompleteActivities()
        {
            Console.Clear();
            Vacation[] vacationCount = new Vacation[50];
            Activity[] checkActivities = new Activity[50];

            ActivityFile completedPrimer1 = new ActivityFile(checkActivities);
            completedPrimer1.GetAllActivities();

            if (Activity.GetCount() < 1)
            {
                Prompts.PromptNoActivities();
                Prompts.MainMenuPrompt();
                DisplayMainMenu();
            }

            CompleteActivity[] newCompletes = new CompleteActivity[50];
            CompleteActivityFile fillCompletes = new CompleteActivityFile(newCompletes);
            fillCompletes.GetCompletedActivities();

            RemainingActivities[] checkRemaining = new RemainingActivities[50];
            RemainingActivitiesFile completedPrimer2 = new RemainingActivitiesFile(checkRemaining);
            completedPrimer2.GetRemainingActivities();

            RemainingActivitiesReport remainingActivities = new RemainingActivitiesReport();
            if (remainingActivities.CheckIfAnyRemaining(checkRemaining) < 0)
            {
                DisplayMainMenu();
            }
            VacationFile checkForVacation = new VacationFile(vacationCount);
            checkForVacation.GetAllVacations();
            if (Vacation.GetCount() > 0)
            {
                CompleteActivity[] completeActivities = new CompleteActivity[50];
                CompleteActivityFile processInfo = new CompleteActivityFile(completeActivities);
                processInfo.GetCompletedActivities();
                if (processInfo.GetNewProcessInformation() < 0)
                {
                    Prompts.PromptAbortCompletion();
                }
                else
                {
                    Prompts.PromptProcessedCompletion();
                }
            }
            else
            {
                Prompts.PromptCantComplete();
            }
            
            Prompts.MainMenuPrompt();
            DisplayMainMenu();
        }
        //Flow of control for the Completions Edit Process
        static void EditCompletions()
        {
            Console.Clear();
            CompleteActivity[] editComplete = new CompleteActivity[50];
            CompleteActivityFile editCompletionMenu = new CompleteActivityFile(editComplete);
            editCompletionMenu.GetCompletedActivities();

            CompleteActivityReport checkForCompletions = new CompleteActivityReport();
            if (checkForCompletions.CheckIfAnyActivities(editComplete) < 0)
            {
                DisplayMainMenu();
            }

            Prompts.PromptForCompleteIDEdit();
            string completeEditID = Console.ReadLine();

            int lineToEdit = editCompletionMenu.GetUserLineToEdit(completeEditID, editComplete);
            if (lineToEdit < 0)
            {
                Prompts.AbortCompletionEditMessage();
                DisplayCompleteMenu();
            }

            Prompts.EditingMessage();
            CompleteActivityReport singleLine = new CompleteActivityReport(editComplete);
            singleLine.DisplayOneCompleted(lineToEdit);

            EditCompletionFieldMenu(lineToEdit, editComplete, singleLine);

            
        }

        static void EditCompletionFieldMenu(int lineToEdit, CompleteActivity[] editComplete, CompleteActivityReport singleLine)
        {
            Prompts[] completeEditFieldMenuDisplays = new Prompts[1];
            MenuDisplays[] completeEditFieldMenuOptions = new MenuDisplays[6];
            MenuDisplays.SetMenuType(18);

            DisplaysFile completionFieldMenu = new DisplaysFile(completeEditFieldMenuDisplays, completeEditFieldMenuOptions);
            completionFieldMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(completeEditFieldMenuDisplays, completeEditFieldMenuOptions);
            displayCurrent.DisplayText();

            int fieldEditChoice = GetCompletionField(completeEditFieldMenuOptions);
            EditCompletionField(lineToEdit, fieldEditChoice, editComplete);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetCompletionField(MenuDisplays[] completeEditFieldMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(completeEditFieldMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu editCompletionField = new Menu();
            editCompletionField = new Menu();
            editCompletionField.SetNumOptions(completeEditFieldMenuOptions.Length);
            editCompletionField.SetOptions(options);
            int menuChoice = editCompletionField.GetValidMenuChoice();
            return menuChoice;
        }
        //Directs flow of control based on user's Completion Field Menu selection
        static void EditCompletionField(int lineToEdit, int fieldEditChoice, CompleteActivity[] editComplete)
        {
            if (fieldEditChoice == 6)
            {
                DisplayCompleteMenu();
            }
            else
            {
                CompleteActivityUtil newEdit = new CompleteActivityUtil(editComplete);
                newEdit.EditCompletionField(fieldEditChoice, lineToEdit, editComplete);
                CompleteActivityFile.EditCompletionToFile(editComplete);
                DisplayCompleteMenu();
            }
        }
        //Flow of control for the Completions Deletion Process
        static void DeleteCompletions()
        {
            CompleteActivity[] deleteComplete = new CompleteActivity[50];
            CompleteActivityFile deleteCompletionMenu = new CompleteActivityFile(deleteComplete);
            deleteCompletionMenu.GetCompletedActivities();

            CompleteActivityReport checkForCompletions = new CompleteActivityReport();
            if (checkForCompletions.CheckIfAnyActivities(deleteComplete) < 0)
            {
                DisplayMainMenu();
            }

            Prompts.PromptForCompleteIDDelete();
            string completeDeleteID = Console.ReadLine();

            int lineToEdit = deleteCompletionMenu.GetUserLineToEdit(completeDeleteID, deleteComplete);
            if (lineToEdit < 0)
            {
                Prompts.AbortCompletionDeletionMessage();
                DisplayCompleteMenu();
            }

            Prompts.DeletingMessage();
            CompleteActivityReport singleLine = new CompleteActivityReport(deleteComplete);
            singleLine.DisplayOneCompleted(lineToEdit);
            Prompts[] completeMenuDeleteDisplays = new Prompts[1];
            MenuDisplays[] completeMenuDeleteOptions = new MenuDisplays[2];
            MenuDisplays.SetMenuType(19);

            DisplaysFile deleteMenu = new DisplaysFile(completeMenuDeleteDisplays, completeMenuDeleteOptions);
            deleteMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(completeMenuDeleteDisplays, completeMenuDeleteOptions);
            displayCurrent.DisplayText();

            int deleteVerify = GetDeleteCompleteVerify(completeMenuDeleteOptions);
            RouteDeleteCompleteChoice(deleteVerify, lineToEdit, deleteComplete);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetDeleteCompleteVerify(MenuDisplays[] completeMenuDeleteOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(completeMenuDeleteOptions);
            string[] options = convertOptions.ToArray();

            Menu deleteCompletion = new Menu();
            deleteCompletion = new Menu();
            deleteCompletion.SetNumOptions(completeMenuDeleteOptions.Length);
            deleteCompletion.SetOptions(options);
            int menuChoice = deleteCompletion.GetValidMenuChoice();
            return menuChoice;
        }
        //Directs flow of control based on user's Delete Completion Menu selection
        static void RouteDeleteCompleteChoice(int deleteVerify, int lineToEdit, CompleteActivity[] deleteComplete)
        {
            if (deleteVerify == 1)
            {
                CompleteActivityFile.DeleteCompletionFromFile(lineToEdit, deleteComplete);
                Prompts.DeleteCompletionMessage();
            }
            else
            {
                Prompts.AbortCompletionDeletionMessage();
            } 
            DisplayCompleteMenu();
        }

        static void DisplayRemainingMenu()
        {
            Console.Clear();
            RemainingActivities[] remainActivities = new RemainingActivities[50];
            Activity[] allQuery = new Activity[50];
            CompleteActivity[] omissionQuery = new CompleteActivity[50];
            ActivityFile actsToCompare = new ActivityFile(allQuery);
            actsToCompare.GetAllActivities();

            CompleteActivityFile actsToOmit = new CompleteActivityFile(omissionQuery);
            actsToOmit.GetCompletedActivities();

            RemainingActivitiesFile actsToKeep = new RemainingActivitiesFile(remainActivities);
            if (actsToKeep.CheckIfAnyActivities(remainActivities) < 0)
            {
                DisplayMainMenu();
            }
            if (actsToKeep.GetRemainingActivities() < 0)
            {
                DisplayMainMenu();
            }
            Prompts[] remainSortMenuDisplays = new Prompts[1];
            MenuDisplays[] remainSortMenuOptions = new MenuDisplays[12];
            MenuDisplays.SetMenuType(12);

            DisplaysFile vacationMenu = new DisplaysFile(remainSortMenuDisplays, remainSortMenuOptions);
            vacationMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(remainSortMenuDisplays, remainSortMenuOptions);
            displayCurrent.DisplayText();

            int remainingSortChoice = GetRemainingSortChoice(remainSortMenuOptions);
            RouteRemainingSortChoice(remainingSortChoice, remainActivities);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetRemainingSortChoice(MenuDisplays[] remainSortMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(remainSortMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu remainingSortMenu = new Menu();
            remainingSortMenu = new Menu();
            remainingSortMenu.SetNumOptions(remainSortMenuOptions.Length);
            remainingSortMenu.SetOptions(options);
            int menuChoice = remainingSortMenu.GetValidMenuChoice();
            return menuChoice;
        }
        //Directs flow of control based on user's Remaining Sort Menu selection
        static void RouteRemainingSortChoice(int remainingSortChoice, RemainingActivities[] remainActivities)
        {
            RemainingActivitiesReport remaining = new RemainingActivitiesReport();
            RemainingActivitiesUtil sort = new RemainingActivitiesUtil(remainActivities);

            switch (remainingSortChoice)
            {
                case 1: remaining.DisplayAllRemaining(remainActivities);
                    break;
                case 2: sort.SortByCategory(remainingSortChoice);
                    break;
                case 3: sort.SortByCategory(remainingSortChoice);
                    break;
                case 4: sort.SortByTime(remainingSortChoice);
                    break;
                case 5: sort.SortByTime(remainingSortChoice);
                    break;
                case 6: sort.SortByPrice(remainingSortChoice);
                    break;
                case 7: sort.SortByPrice(remainingSortChoice);
                    break;
                case 8: sort.SortByPrice(remainingSortChoice);
                    break;
                case 9: sort.SortByPrice(remainingSortChoice);
                    break;
                case 10: sort.SortByTicketNeed(remainingSortChoice);
                    break;
                case 11: sort.SortByTicketNeed(remainingSortChoice);
                    break;
                default: Console.Clear();
                    DisplayMainMenu();
                    break;
            }
            remaining.DisplayAllRemaining(remainActivities);
            Prompts.MainMenuPrompt();
            DisplayMainMenu();
        }

        static void DisplayTripReportMenu()
        {
            Console.Clear();
            Prompts[] tripReportMenuDisplays = new Prompts[1];
            MenuDisplays[] tripReportMenuOptions = new MenuDisplays[5];
            MenuDisplays.SetMenuType(13);

            DisplaysFile reportMenu = new DisplaysFile(tripReportMenuDisplays, tripReportMenuOptions);
            reportMenu.GetMenuDisplay();

            DisplaysReports displayCurrent = new DisplaysReports(tripReportMenuDisplays, tripReportMenuOptions);
            displayCurrent.DisplayText();

            int tripReportChoice = GetTripReportChoice(tripReportMenuOptions);
            RouteTripReportChoice(tripReportChoice);
        }
        //Passes user input through menu class for null/unexpected error handling
        static int GetTripReportChoice(MenuDisplays[] tripReportMenuOptions)
        {
            MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(tripReportMenuOptions);
            string[] options = convertOptions.ToArray();

            Menu tripReportMenu = new Menu();
            tripReportMenu = new Menu();
            tripReportMenu.SetNumOptions(tripReportMenuOptions.Length);
            tripReportMenu.SetOptions(options);
            int menuChoice = tripReportMenu.GetValidMenuChoice();
            return menuChoice;
        }
        //Directs flow of control based on user's Report Menu selection
        static void RouteTripReportChoice(int tripReportChoice)
        {
            SaveToFileMenu toFileOption = new SaveToFileMenu();
            EventsCat[] events = new EventsCat[50];
            FoodDrinkCat[] foodDrinks = new FoodDrinkCat[50];
            GamesCat[] games = new GamesCat[50];
            MuseumsCat[] museums = new MuseumsCat[50];
            NatureCat[] natures = new NatureCat[50];
            NightLifeCat[] nightLives = new NightLifeCat[50];
            ShoppingCat[] shoppings = new ShoppingCat[50];
            ToursCat[] tours = new ToursCat[50];
            WorkshopsCat[] workshops = new WorkshopsCat[50];
            switch (tripReportChoice)
            {
                case 1: TripSummaryProcess(toFileOption);
                    break;
                case 2: FavActSummaryProcess(toFileOption);
                    break;
                case 3: IncompleteSummaryProcess(toFileOption);
                    break;
                case 4: RecommendSummaryProcess(toFileOption, events, foodDrinks, games, museums, natures, 
                nightLives, shoppings, tours, workshops);
                    break;
                default: SpendingSummaryProcess(toFileOption, events, foodDrinks, games, museums, natures, 
                nightLives, shoppings, tours, workshops);
                    break;
            }
        }
        //Flow of control for the Trip Summary Process
        static void TripSummaryProcess(SaveToFileMenu toFileOption)
        {
            TripSummaryByDay[] dayByDayCompletions = new TripSummaryByDay[50];
            TripSummaryByDayFile fillDayByDay = new TripSummaryByDayFile(dayByDayCompletions);
            if (fillDayByDay.GetDayByDayCompletions() < 0)
            {
                DisplayMainMenu();
            }

            TripSummaryByDayUtil sort = new TripSummaryByDayUtil(dayByDayCompletions);
            sort.SortByDay();

            TripSummaryByDayReport reportDayByDay = new TripSummaryByDayReport(dayByDayCompletions);
            reportDayByDay.DisplayTripSummary();
            if(toFileOption.DisplaySaveToFileOption() > 0)
            {
                fillDayByDay.SummaryToFile(dayByDayCompletions);
            }
            DisplayMainMenu();
        }
        //Flow of control for the Favorite Activity Summary Process
        static void FavActSummaryProcess(SaveToFileMenu toFileOption)
        {
            FavoriteActivities[] favoriteActivities = new FavoriteActivities[50];
            FavoriteActivitiesFile fillFavorites = new FavoriteActivitiesFile(favoriteActivities);
            if (fillFavorites.GetFavoriteCompletions() < 0)
            {
                DisplayMainMenu();
            }

            FavoriteActivitiesUtil sort = new FavoriteActivitiesUtil(favoriteActivities);
            sort.SortByRating();

            FavoriteActivitiesReport reportFavorites = new FavoriteActivitiesReport(favoriteActivities);
            reportFavorites.DisplayFavorites();
            if (toFileOption.DisplaySaveToFileOption() > 0)
            {
                fillFavorites.FavoritesToFile(favoriteActivities);
            }
            DisplayMainMenu();
        }
        //Flow of control for the Incomplete Activities Summary Process
        static void IncompleteSummaryProcess(SaveToFileMenu toFileOption)
        {
            IncompleteActivities[] incompleteActivities = new IncompleteActivities[50];
            IncompleteActivitiesFile fillIncompletes = new IncompleteActivitiesFile(incompleteActivities);

            if (fillIncompletes.GetIncompleteActivities() < 0)
            {
                DisplayMainMenu();
            }

            IncompleteActivitiesReport reportIncompletes = new IncompleteActivitiesReport(incompleteActivities);
            reportIncompletes.DisplayIncompletes();
            if (toFileOption.DisplaySaveToFileOption() > 0)
            {
                fillIncompletes.IncompletesToFile(incompleteActivities);
            }
            DisplayMainMenu();
        }
        //Flow of control for the Recommended Activities Summary Process
        static void RecommendSummaryProcess(SaveToFileMenu toFileOption, EventsCat[] events, FoodDrinkCat[] foodDrinks, 
        GamesCat[] games, MuseumsCat[] museums, NatureCat[] natures, NightLifeCat[] nightLives, 
        ShoppingCat[] shoppings, ToursCat[] tours, WorkshopsCat[] workshops)
        {
            RecommendationsFile fillRecommendations = new RecommendationsFile(events, foodDrinks, games, 
            museums, natures, nightLives, shoppings, tours, workshops);
            if (fillRecommendations.GetRecommendations() < 0)
            {
                DisplayMainMenu();
            }
            
            RecommendationsUtil sort = new RecommendationsUtil(events, foodDrinks, games, museums, 
            natures, nightLives, shoppings, tours, workshops);
            sort.SortByPrice();

            RecommendationsReport reportRecommendations = new RecommendationsReport(events, foodDrinks, 
            games, museums, natures, nightLives, shoppings, tours, workshops);
            reportRecommendations.DisplayRecommendations();
            if (toFileOption.DisplaySaveToFileOption() > 0)
            {
                fillRecommendations.RecommendationsToFile(events, foodDrinks, games, museums, natures, 
                nightLives, shoppings, tours, workshops);
            }
            DisplayMainMenu();
        }
        //Flow of control for the Spending Report Summary Process
        static void SpendingSummaryProcess(SaveToFileMenu toFileOption, EventsCat[] events, FoodDrinkCat[] foodDrinks, 
        GamesCat[] games, MuseumsCat[] museums, NatureCat[] natures, NightLifeCat[] nightLives, 
        ShoppingCat[] shoppings, ToursCat[] tours, WorkshopsCat[] workshops)
        {
            Spending[] expenditures = new Spending[50];
            SpendingFile fillExpenditures = new SpendingFile(expenditures, events, foodDrinks, 
            games, museums, natures, nightLives, shoppings, tours, workshops);
            if (fillExpenditures.GetExpenditures() < 0)
            {
                DisplayMainMenu();
            }
            SpendingUtil sortAndSum = new SpendingUtil(expenditures, events, foodDrinks, 
            games, museums, natures, nightLives, shoppings, tours, workshops);
            sortAndSum.GetSpendingSum();
            sortAndSum.SortByPrice();

            SpendingReport reportSpending = new SpendingReport(expenditures, events, foodDrinks, 
            games, museums, natures, nightLives, shoppings, tours, workshops);
            reportSpending.DisplayExpenditures();
            if (toFileOption.DisplaySaveToFileOption() > 0)
            {
                fillExpenditures.SpendingToFile(expenditures);
            }
            DisplayMainMenu();
        }
    }
}
