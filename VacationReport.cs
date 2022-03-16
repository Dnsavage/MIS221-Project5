using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class VacationReport
    {
        private Vacation[] vacations;
        //No args constructor for VacationReport
        public VacationReport()
        {

        }
        //Constructor for Vacation Report
        public VacationReport(Vacation[] vacations)
        {
            this.vacations = vacations;
        }
        //Displays all Vacations currently in the Vacations file
        public void DisplayAllVacations(Vacation[] vacations)
        {
            Prompts.VacationMessage();
            Prompts.VacationFormatHeader();
            for (int i = 0; i < Vacation.GetCount(); i++)
            {
                Console.Write($"{vacations[i].GetID()} | ");
                Console.Write($"{vacations[i].GetDestination()} | ");
                Console.Write($"{vacations[i].GetStartDate()} | ");
                Console.Write($"{vacations[i].GetEndDate()} | ");
                Console.WriteLine($"${vacations[i].GetBudget()}");
            }
        }
        //Displays a single Vacation based on user ID selection
        public void DisplayOneVacation(int lineToEdit)
        {
            Prompts.VacationFormatHeader();
            Console.Write($"{vacations[lineToEdit].GetID()} | ");
            Console.Write($"{vacations[lineToEdit].GetDestination()} | ");
            Console.Write($"{vacations[lineToEdit].GetStartDate()} | ");
            Console.Write($"{vacations[lineToEdit].GetEndDate()} | ");
            Console.WriteLine($"${vacations[lineToEdit].GetBudget()}");
        }
        //Checks if any Vacations exist
        public int CheckIfAnyVacations(Vacation[] vacations)
        {
            if (Vacation.GetCount() < 1)
            {
                Prompts.PromptNoVacations();
                return -1;
            }
            else
            {
                DisplayAllVacations(vacations);
                return 1;
            }
        }
    }
}