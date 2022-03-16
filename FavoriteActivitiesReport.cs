using System;
namespace mis221_pa5_Dnsavage
{
    public class FavoriteActivitiesReport
    {
        private FavoriteActivities[] favoriteActivities;
        //No args constructor for FavoriteActivitiesReport
        public FavoriteActivitiesReport()
        {

        }
        //Constructor for FavoriteActivitiesReport
        public FavoriteActivitiesReport(FavoriteActivities[] favoriteActivities)
        {
            this.favoriteActivities = favoriteActivities;
        }
        //Displays all favorite activities
        public void DisplayFavorites()
        {
            Prompts.FavoritesMessage();
            Prompts.FavoritesFormatHeader();
            for (int i = 0; i < FavoriteActivities.GetCount(); i++)
            {
                Console.Write($"{favoriteActivities[i].GetName()} | ");
                Console.WriteLine($"{favoriteActivities[i].GetRating()}");
            }
            Prompts.EnterToContinueMessage();
        }
    }
}