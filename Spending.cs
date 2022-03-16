namespace mis221_pa5_Dnsavage
{
    public class Spending
    {
        private string completeID;
        private string category;
        private string name;
        private string moneySpent;
        private static string totalSpent;
        private static int count;
        //No args constructor for Spending
        public Spending()
        {
            
        }
        //Constructor for Spending
        public Spending(string completeID, string category, string name, string moneySpent)
        {
            this.completeID = completeID;
            this.category = category;
            this.name = name;
            this.moneySpent = moneySpent;
        }
        //Set the complete ID
        public void SetCompleteID(string completeID)
        {
            this.completeID = completeID;
        }
        //Return the complete ID when called
        public string GetCompleteID()
        {
            return completeID;
        }
        //Set the category
        public void SetCategory(string category)
        {
            this.category = category;
        }
        //Return the category when called
        public string GetCategory()
        {
            return category;
        }
        //Set the name
        public void SetName(string name)
        {
            this.name = name;
        }
        //Return the name when called
        public string GetName()
        {
            return name;
        }
        //Set the amount spent
        public void SetMoneySpent(string moneySpent)
        {
            this.moneySpent = moneySpent;
        }
        //Returnt the amount spent when called
        public string GetMoneySpent()
        {
            return moneySpent;
        }
        //Return the total amount spent for this category when called
        public static string GetTotalSpent()
        {
            return totalSpent;
        }
        //Set the total amount spent for this category
        public static void SetTotalSpent(string totalSpent)
        {
            Spending.totalSpent = totalSpent;
        }
        //Return the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            Spending.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
        //Compares the current category to the next category to see which comes before the other
        public int CatCompareTo(Spending expenditures)
        {
            return this.category.CompareTo(expenditures.GetCategory());
        }
    }
}