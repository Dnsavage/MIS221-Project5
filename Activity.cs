namespace mis221_pa5_Dnsavage
{
    public class Activity
    {
        private string activityID;
        private string name;
        private string category;
        private string priceMin;
        private string priceMax;
        private string timeNeeded;
        private string ticketNeeded;
        private static int count;
        //No-Arguments Constructor for class
        public Activity()
        {
            
        }
        //Constructor for class
        public Activity(string activityID, string name, string category, string priceMin, string priceMax, 
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
        //Set the Activity ID
        public void SetActID(string activityID)
        {
            this.activityID = activityID;
        }
        //Returns the Activity ID when called
        public string GetActID()
        {
            return activityID;
        }
        //Sets the Activity Name
        public void SetName(string name)
        {
            this.name = name;
        }
        //Returns the Activity name when called
        public string GetName()
        {
            return name;
        }
        //Sets the Activity category
        public void SetCategory(string category)
        {
            this.category = category;
        }
        //Returns the Activity category when called
        public string GetCategory()
        {
            return category;
        }
        //Sets the Minimum Activity Price
        public void SetPriceMin(string priceMin)
        {
            this.priceMin = priceMin;
        }
        //Returns the Minimum Activity Price when called
        public string GetPriceMin()
        {
            return priceMin;
        }
        //Sets the Maximum Activity Price
        public void SetPriceMax(string priceMax)
        {
            this.priceMax = priceMax;
        }
        //Returns the Maximum Activity Price when called
        public string GetPriceMax()
        {
            return priceMax;
        }
        //Sets the Time Needed for the Activity
        public void SetTimeNeeded(string timeNeeded)
        {
            this.timeNeeded = timeNeeded;
        }
        //Returns the Time Needed for the Activity when called
        public string GetTimeNeeded()
        {
            return timeNeeded;
        }
        //Sets the necessity for tickets for the activity
        public void SetTicketNeeded(string ticketNeeded)
        {
            this.ticketNeeded = ticketNeeded;
        }
        //Returns the necessity for tickets for the activity when called
        public string GetTicketNeeded()
        {
            return ticketNeeded;
        }
        //Retrieves Count
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            Activity.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
        //Concatenates activity fields into a #-delimited, file-ready format
        public string GetConcatActivity()//This belongs in ActivityFile
        {
            return (activityID + "#" + name + "#" + category + "#" + "$" + priceMin + "#" + "$" + priceMax + "#" + timeNeeded + "#" + ticketNeeded);
        }

        
    }
}