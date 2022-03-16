namespace mis221_pa5_Dnsavage
{
    public class FavoriteActivitiesUtil
    {
        private FavoriteActivities[] favoriteActivities;
        //No args constructor for FavoriteActivitiesUtil
        public FavoriteActivitiesUtil()
        {

        }
        //Constructor for FavoriteActivitiesUtil
        public FavoriteActivitiesUtil(FavoriteActivities[] favoriteActivities)
        {
            this.favoriteActivities = favoriteActivities;
        }
        //Sorts favorite activities by ratings, high to low
        public void SortByRating()
        {
            for (int i = 0; i < FavoriteActivities.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < FavoriteActivities.GetCount(); j++)
                {
                    string[] maxRatingArray = favoriteActivities[max].GetRating().Split(" ");
                    string[] nextRatingArray = favoriteActivities[j].GetRating().Split(" ");
                    //Years
                    if (int.Parse(nextRatingArray[0]) > int.Parse(maxRatingArray[0]))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    Swap(max, i);
                }
            }
        }
        //Swaps the order of favorite activities
        public void Swap(int x, int y)
        {
            FavoriteActivities temp = favoriteActivities[x];
            favoriteActivities[x] = favoriteActivities[y];
            favoriteActivities[y] =  temp;
        }
    }
}