using System;
namespace mis221_pa5_Dnsavage
{
    public class RemainingActivitiesReport
    {
        private RemainingActivities[] remainActivities;
        //No args construtor for RemainingActivitiesReport
        public RemainingActivitiesReport()
        {

        }
        //Constructor for RemainingActivitiesReport
        public RemainingActivitiesReport(RemainingActivities[] remainActivities)
        {
            this.remainActivities = remainActivities;
        }
        //Displays all remaining activities
        public void DisplayAllRemaining(RemainingActivities[] remainActivities)
        {
            Prompts.RemainingMessage();
            Prompts.ActivityFormatHeader();
            for (int i = 0; i < RemainingActivities.GetCount(); i++)
            {
                Console.Write($"{remainActivities[i].GetActID()} | ");
                Console.Write($"{remainActivities[i].GetName()} | ");
                Console.Write($"{remainActivities[i].GetCategory()} | ");
                Console.Write($"${remainActivities[i].GetPriceMin()} | ");
                Console.Write($"${remainActivities[i].GetPriceMax()} | ");
                Console.Write($"{remainActivities[i].GetTimeNeeded()} | ");
                Console.WriteLine($"{remainActivities[i].GetTicketNeeded()}");
            }
            
        }
        //Checks if there are any remaining activities
        public int CheckIfAnyRemaining(RemainingActivities[] remainActivities)
        {
            if (Activity.GetCount() < 1)
            {
                Prompts.PromptNoRemaining();
                Prompts.MainMenuPrompt();
                return -1;
            }
            else
            {
                DisplayAllRemaining(remainActivities);
                return 1;
            }
        }
    }
}