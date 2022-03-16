using System;
namespace mis221_pa5_Dnsavage
{
    public class VacationUtil
    {
        private Vacation[] vacations;
        //No args constructor for VacationUtil
        public VacationUtil()
        {

        }
        //Constructor for VacationUtil
        public VacationUtil(Vacation[] vacations)
        {
            this.vacations = vacations;
        }
        //Changes the selected Vacation field based on user input
        public void EditVacationField(int fieldEditChoice, int lineToEdit)
        {
            int tempVacCount = Vacation.GetCount();
            Vacation.SetCount(lineToEdit);
            switch (fieldEditChoice)
            {
                case 1: Prompts.PromptDestination();
                    string newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        vacations[lineToEdit].SetDestination(newField);
                    }
                    break;
                case 2: Prompts.PromptStartDate();
                    newField = GetValidDate(-1, vacations);
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        vacations[lineToEdit].SetStartDate(newField);
                    }
                    break;
                case 3: Prompts.PromptEndDate();
                    newField = GetValidDate(1, vacations);
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        vacations[lineToEdit].SetEndDate(newField);
                    }
                    break;
                case 4: Prompts.PromptBudget();
                    newField = Console.ReadLine();
                    if(newField.ToLower() == "stop")
                    {
                        break;
                    }
                    else
                    {
                        vacations[lineToEdit].SetBudget(GetValidBudget(newField));
                    }
                    break;
                default: break;
            }
            Vacation.SetCount(tempVacCount);
        }
        //Null error handling for entered destination
        public string GetValidDestination(string destination)
        {
            if (destination.Length > 0)
            {
                return destination;
            }
            else
            {
                return Prompts.GetPlaceholderDestination();
            }
        }
        //Null/unexpected error handling for entered budget
        public string GetValidBudget(string budget)
        {
            int goodBudget = 0;
            bool goodInput = int.TryParse(budget, out goodBudget);
            while (!goodInput || goodBudget < 0)
            {
                Prompts.PromptValidBudget();
                budget = Console.ReadLine();
                goodInput = int.TryParse(budget, out goodBudget);
            }
            return budget;
        }
        //Null/unexpected error handling for entered start and end dates
        public string GetValidDate(int dateType, Vacation[] vacations)
        {
            string userDate = Console.ReadLine();
            string[] dateArray = userDate.Split("/");
            int monthSpecifier = 0;
            int[] daysInMonths = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            VacationReport dateError = new VacationReport();
            if (userDate.ToLower() == "stop")
            {
                return userDate;
            }

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
                    if (goodInput != true || (dateArray.Length < 3) || (dateArray.Length > 3) || 
                    (i == 0 && (number < 01 || number > 12)) || notADay || 
                    (i == 2 && (number < 1999 || number > 2099)))
                    {
                        Prompts.PromptDateError(4, -1);
                        failedCheck = true;
                        i = -1; //will increment to 0, thus restarting the outside for-loop
                    }
                    int endYear = int.Parse(dateArray[2]);
                    if ((i > -1 && i < 3) && dateType == 1)
                    {
                        string[] startDate = vacations[Vacation.GetCount()].GetStartDate().Split("/");
                        
                        //Months comparison
                        if (i == 0 && ((number < int.Parse(startDate[0])) && (endYear <= int.Parse(startDate[2]))))
                        {
                            Prompts.PromptDateError(i+1, dateType);
                            failedCheck = true;
                            i = -1;
                        }
                        //Days comparison
                        if (i == 1 && ((number < int.Parse(startDate[1])) && (monthSpecifier <= int.Parse(startDate[0])) && (endYear <= int.Parse(startDate[2]))))
                        {
                            Prompts.PromptDateError(i+1, dateType);
                            failedCheck = true;
                            i = -1;
                        }
                        //Year comparison
                        if (i == 2)
                        {
                            //Compare end-date year with start-date year
                            int year = 0;
                            bool yearCheck = (int.TryParse(startDate[2], out year));
                            if (yearCheck != true || (number < year))
                            {
                                Prompts.PromptDateError(i+1, dateType);
                                failedCheck = true;
                                i = -1;
                            }
                        }
                        
                    }
                    if (failedCheck == true)
                    {
                        userDate = Console.ReadLine();
                        dateArray = userDate.Split("/");
                    }
                }
            return userDate;
        }
    }
}