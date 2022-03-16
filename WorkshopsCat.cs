namespace mis221_pa5_Dnsavage
{
    public class WorkshopsCat
    {
        private string name;
        private string spent;
        private string rating;
        private static string totSpentCat;
        private static int count;
        //No args constructor for WorkshopsCat
        public WorkshopsCat()
        {

        }
        //Constructor for WorkshopsCat
        public WorkshopsCat(string name, string spent, string rating)
        {
            this.name = name;
            this.spent = spent;
            this.rating = rating;
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
        //Set amount spent
        public void SetSpent(string spent)
        {
            this.spent = spent;
        }
        //Return the amount spent when called
        public string GetSpent()
        {
            return spent;
        }
        //Set the rating
        public void SetRating(string rating)
        {
            this.rating = rating;
        }
        //Return the rating when called
        public string GetRating()
        {
            return rating;
        }
        //Set the total amount spent for this category
        public static void SetTotSpentCat(string totSpentCat)
        {
            WorkshopsCat.totSpentCat = totSpentCat;
        }
        //Return the total amount spent for this category when called
        public static string GetTotSpentCat()
        {
            return totSpentCat;
        }
        //Return the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            WorkshopsCat.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
    }
}