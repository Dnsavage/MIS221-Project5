namespace mis221_pa5_Dnsavage
{
    public class CompleteActivity
    {
        private string completeID;
        private string originID;
        private string name;
        private string dateComplete;
        private string moneySpent;
        private string rating;
        private string review;
        private string recommended;
        private string category;
        private static int count;
        //No args constructor for CompleteActivity
        public CompleteActivity()
        {
            
        }
        //Constructor for CompleteActivity
        public CompleteActivity(string completeID, string originID, string name, string dateComplete, 
        string moneySpent, string rating, string review, string recommended, string category)
        {
            this.completeID = completeID;
            this.originID = originID;
            this.name = name;
            this.dateComplete = dateComplete;
            this.moneySpent = moneySpent;
            this.rating = rating;
            this.review = review;
            this.recommended = recommended;
            this.category = category;
        }
        //Sets the Complete ID
        public void SetCompleteID(string completeID)
        {
            this.completeID = completeID;
        }
        //Returns the Complete ID when called
        public string GetCompleteID()
        {
            return completeID;
        }
        //Sets the Origin ID
        public void SetOriginID(string originID)
        {
            this.originID = originID;
        }
        //Returns the Origin ID when called
        public string GetOriginID()
        {
            return originID;
        }
        //Sets the Name
        public void SetName(string name)
        {
            this.name = name;
        }
        //Returns the Name when called
        public string GetName()
        {
            return name;
        }
        //Sets the Date the Activity was completed
        public void SetDateComplete(string dateComplete)
        {
            this.dateComplete = dateComplete;
        }
        //Returns the sate the Activity was completed when called
        public string GetDateComplete()
        {
            return dateComplete;
        }
        //Sets the amount of money spent
        public void SetMoneySpent(string moneySpent)
        {
            this.moneySpent = moneySpent;
        }
        //Returns the amount of money spent when called
        public string GetMoneySpent()
        {
            return moneySpent;
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
        //Sets the review
        public void SetReview(string review)
        {
            this.review = review;
        }
        //Returns the review when called
        public string GetReview()
        {
            return review;
        }
        //Sets the recommended status
        public void SetRecommended(string recommended)
        {
            this.recommended = recommended;
        }
        //Returns the recommended status when called
        public string GetRecommended()
        {
            return recommended;
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
        //Return the count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            CompleteActivity.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }
        //Concatenates all relevant completion fields
        public string GetConcatCompleted()
        {
            return (completeID + "#" + originID + "#" + name + "#" + dateComplete + "#" + moneySpent + "#" + rating + "#" + review + "#" + recommended + "#" + category);
        }
    }
}