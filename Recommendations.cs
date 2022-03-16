namespace mis221_pa5_Dnsavage
{
    public class Recommendations
    {
        private string completeID;
        private string name;
        private string category;
        private string spent;
        private static int count;
        //No args constructor for Recommendations
        public Recommendations()
        {
            
        }
        //Constructor for Recommendations
        public Recommendations(string completeID, string name, string category, string spent)
        {
            this.completeID = completeID;
            this.name = name;
            this.category = category;
            this.spent = spent;
        }
        //Sets the complete ID
        public void SetCompleteID(string completeID)
        {
            this.completeID = completeID;
        }
        //Returns the complete ID when called
        public string GetCompleteID()
        {
            return completeID;
        }
        //Sets the name
        public void SetName(string name)
        {
            this.name = name;
        }
        //Returns the name when called
        public string GetName()
        {
            return name;
        }
        //Sets the category
        public void SetCategory(string category)
        {
            this.category = category;
        }
        //Returns the category when called
        public string GetCategory()
        {
            return category;
        }
        //Sets the amount spent
        public void SetSpent(string spent)
        {
            this.spent = spent;
        }
        //Returns the amount spent when called
        public string GetSpent()
        {
            return spent;
        }
        //Returns the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            Recommendations.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
    }
}