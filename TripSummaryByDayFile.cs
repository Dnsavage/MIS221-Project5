using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class TripSummaryByDayFile
    {
        private TripSummaryByDay[] dayByDayCompletions;
        //no args constructor for TripSummaryByDayFile
        public TripSummaryByDayFile()
        {

        }
        //Constructor for TripSummaryByDayFile
        public TripSummaryByDayFile(TripSummaryByDay[] dayByDayCompletions)
        {
            this.dayByDayCompletions = dayByDayCompletions;
        }
        //Pulls all completed activities from the completion file
        public int GetDayByDayCompletions()
        {
            TripSummaryByDay.SetCount(0);

            StreamReader completedFile = new StreamReader("completed.txt");
            string completeLine = completedFile.ReadLine();
            if (completeLine == null)
            {
                Prompts.NoneCompleted();
                completedFile.Close();
                return -1;
            }

            while (completeLine != null)
            {
                string[] tempArray = completeLine.Split('#');
                dayByDayCompletions[TripSummaryByDay.GetCount()] = new TripSummaryByDay(tempArray[0], tempArray[1],
                tempArray[2], tempArray[3]);
                TripSummaryByDay.IncCount();

                completeLine = completedFile.ReadLine();
            }
            completedFile.Close();
            return 1;
        }
        //Write the Summary report to the ByDayReport file
        public void SummaryToFile(TripSummaryByDay[] dayByDayCompletions)
        {
            Prompts.SummaryReportLocation();
            if (File.Exists("ByDayReport.txt"))
            {
                StreamWriter outFile = new StreamWriter("ByDayReport.txt");
                for (int i = 0; i < TripSummaryByDay.GetCount(); i++)
                {
                    Console.WriteLine(TripSummaryByDay.GetCount());
                    outFile.Write($"{dayByDayCompletions[i].GetName()} | ");
                    outFile.WriteLine($"{dayByDayCompletions[i].GetDateComplete()}");
                }
                outFile.Close();
                Prompts.ReportSuccessful();
            }
            else
            {
                Prompts.SummaryReportFailed();
            }
        }
    }
}