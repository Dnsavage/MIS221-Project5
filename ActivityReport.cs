using System;
namespace mis221_pa5_Dnsavage
{
    public class ActivityReport
    {
        private Activity[] activities;
        //No args constructor for ActivityReport
        public ActivityReport()
        {

        }
        //Constructor for Activity Report
        public ActivityReport(Activity[] activities)
        {
            this.activities = activities;
        }

        //Displays all Activities currently in the activity list file
        public void DisplayAllActivities(Activity[] activities)
        {
            Prompts.ActivitiesMessage();
            Prompts.ActivityFormatHeader();
            for (int i = 0; i < Activity.GetCount(); i++)
            {
                Console.Write($"{activities[i].GetActID()} | ");
                Console.Write($"{activities[i].GetName()} | ");
                Console.Write($"{activities[i].GetCategory()} | ");
                Console.Write($"${activities[i].GetPriceMin()} | ");
                Console.Write($"${activities[i].GetPriceMax()} | ");
                Console.Write($"{activities[i].GetTimeNeeded()} | ");
                Console.WriteLine($"{activities[i].GetTicketNeeded()}");
            }
        }

        //Displays a single Activity based on user ID selection
        public void DisplayOneActivity(int lineToEdit)
        {
            Prompts.ActivityFormatHeader();
            Console.Write($"{activities[lineToEdit].GetActID()} | ");
            Console.Write($"{activities[lineToEdit].GetName()} | ");
            Console.Write($"{activities[lineToEdit].GetCategory()} | ");
            Console.Write($"${activities[lineToEdit].GetPriceMin()} | ");
            Console.Write($"${activities[lineToEdit].GetPriceMax()} | ");
            Console.Write($"{activities[lineToEdit].GetTimeNeeded()} | ");
            Console.WriteLine($"{activities[lineToEdit].GetTicketNeeded()}");
        }
        //Checks if any Activities exist
        public int CheckIfAnyActivities(Activity[] activities)
        {
            if (Activity.GetCount() < 1)
            {
                Prompts.PromptNoActivities();
                Prompts.PromptReturnToActMenu();
                return -1;
            }
            else
            {
                DisplayAllActivities(activities);
                return 1;
            }
        }
    }
}