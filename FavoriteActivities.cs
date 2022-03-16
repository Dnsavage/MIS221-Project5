namespace mis221_pa5_Dnsavage
{
    public class FavoriteActivities
    {
        private string completeID;
        private string name;
        private string rating;
        private static int count;
        //No args constructor for FavoriteActivities
        public FavoriteActivities()
        {
            
        }
        //Cosntructor for FavoriteActivities
        public FavoriteActivities(string completeID, string name, string rating)
        {
            this.completeID = completeID;
            this.name = name;
            this.rating = rating;
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
        //Sets the rating
        public void SetRating(string rating)
        {
            this.rating = rating;
        }
        //Returns the rating when called
        public string GetRating()
        {
            return rating;
        }
        //Returns the count
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            FavoriteActivities.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
    }
}