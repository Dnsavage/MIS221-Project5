namespace mis221_pa5_Dnsavage
{
    public class IncompleteActivities
    {
        private string activityID;
        private string name;
        private static int count;
        //No args constructor for IncompleteActivities
        public IncompleteActivities()
        {
            
        }
        //Constructor for IncompleteActivities
        public IncompleteActivities(string activityID, string name)
        {
            this.activityID = activityID;
            this.name = name;
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
        //Returns the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            IncompleteActivities.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
    }
}