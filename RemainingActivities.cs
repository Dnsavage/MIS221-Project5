namespace mis221_pa5_Dnsavage
{
    public class RemainingActivities
    {
        private string activityID;
        private string name;
        private string category;
        private string priceMin;
        private string priceMax;
        private string timeNeeded;
        private string ticketNeeded;
        private static int count;
        //No args constructor for RemainingActivities
        public RemainingActivities()
        {
            
        }
        //Constructor for RemainingActivities
        public RemainingActivities(string activityID, string name, string category, string priceMin, string priceMax, 
        string timeNeeded, string ticketNeeded)
        {
            this.activityID = activityID;
            this.name = name;
            this.category = category;
            this.priceMin = priceMin;
            this.priceMax = priceMax;
            this.timeNeeded = timeNeeded;
            this.ticketNeeded = ticketNeeded;
        }
        //Sets the activity ID
        public void SetActID(string activityID)
        {
            this.activityID = activityID;
        }
        //Returns the activity ID when called
        public string GetActID()
        {
            return activityID;
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
        // Sets the minimum price
        public void SetPriceMin(string priceMin)
        {
            this.priceMin = priceMin;
        }
        //Returns the minimum price when called
        public string GetPriceMin()
        {
            return priceMin;
        }
        //Sets the maximum price
        public void SetPriceMax(string priceMax)
        {
            this.priceMax = priceMax;
        }
        //Returns the maximum price when called
        public string GetPriceMax()
        {
            return priceMax;
        }
        //Sets the time needed
        public void SetTimeNeeded(string timeNeeded)
        {
            this.timeNeeded = timeNeeded;
        }
        //Returns the time needed when called
        public string GetTimeNeeded()
        {
            return timeNeeded;
        }
        //Sets the necessity for tickets
        public void SetTicketNeeded(string ticketNeeded)
        {
            this.ticketNeeded = ticketNeeded;
        }
        //Returns the necessity for tickets when called
        public string GetTicketNeeded()
        {
            return ticketNeeded;
        }
        //Returns the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            RemainingActivities.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
        //Concatenates remaining activity fields into a #-delimited, file-ready format
        public string GetConcatRemainActivity()
        {
            return (activityID + "#" + name + "#" + category + "#" + priceMin + "#" + priceMax + "#" + timeNeeded + "#" + ticketNeeded);
        }
        //Compares current category with another category to see which comes before the other
        public int CatCompareTo(RemainingActivities remainActivities)
        {
            return this.category.CompareTo(remainActivities.GetCategory());
        }
        //Compares current ticket necessity with another ticket necessity to see which comes before the other
        public int TicketCompareTo(RemainingActivities remainActivities)
        {
            return this.ticketNeeded.CompareTo(remainActivities.GetTicketNeeded());
        }
    }
}