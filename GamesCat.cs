namespace mis221_pa5_Dnsavage
{
    public class GamesCat
    {
        private string name;
        private string spent;
        private string rating;
        private static string totSpentCat;
        private static int count;
        //no args constructor for GamesCat
        public GamesCat()
        {

        }
        //Constructor for GamesCat
        public GamesCat(string name, string spent, string rating)
        {
            this.name = name;
            this.spent = spent;
            this.rating = rating;
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
        //Sets the amount spent
        public void SetSpent(string spent)
        {
            this.spent = spent;
        }
        //Returns the amount spent
        public string GetSpent()
        {
            return spent;
        }
        //Sets the rating
        public void SetRating(string rating)
        {
            this.rating = rating;
        }
        //Returns the rating whehn called
        public string GetRating()
        {
            return rating;
        }
        //Sets the total amount spent for this category
        public static void SetTotSpentCat(string totSpentCat)
        {
            GamesCat.totSpentCat = totSpentCat;
        }
        //Returns the total amount spent for this category when called
        public static string GetTotSpentCat()
        {
            return totSpentCat;
        }
        //Returns the count
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            GamesCat.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
    }
}