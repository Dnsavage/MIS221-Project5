using System;
namespace mis221_pa5_Dnsavage
{
    public class TripSummaryByDayReport
    {
        private TripSummaryByDay[] dayByDayCompletions;
        //No args constructor for TripSummaryByDayReport
        public TripSummaryByDayReport()
        {

        }
        //Constructor for TripSummaryByDayReport
        public TripSummaryByDayReport(TripSummaryByDay[] dayByDayCompletions)
        {
            this.dayByDayCompletions = dayByDayCompletions;
        }
        // Display all activities from the Summary report
        public void DisplayTripSummary()
        {
            Prompts.CompletedMessage();
            Prompts.TripSummaryFormatHeader();
            for (int i = 0; i < TripSummaryByDay.GetCount(); i++)
            {
                Console.Write($"{dayByDayCompletions[i].GetName()} | ");
                Console.WriteLine($"{dayByDayCompletions[i].GetDateComplete()}");
            }
            Prompts.EnterToContinueMessage();
        }
    }
}