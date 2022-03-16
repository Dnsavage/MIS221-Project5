using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class VacationFile
    {
        private Vacation[] vacations;
        //No args constructor for VacationFile
        public VacationFile()
        {

        }
        //Constructor for VacationFile
        public VacationFile(Vacation[] vacations)
        {
            this.vacations = vacations;
        }
        //Pulls all vacations from the vacation file
        public void GetAllVacations()
        {
            Vacation.SetCount(0);

            StreamReader inFile = new StreamReader("vacation.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                //string intOnly = tempArray[4].TrimStart('$');
                vacations[Vacation.GetCount()] = new Vacation(tempArray[0], tempArray[1], tempArray[2], tempArray[3], 
                (tempArray[4]));
                Vacation.IncCount();

                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        //Assigns new info when creating a new vacation
        public void GetNewVacationInfo(Vacation[] vacations)
        {
            VacationUtil newVacationTool = new VacationUtil();
            Console.Clear();
            vacations[Vacation.GetCount()] = new Vacation();

            vacations[Vacation.GetCount()].SetID(GenNewID());

            Prompts.PromptNewDestination();
            vacations[Vacation.GetCount()].SetDestination(newVacationTool.GetValidDestination(Console.ReadLine()));

            Prompts.PromptNewStartDate();
            int dateType = -1;
            vacations[Vacation.GetCount()].SetStartDate(newVacationTool.GetValidDate(dateType, vacations));

            Prompts.PromptNewEndDate();
            dateType = 1;
            vacations[Vacation.GetCount()].SetEndDate(newVacationTool.GetValidDate(dateType, vacations));

            Prompts.PromptNewBudget();
            vacations[Vacation.GetCount()].SetBudget(newVacationTool.GetValidBudget(Console.ReadLine()));

            NewVacationToFile(vacations);
            Vacation.IncCount();
            Prompts.NewVacationSuccess();
        }
        //Generates a unique ID for vacations
        public string GenNewID()
        {
            StreamReader inFile = new StreamReader("vacation.txt");
            string line = inFile.ReadLine();

            if (line == null)
            {
                inFile.Close();
                return "1";
            }

            string[] checkVacationIDs = new string[Vacation.GetCount() + 1];
            int index = 0;

            while (line != null)
            {
                string[] tempArray = line.Split('#');
                checkVacationIDs[index] = tempArray[0];//Populate array with each completeID
                index++;

                line = inFile.ReadLine();
            }
            inFile.Close();

            int maxID = 0;
            for (int i = 0; i < Vacation.GetCount(); i++)
            {
                if (int.Parse(checkVacationIDs[i]) > maxID)
                {
                    maxID = int.Parse(checkVacationIDs[i]);
                }
            }
            return (maxID+1).ToString();
        }
        //Checks entered ID against all IDs on record
        public static int CheckID(int trueInt)
        {
            int count = 0;
            bool goodID = false;

            while (goodID != true && trueInt != -1)
            {
                StreamReader inFile = new StreamReader("vacation.txt");
                string line = inFile.ReadLine();
                count = 0;
                while (line != null)
                {
                    string[] tempArray = line.Split('#');
                    
                    if (trueInt != int.Parse(tempArray[0]))
                    {
                        count++;
                        line = inFile.ReadLine();
                        continue;
                    }
                    else
                    {
                        goodID = true;
                        break;
                    }
                }
                if (line == null)//Reached end of file and no matches
                {
                    do
                    {
                        Prompts.PromptValidOrAbort();
                    }
                    while ((!(int.TryParse(Console.ReadLine(), out trueInt))) && trueInt != -1);
                }
                inFile.Close();
            }
            if (trueInt != -1)
            {
                return count;
            }
            else
            {
                return trueInt;
            }
        }
        //Gets the user's selected vacation as a line from the file
        public int GetUserLineToEdit(string vacEditID)
        {
            int trueInt = 0;
            string verifiedInt = VerifyEditInt(vacEditID);
            if (verifiedInt.ToLower() == "stop")
            {
                return -1;
            }
            else
            {
                trueInt = int.Parse(verifiedInt);
            }
            int lineToEdit = CheckID(trueInt);
            return lineToEdit;
        }
        //Ensure entered value is not an exit keyword or null
        public string VerifyEditInt(string vacEditID)
        {
            int userID = 0;
            bool goodInput = (int.TryParse(vacEditID, out userID));
            while (goodInput != true && vacEditID.ToLower() != "stop")
            {
                Prompts.PromptValidEditID();
                vacEditID = Console.ReadLine();
                goodInput = (int.TryParse(vacEditID, out userID));
            }
            return vacEditID;
        }
        //Appends the file with new vacations
        public static void NewVacationToFile(Vacation[] vacations)
        {
            StreamWriter outFile = new StreamWriter("vacation.txt", true);
            outFile.WriteLine(vacations[Vacation.GetCount()].GetConcatVacation());
            outFile.Close();

        }
        //Replaces old line with updated line
        public static void EditVacationToFile(Vacation[] vacations)
        {
            StreamWriter outFile = new StreamWriter("vacation.txt");
            for (int i = 0; i < Vacation.GetCount(); i++)
            {
                outFile.WriteLine(vacations[i].GetConcatVacation());
            }
            outFile.Close();

        }
        //Deletes the selected line from the file
        public static void DeleteVacationFromFile(int lineToEdit, Vacation[] vacations)
        {
            StreamWriter outFile = new StreamWriter("vacation.txt");
            for (int i = 0; i < Vacation.GetCount(); i++)
            {
                
                if(i == lineToEdit)
                {
                    continue;
                }
                else
                {
                    outFile.WriteLine(vacations[i].GetConcatVacation());
                }
            }
            outFile.Close();
        }
    }
}