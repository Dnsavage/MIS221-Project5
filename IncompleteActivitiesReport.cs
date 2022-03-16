using System;
namespace mis221_pa5_Dnsavage
{
    public class IncompleteActivitiesReport
    {
        private IncompleteActivities[] incompleteActivities;
        //No args constructor for IncompleteActivitiesreport
        public IncompleteActivitiesReport()
        {

        }
        //Constructor for IncompleteActivitiesReport
        public IncompleteActivitiesReport(IncompleteActivities[] incompleteActivities)
        {
            this.incompleteActivities = incompleteActivities;
        }
        //Displays all incomplete activity names
        public void DisplayIncompletes()
        {
            Prompts.IncompleteMessage();
            for (int i = 0; i < IncompleteActivities.GetCount(); i++)
            {
                //Console.Write($"{incompleteActivities[i].GetActID()} | ");
                Console.WriteLine($"{incompleteActivities[i].GetName()}");
            }
            Prompts.EnterToContinueMessage();
        }
    }
}