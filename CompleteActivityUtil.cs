using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class CompleteActivityUtil
    {
        private CompleteActivity[] completeActivities;
        //No args constructor for CompleteActivityUtil
        public CompleteActivityUtil()
        {

        }
        //Constructor for CompleteActivityUtil
        public CompleteActivityUtil(CompleteActivity[] completeActivities)
        {
            this.completeActivities = completeActivities;
        }
        //Resolves date errors for activity completion dates
        public string ResolveDateErrors(string badDate)
        {
            string[] dateArray = badDate.Split("/");
            int monthSpecifier = 0;
            int[] daysInMonths = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

            StreamReader vacationFile = new StreamReader("vacation.txt");
            string vacationLine = vacationFile.ReadLine();
            string[] vacationArray = vacationLine.Split('#');
            string vacationStart = vacationArray[2];
            string[] vacationStartArray = vacationStart.Split("/");
            int vacationStartMonth = int.Parse(vacationStartArray[0]);
            int vacationStartDay = int.Parse(vacationStartArray[1]);
            int vacationStartYear = int.Parse(vacationStartArray[2]);
            string vacationEnd = vacationArray[3];
            string[] vacationEndArray = vacationEnd.Split("/");
            int vacationEndMonth = int.Parse(vacationEndArray[0]);
            int vacationEndDay = int.Parse(vacationEndArray[1]);
            int vacationEndYear = int.Parse(vacationEndArray[2]);
            vacationFile.Close();
            for (int i = 0; i < 3; i++)
            {
                bool failedCheck = false;
                int number = 0;
                bool notADay = false;
                string userNumber = dateArray[i];
                bool goodInput = (int.TryParse(userNumber, out number));
                if (i == 0)
                {
                        monthSpecifier = number;
                }
                if (i == 1)
                {
                    if (number < 1 || number > daysInMonths[monthSpecifier-1])
                    {
                        notADay = true;
                    }
                }
                while (goodInput != true || (dateArray.Length < 3) || (dateArray.Length > 3) || 
                (i == 0 && (number < 01 || number > 12)) || notADay || 
                (i == 2 && (number < 1999 || number > 2099)))
                {
                    Prompts.PromptDateError(4, -1);
                    badDate = Console.ReadLine();
                    dateArray = badDate.Split("/");
                    for (int j = 0; j < 3; j++)
                    {
                        if (dateArray.Length < 3 || dateArray.Length > 3)
                        {
                            break;
                        }
                        goodInput = (int.TryParse(dateArray[j], out number));
                        if (!goodInput)
                        {
                            break;
                        }
                    }
                    notADay = false;
                    i = -1; //will increment to 0, thus restarting the outside for-loop
                }
        //Start vacation date boundary checking HERE
                //Months comparison
                int completeYear = int.Parse(dateArray[2]);
                if (i == 0 && ((number < vacationStartMonth) && (completeYear <= vacationStartYear)))
                {
                    failedCheck = true;
                    i = -1;
                }
                else if (i == 0 && ((number > vacationEndMonth) && (completeYear >= vacationEndYear)))
                {
                    failedCheck = true;
                    i = -1;
                }
                //Days comparison
                if (i == 1 && ((number < vacationStartDay) && (monthSpecifier <= vacationStartMonth) && (completeYear <= vacationStartYear)))
                {
                    failedCheck = true;
                    i = -1;
                }
                else if (i == 1 && ((number > vacationEndDay) && (monthSpecifier >= vacationEndMonth) && (completeYear >= vacationEndYear)))
                {
                    failedCheck = true;
                    i = -1;
                }
                //Year comparison
                if (i == 2)
                {
                    if (number < vacationStartYear || number > vacationEndYear)
                    {
                        failedCheck = true;
                        i = -1;
                    }
                }
        //End vacation date boundary test HERE
                if (failedCheck == true)
                {
                    Prompts.PromptCompleteDateError(vacationStart, vacationEnd);
                    badDate = Console.ReadLine();
                    dateArray = badDate.Split("/");
                }
            }
            return badDate;
        }
        //Null/unexpected arror handling for amount spent
        public string GetValidSpent(string spent)
        {
            int goodSpent = 0;
            bool goodInput = int.TryParse(spent, out goodSpent);
            while (!goodInput || goodSpent < 0)
            {
                Prompts.PromptValidSpent();
                spent = Console.ReadLine();
                goodInput = int.TryParse(spent, out goodSpent);
            }
            return spent;
        }
        //Handles null reviews
        public string GetValidReview(string review)
        {
            if (review.Length > 0)
            {
                return review;
            }
            else
            {
                return Prompts.GetPlaceHolderReview();
            }
        }
        //Processes edits for completed activities
        public void EditCompletionField(int fieldEditChoice, int lineToEdit, CompleteActivity[] editComplete)
        {
            Console.Clear();
            switch (fieldEditChoice)
            {
                case 1: Prompts.PromptDateCompleted();
                    string newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        editComplete[lineToEdit].SetDateComplete(ResolveDateErrors(newField));
                    }
                    break;
                case 2: Prompts.PromptExpenditures();
                    newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        editComplete[lineToEdit].SetMoneySpent(GetValidSpent(newField));
                    }
                    break;
                case 3:
                    Prompts[] ratingMenuEditDisplays = new Prompts[1];
                    MenuDisplays[] ratingMenuEditOptions = new MenuDisplays[5];
                    MenuDisplays.SetMenuType(15);

                    DisplaysFile activityMenu = new DisplaysFile(ratingMenuEditDisplays, ratingMenuEditOptions);
                    activityMenu.GetMenuDisplay();

                    DisplaysReports displayCurrent = new DisplaysReports(ratingMenuEditDisplays, ratingMenuEditOptions);
                    displayCurrent.DisplayText();

                    MenuDisplaysUtil convertOptions = new MenuDisplaysUtil(ratingMenuEditOptions);
                    string[] options = convertOptions.ToArray();

                    Menu ratingMenu = new Menu();
                    ratingMenu = new Menu();
                    ratingMenu.SetNumOptions(ratingMenuEditOptions.Length);
                    ratingMenu.SetOptions(options);
                    editComplete[lineToEdit].SetRating(Prompts.AssignRating(ratingMenu.GetValidMenuChoice()));
                    break;
                case 4:Prompts.PromptReview();
                     newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        editComplete[lineToEdit].SetReview(GetValidReview(newField));
                    }
                    break;
                default:
                    Prompts[] recommendMenuEditDisplays = new Prompts[1];
                    MenuDisplays[] recommendMenuEditOptions = new MenuDisplays[2];
                    MenuDisplays.SetMenuType(16);

                    DisplaysFile recommendMenu = new DisplaysFile(recommendMenuEditDisplays, recommendMenuEditOptions);
                    recommendMenu.GetMenuDisplay();

                    DisplaysReports displayRecommend = new DisplaysReports(recommendMenuEditDisplays, recommendMenuEditOptions);
                    displayRecommend.DisplayText();

                    MenuDisplaysUtil convertRecommendOptions = new MenuDisplaysUtil(recommendMenuEditOptions);
                    string[] recommendOptions = convertRecommendOptions.ToArray();
            
                    Menu RecommendMenu = new Menu();
                    RecommendMenu = new Menu();
                    RecommendMenu.SetNumOptions(recommendMenuEditOptions.Length);
                    RecommendMenu.SetOptions(recommendOptions);
                    int menuChoice = RecommendMenu.GetValidMenuChoice();
                    editComplete[lineToEdit].SetRecommended(Prompts.AssignRecommend(RecommendMenu.GetValidMenuChoice()));
                    break;
            }
        }
    }
}