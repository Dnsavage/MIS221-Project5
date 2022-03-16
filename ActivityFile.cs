using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class ActivityFile
    {
        private Activity[] activities;
        //No-argument constructor for class
        public ActivityFile()
        {

        }
        //Constructor for class
        public ActivityFile(Activity[] activities)
        {
            this.activities = activities;
        }
        //Indexes the "list" file and retrieves all previously entered activities
        public void GetAllActivities()
        {
            Activity.SetCount(0);

            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                string minPrice = tempArray[3].TrimStart('$');
                string maxPrice = tempArray[4].TrimStart('$');
                activities[Activity.GetCount()] = new Activity(tempArray[0], tempArray[1], tempArray[2], minPrice, 
                maxPrice, tempArray[5], tempArray[6]);
                Activity.IncCount();

                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        //Generates a unique ID based on existing IDs
        public string GenActivityID()
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();

            if (line == null)
            {
                inFile.Close();
                return "1";
            }
            
            string[] checkActivityIDs = new string[Activity.GetCount()];
            int index = 0;

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                checkActivityIDs[index] = tempArray[0];
                index++;

                line = inFile.ReadLine();
            }
            inFile.Close();
            int maxID = 0;
            for (int i = 0; i < Activity.GetCount(); i++)
            {
                if (int.Parse(checkActivityIDs[i]) > maxID)
                {
                    maxID = int.Parse(checkActivityIDs[i]);
                }
            }
            return (maxID+1).ToString();
        }
        //Gets the user's selected vacation as a line from the file
        public int GetUserLineToEdit(string actEditID, Activity[] activities)
        {
            string verifiedID = VerifyEditID(actEditID);
            int lineToEdit = CompareID(verifiedID, activities);
            lineToEdit = (CheckLineValidity(verifiedID, lineToEdit, activities));
            return lineToEdit;
        }
        //Error handling for null/unexpected ID values
        public string VerifyEditID(string actEditID)
        {
            int userID = 0;
            bool goodInput = (int.TryParse(actEditID, out userID));
            while (goodInput != true)
            {
                Console.Clear();
                Prompts.PromptValidIDNoExit();
                actEditID = Console.ReadLine();
                goodInput = (int.TryParse(actEditID, out userID));
            }
            return actEditID;
        }
        //Compare user-entered ID with IDs on file (Contains Binary Search)
        static int CompareID(string verifiedID, Activity[] activities)
        {
            int newID = 0;
            bool goodInput = int.TryParse(verifiedID, out newID);
            if (!goodInput)
            {
                return -2;
            }

            if (int.Parse(verifiedID) == -1)
            {
                return -1;
            }
            
            //Binary Search
            int first = 0;
            int last = Activity.GetCount()-1;
            int foundIndex = -2;
            bool found = false;
            int middle;
            const int BINARY_DIVISOR = 2;

            while (!found && (first <= last))
            {
                middle = (first+last)/BINARY_DIVISOR;
                if (activities[middle].GetActID() == verifiedID)
                {
                    found = true;
                    foundIndex = middle;
                }
                else if (activities[middle].GetActID().CompareTo(verifiedID) > 0)
                {
                    last = middle-1;
                }
                else
                {
                    first = middle+1;
                }
            }
            return foundIndex;
        }

        //Checks validity of returned line and throws error if invalid
        public static int CheckLineValidity(string verifiedID, int lineToEdit, Activity[] activities)
        {
            ActivityReport reList = new ActivityReport(activities);
            bool goodInput = true;
            int newID = 0;
            while ((lineToEdit < 0 && lineToEdit != -1) || goodInput != true)
            {
                Console.Clear();
                reList.DisplayAllActivities(activities);
                Prompts.PromptValidIDNoExit();
                string activityEditID = Console.ReadLine();
                goodInput = int.TryParse(activityEditID, out newID);
                lineToEdit = CompareID(activityEditID, activities);
            }
            return lineToEdit;
        }

        
        //Appends the file with new activities
        public static void NewActivityToFile(Activity[] activities)
        {
            StreamWriter outFile = new StreamWriter("list.txt", true);
            outFile.WriteLine(activities[Activity.GetCount()].GetConcatActivity());
            outFile.Close();

        }
        //Replaces old line with updated line
        public static void EditActivityToFile(Activity[] activities)
        {
            StreamWriter outFile = new StreamWriter("list.txt");
            for (int i = 0; i < Activity.GetCount(); i++)
            {
                outFile.WriteLine(activities[i].GetConcatActivity());
            }
            outFile.Close();

        }
        //Deletes the selected line from the file
        public static void DeleteActivityFromFile(int lineToEdit, Activity[] activities)
        {
            StreamWriter outFile = new StreamWriter("list.txt");
            for (int i = 0; i < Activity.GetCount(); i++)
            {
                
                if(i == lineToEdit)
                {
                    continue;
                }
                else
                {
                    outFile.WriteLine(activities[i].GetConcatActivity());
                }
            }
            outFile.Close();
        }
        //Clears all activities from the activities file
        public static void DeleteAllActivitiesFromFile()
        {
            StreamWriter outFile = new StreamWriter("list.txt");
            outFile.Write(string.Empty);
            outFile.Close();
        }
    }
}