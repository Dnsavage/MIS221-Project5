using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class CompleteActivityFile
    {
        private CompleteActivity[] completeActivities;
        //No args CompleteActivityFile constructor
        public CompleteActivityFile()
        {

        }
        //Constructor for CompleteActivityFile
        public CompleteActivityFile(CompleteActivity[] completeActivities)
        {
            this.completeActivities = completeActivities;
        }
        //Pulls all completed activities from the completed file
        public void GetCompletedActivities()
        {
            CompleteActivity.SetCount(0);

            StreamReader inFile = new StreamReader("completed.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                string amountSpent = tempArray[4].TrimStart('$');
                completeActivities[CompleteActivity.GetCount()] = new CompleteActivity(tempArray[0], tempArray[1], 
                tempArray[2], tempArray[3], amountSpent, tempArray[5], tempArray[6], tempArray[7], tempArray[8]);
                CompleteActivity.IncCount();

                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        //Assigns new info to completed fields when processing new completion
        public int GetNewProcessInformation()
        {
            CompleteActivity[] processedActivities = new CompleteActivity[50];
            processedActivities[CompleteActivity.GetCount()] = new CompleteActivity();

            processedActivities[CompleteActivity.GetCount()].SetCompleteID(GenCompleteID());

            Prompts.PromptForActIDComplete();
            CompleteActivityMenu completeMenu = new CompleteActivityMenu();
            string completeID = completeMenu.GetValidID();
            if (completeID == "-1")
            {
                return -1;
            }

            processedActivities[CompleteActivity.GetCount()].SetName(GetCompleteName(completeID));

            processedActivities[CompleteActivity.GetCount()].SetOriginID(completeID);

            Prompts.PromptDateCompleted();
            string processInput = Console.ReadLine();
            CompleteActivityUtil newProcess = new CompleteActivityUtil();
            processInput = newProcess.ResolveDateErrors(processInput);
            processedActivities[CompleteActivity.GetCount()].SetDateComplete(processInput);

            Prompts.PromptExpenditures();
            processInput = Console.ReadLine();
            processedActivities[CompleteActivity.GetCount()].SetMoneySpent("$" + newProcess.GetValidSpent(processInput));

            CompleteActivityMenu processedRating = new CompleteActivityMenu();
            processedActivities[CompleteActivity.GetCount()].SetRating(processedRating.ProcessRatingMenu());

            Prompts.PromptReview();
            processInput = Console.ReadLine();
            processedActivities[CompleteActivity.GetCount()].SetReview(newProcess.GetValidReview(processInput));

            CompleteActivityMenu processedRecommend = new CompleteActivityMenu();
            processedActivities[CompleteActivity.GetCount()].SetRecommended(processedRating.ProcessRecommendMenu());
            
            processedActivities[CompleteActivity.GetCount()].SetCategory(GetCompleteCategory(completeID));
            
            NewActivityToCompletion(processedActivities);
            CompleteActivity.IncCount();
            return 1;
        }
        //Returns the line to edit
        public int GetUserLineToEdit(string completeEditID, CompleteActivity[] editComplete)
        {
            string verifiedID = VerifyEditID(completeEditID);
            int lineToEdit = CompareID(verifiedID, editComplete);
            lineToEdit = (CheckLineValidity(verifiedID, lineToEdit, completeActivities));
            return lineToEdit;
        }
        //Null error handling for the entered ID
        public string VerifyEditID(string completeEditID)
        {
            int userID = 0;
            bool goodInput = (int.TryParse(completeEditID, out userID));
            while (goodInput != true)
            {
                Console.Clear();
                Prompts.PromptValidIDNoExit();
                completeEditID = Console.ReadLine();
                goodInput = (int.TryParse(completeEditID, out userID));
            }
            return completeEditID;
        }
        //Compares entered ID with existing IDs to search for a match
        static int CompareID(string verifiedID, CompleteActivity[] editComplete)
        {
            if (int.Parse(verifiedID) == -1)
            {
                return -1;
            }
            for (int i = 0; i < CompleteActivity.GetCount(); i++)
            {
                if (verifiedID == editComplete[i].GetCompleteID())
                {
                    return i;
                }
            }
            return -2;
        }
        //Ensures that the number entered translates to a valid line/unexpected error handling
        public static int CheckLineValidity(string verifiedID, int lineToEdit, CompleteActivity[] editComplete)
        {
            CompleteActivityReport reList = new CompleteActivityReport(editComplete);
            bool goodInput = true;
            int newID = 0;
            while ((lineToEdit < 0 && lineToEdit != -1) || goodInput != true)
            {
                Console.Clear();
                reList.DisplayAllActivities(editComplete);
                Prompts.PromptValidIDNoExit();
                string completeEditID = Console.ReadLine();
                goodInput = int.TryParse(completeEditID, out newID);
                lineToEdit = CompareID(completeEditID, editComplete);
            }
            return lineToEdit;
        }
        //Returns the name of a completed activity corresponding with a a specific ID
        public string GetCompleteName(string completeID)
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();
            
            while (line != null)
            {
                string[] tempArray = line.Split('#');
                if (completeID == tempArray[0])
                {
                    inFile.Close();
                    return(tempArray[1]);
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
            return "NAME_NOT_FOUND";
        }
        //Generates a unique ID for completed activities
        public string GenCompleteID()
        {
            StreamReader inFile = new StreamReader("completed.txt");
            string line = inFile.ReadLine();

            if (line == null)
            {
                inFile.Close();
                return "1";
            }

            string[] checkCompleteIDs = new string[CompleteActivity.GetCount() + 1];
            int index = 0;

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                checkCompleteIDs[index] = tempArray[0];
                index++;

                line = inFile.ReadLine();
            }
            inFile.Close();

            int maxID = 0;
            for (int i = 0; i < CompleteActivity.GetCount(); i++)
            {
                if (int.Parse(checkCompleteIDs[i]) > maxID)
                {
                    maxID = int.Parse(checkCompleteIDs[i]);
                }
            }
            return (maxID+1).ToString();
        }
        //Returns the category for a specfic completion ID
        static string GetCompleteCategory(string completeID)
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                if (tempArray[0] == completeID)
                {
                    inFile.Close();//INSERT IN DESIGN DOC
                    return tempArray[2];
                }
                line = inFile.ReadLine();
            }
            inFile.Close();
            return "CAT_NOT_FOUND";
        }
        //Adds a new completion to the completion file
        public static void NewActivityToCompletion(CompleteActivity[] processedActivities)
        {
            StreamWriter outFile = new StreamWriter("completed.txt", true);
            outFile.WriteLine(processedActivities[CompleteActivity.GetCount()].GetConcatCompleted());
            outFile.Close();

        }
        //Implements edits to a current completion in the completion file
        public static void EditCompletionToFile(CompleteActivity[] editComplete)
        {
            StreamWriter outFile = new StreamWriter("completed.txt");
            for (int i = 0; i < CompleteActivity.GetCount(); i++)
            {
                outFile.WriteLine(editComplete[i].GetConcatCompleted());
            }
            outFile.Close();

        }
        //Removes a completion from the completion file
        public static void DeleteCompletionFromFile(int lineToEdit, CompleteActivity[] deleteComplete)
        {
            StreamWriter outFile = new StreamWriter("completed.txt");
            for (int i = 0; i < CompleteActivity.GetCount(); i++)
            {
                
                if(i == lineToEdit)
                {
                    continue;
                }
                else
                {
                    outFile.WriteLine(deleteComplete[i].GetConcatCompleted());
                }
            }
            outFile.Close();
        }
        //Removes a completion from the completion file when the corresponding activity is deleted
        public static void DeleteCompletionWithActivity(string originID, CompleteActivity[] deleteComplete)
        {
            StreamWriter outFile = new StreamWriter("completed.txt");
            for (int i = 0; i < CompleteActivity.GetCount(); i++)
            {
                if(deleteComplete[i].GetOriginID() == originID)
                {
                    continue;
                }
                else
                {
                    outFile.WriteLine(deleteComplete[i].GetConcatCompleted());
                }
            }
            outFile.Close();
        }
        //Removes all completions from the completion file
        public static void DeleteAllCompletionsFromFile()
        {
            StreamWriter outFile = new StreamWriter("completed.txt");
            outFile.Write(string.Empty);
            outFile.Close();
        }
    }
}