namespace mis221_pa5_Dnsavage
{
    public class TripSummaryByDay
    {
        private string completeID;
        private string originID;
        private string name;
        private string dateComplete;
        private static int count;
        //No args constructor for TripSummaryByDay
        public TripSummaryByDay()
        {
            
        }
        //Constructor for TripSummaryByDay
        public TripSummaryByDay(string completeID, string originID, string name, string dateComplete)
        {
            this.completeID = completeID;
            this.originID = originID;
            this.name = name;
            this.dateComplete = dateComplete;
        }
        //Set the completed ID
        public void SetCompleteID(string completeID)
        {
            this.completeID = completeID;
        }
        //Return the complete ID when called
        public string GetCompleteID()
        {
            return completeID;
        }
        //Set the origin ID
        public void SetOriginID(string originID)
        {
            this.originID = originID;
        }
        //Return the origin ID when called
        public string GetOriginID()
        {
            return originID;
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
        //Set the date the activity was completed
        public void SetDateComplete(string dateComplete)
        {
            this.dateComplete = dateComplete;
        }
        //Return the date the activity was completed when called
        public string GetDateComplete()
        {
            return dateComplete;
        }
        //Return the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            TripSummaryByDay.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
        //Concatenates activity fields into a #-delimited, file-ready format
        public string GetConcatDayByDay()
        {
            return (completeID + "#" + originID + "#" + name + "#" + dateComplete);
        }
    }
}