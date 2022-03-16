using System;
namespace mis221_pa5_Dnsavage
{
    public class Vacation
    {
        private string vacationID;
        private string destination;
        private string startDate;
        private string endDate;
        private string budget;
        public static int count;
        //No args constructor for Vacation
        public Vacation()
        {
            
        }
        //Constructor for the Vacation class
        public Vacation(string vacationID, string destination, string startDate, string endDate, string budget)
        {
            this.vacationID = vacationID;
            this.destination = destination;
            this.startDate = startDate;
            this.endDate = endDate;
            this.budget = budget;
        }
        //Sets the ID to the current instance of ID
        public void SetID(string vacationID)
        {
            this.vacationID = vacationID;
        }
        //Retrieves ID
        public string GetID()
        {
            return vacationID;
        }
        //Sets the Destination to the current instance of Destination
        public void SetDestination(string destination)
        {
            this.destination = destination;
        }
        //Retrieves Destination
        public string GetDestination()
        {
            return destination;
        }
        //Sets the Start Date to the current instance of Start Date
        public void SetStartDate(string startDate)
        {
            this.startDate = startDate;
        }
        //Retrieves Start Date
        public string GetStartDate()
        {
            return startDate;
        }
        //Sets the End Date to the current instance of End Date
        public void SetEndDate(string endDate)
        {
            this.endDate = endDate;
        }
        //Retrieves End Date
        public string GetEndDate()
        {
            return endDate;
        }
        //Sets the Budget to the current instance of Budget
        public void SetBudget(string budget)
        {
            this.budget = budget;
        }
        //Retrieves Budget
        public string GetBudget()
        {
            return budget;
        }
        //Retrieves Count
        public static int GetCount()
        {
            return count;
        }
        //Sets the count equal to the count of Vacation
        public static void SetCount(int count)
        {
            Vacation.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
        //Concatenates vacation fields into a #-delimited, file-ready format
        public string GetConcatVacation()
        {
            return (vacationID + "#" + destination + "#" + startDate + "#" + endDate + "#" + budget);
        }
        
    }
}