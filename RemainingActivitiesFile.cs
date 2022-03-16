using System;//Temp
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class RemainingActivitiesFile
    {
        private RemainingActivities[] remainActivities;
        //No args constructor for RemainingActivitiesFile
        public RemainingActivitiesFile()
        {

        }
        //Constructor for RemainingActivitiesFile
        public RemainingActivitiesFile(RemainingActivities[] remainActivities)
        {
            this.remainActivities = remainActivities;
        }
        //Checks if any activities exist
        public int CheckIfAnyActivities(RemainingActivities[] remainActivities)
        {
            if (Activity.GetCount() < 1)
            {
                Prompts.PromptNoActivities();
                Prompts.MainMenuPrompt();
                return -1;
            }
            else
            {
                return 1;
            }
        }
        //Gets remaining activities by comparing completed IDs and all activity IDs
        public int GetRemainingActivities()
        {
            string[,] allActivities = GetAllActivities();
            string[] omissionIDs = GetOmissionIDs();
            string[] clearOmitIDs = new string [Activity.GetCount()];
            RemainingActivities.SetCount(0);

            if (omissionIDs[0] == "-1")
                {
                    for (int i = 0; i < Activity.GetCount(); i++)
                    {
                        //elements 3 and 4 need to be stripped of "$" before adding to array
                        string minPrice = allActivities[i, 3].TrimStart('$');
                        string maxPrice = allActivities[i, 4].TrimStart('$');
                        remainActivities[RemainingActivities.GetCount()] = new RemainingActivities(
                            allActivities[i, 0], allActivities[i, 1], allActivities[i, 2], minPrice, 
                            maxPrice, allActivities[i, 5], allActivities[i, 6]
                        );
                        RemainingActivities.IncCount();
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
                        remainActivities[RemainingActivities.GetCount()] = new RemainingActivities(
                            allActivities[i, 0], allActivities[i, 1], allActivities[i, 2], allActivities[i, 3], 
                            allActivities[i, 4], allActivities[i, 5], allActivities[i, 6]
                        );
                        RemainingActivities.IncCount();
                        clearOmitIDs[i] = allActivities[i, 0];
                    }
                }
            }
            return 1;
        }
        //Pulls all current activities from the activities file and stores them in a 2D array for comparison
        public string[,] GetAllActivities()
        {
            int count = 0;
            string[,] allActivities = new string[Activity.GetCount(), 7];
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();

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
        //Gets completed IDs to determine which activities to omit from the remaining computation
        public string[] GetOmissionIDs()
        {
            int count = 0;
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
        //Compares omitted IDs to all activity IDs
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
    }
}