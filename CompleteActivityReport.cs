using System;
namespace mis221_pa5_Dnsavage
{
    public class CompleteActivityReport
    {
        private CompleteActivity[] completeActivities;
        //No args constructor for CompleteActivityReport
        public CompleteActivityReport()
        {

        }
        //Constructor for CompleteActivityReport
        public CompleteActivityReport(CompleteActivity[] completeActivities)
        {
            this.completeActivities = completeActivities;
        }
        //Displays each activity completion
        public void DisplayAllActivities(CompleteActivity[] completeActivities)
        {
            Prompts.CompletedMessage();
            Prompts.CompletionFormatHeader();
            for (int i = 0; i < CompleteActivity.GetCount(); i++)
            {
                Console.Write($"{completeActivities[i].GetCompleteID()} | ");
                Console.Write($"{completeActivities[i].GetName()} | ");
                Console.Write($"{completeActivities[i].GetCategory()} | ");
                Console.Write($"{completeActivities[i].GetDateComplete()} | ");
                Console.Write($"${completeActivities[i].GetMoneySpent()} | ");
                Console.Write($"{completeActivities[i].GetRating()} | ");
                Console.WriteLine($"{completeActivities[i].GetRecommended()} ");
            }
        }

        //Displays a single activity completion based on user ID selection
        public void DisplayOneCompleted(int lineToEdit)
        {
            Prompts.CompletionFormatHeader();
            Console.Write($"{completeActivities[lineToEdit].GetCompleteID()} | ");
            Console.Write($"{completeActivities[lineToEdit].GetName()} | ");
            Console.Write($"{completeActivities[lineToEdit].GetCategory()} | ");
            Console.Write($"{completeActivities[lineToEdit].GetDateComplete()} | ");
            Console.Write($"${completeActivities[lineToEdit].GetMoneySpent()} | ");
            Console.Write($"{completeActivities[lineToEdit].GetRating()} | ");
            Console.WriteLine($"{completeActivities[lineToEdit].GetRecommended()} ");
        }
        //Checks if any Completed Activities exist
        public int CheckIfAnyActivities(CompleteActivity[] completeActivities)
        {
            if (CompleteActivity.GetCount() < 1)
            {
                Prompts.NoneCompleted();
                return -1;
            }
            else
            {
                DisplayAllActivities(completeActivities);
                return 1;
            }
        }
    }
}