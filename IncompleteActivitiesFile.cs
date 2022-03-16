using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class IncompleteActivitiesFile
    {
        private IncompleteActivities[] incompleteActivities;
        //No args constructor for IncompleteActivitiesFile
        public IncompleteActivitiesFile()
        {

        }
        //Constructor for IncompleteActivitiesFile
        public IncompleteActivitiesFile(IncompleteActivities[] incompleteActivities)
        {
            this.incompleteActivities = incompleteActivities;
        }
        //Determines which activities are incomplete by comparing completions vs all activities
        public int GetIncompleteActivities()
        {
            string[,] allActivities = GetAllActivities();
            string[] omissionIDs = GetOmissionIDs();
            string[] clearOmitIDs = new string [Activity.GetCount()];
            IncompleteActivities.SetCount(0);

            if (allActivities[0,0] == "-1")
            {
                Prompts.NoneIncompleted();
                return -1;
            }

            if (omissionIDs[0] == "-1")
            {
                for (int i = 0; i < Activity.GetCount(); i++)
                {
                    incompleteActivities[IncompleteActivities.GetCount()] = new IncompleteActivities(
                        allActivities[i, 0], allActivities[i, 1]);
                    IncompleteActivities.IncCount();
                }
                return 1;
            }

            if (CompareAllActivities(allActivities, omissionIDs) < 0)
            {
                Prompts.NoneIncompleted();
                return -1;
            }

            for (int i = 0; i < Activity.GetCount(); i++)
            {
                
                for (int j = 0; j < CompleteActivity.GetCount(); j++)
                {
                    if ((omissionIDs[j] == allActivities[i, 0]))
                    {
                        break;
                    }

                    else if ((omissionIDs[j] != allActivities[i, 0]) && (j != CompleteActivity.GetCount() - 1))
                    {
                        continue;
                    }
                    
                    else
                    {
                        incompleteActivities[IncompleteActivities.GetCount()] = new IncompleteActivities(
                            allActivities[i, 0], allActivities[i, 1]);
                        IncompleteActivities.IncCount();
                        clearOmitIDs[i] = allActivities[i, 0];
                    }
                }
            }
            return 1;
        }
        //Pull all current activities and stores in a 2D array for comparison
        public string[,] GetAllActivities()
        {
            int count = 0;
            Activity[] forComparison = new Activity[50];
            ActivityFile countActivities = new ActivityFile(forComparison);
            countActivities.GetAllActivities();

            string[,] allActivities = new string[Activity.GetCount(), 7];
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();

            if (line == null)
            {
                string[,] noActivities = new string[1, 7];
                noActivities[0,0] = "-1";
                inFile.Close();
                return noActivities;
            }

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                for (int i = 0; i < 7; i++)
                {
                    allActivities[count, i] = tempArray[i];
                }
                count++;

                line = inFile.ReadLine();
            }
            inFile.Close();
            return allActivities;
        }
        //Pulls all completed origin IDs to omit in the incomplete activities process
        public string[] GetOmissionIDs()//Compare tempArray[1] of CompleteActs with tempArray[0] of AllActs
        {
            int count = 0;
            CompleteActivity[] forComparison = new CompleteActivity[50];
            CompleteActivityFile countCompletes = new CompleteActivityFile(forComparison);
            countCompletes.GetCompletedActivities();

            string[] omissionIDs = new string[CompleteActivity.GetCount()];
            StreamReader inFile = new StreamReader("completed.txt");
            string line = inFile.ReadLine();

            if (line == null)
            {
                string[] noneCompleted = {"-1"};
                inFile.Close();
                return noneCompleted;
            }

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                omissionIDs[count] = tempArray[1];
                count++;

                line = inFile.ReadLine();
            }
            inFile.Close();
            return omissionIDs;
        }
        //Compares all activities to completed activities to see if any incompletes remaining
        static int CompareAllActivities(string [,] allActivities, string[] omissionIDs)
        {
            if (omissionIDs.Length != allActivities.Length)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        //Writes incomplete activities to the IncompleteReport file
        public void IncompletesToFile(IncompleteActivities[] incompleteActivities)
        {
            Prompts.IncompleteReportLocation();
            if (File.Exists("IncompleteReport.txt"))
            {
                StreamWriter outFile = new StreamWriter("IncompleteReport.txt");
                for (int i = 0; i < IncompleteActivities.GetCount(); i++)
                {
                    outFile.WriteLine($"{incompleteActivities[i].GetName()}");
                }
                outFile.Close();
                Prompts.ReportSuccessful();
            }
            else
            {
                Prompts.IncompleteReportFailed();
            }
        }
    }
}