using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class FavoriteActivitiesFile
    {
        private FavoriteActivities[] favoriteActivities;
        //No args constructor for FavoriteActivitiesFile
        public FavoriteActivitiesFile()
        {

        }
        //Constructor for FavoriteActivitiesFile
        public FavoriteActivitiesFile(FavoriteActivities[] favoriteActivities)
        {
            this.favoriteActivities = favoriteActivities;
        }
        //Pulls favorite activities from the completed file
        public int GetFavoriteCompletions()
        {
            FavoriteActivities.SetCount(0);

            StreamReader completedFile = new StreamReader("completed.txt");
            string completeLine = completedFile.ReadLine();
            if (completeLine == null)
            {
                Prompts.NoneCompleted();
                completedFile.Close();
                return -1;
            }

            while (completeLine != null)
            {
                string[] tempArray = completeLine.Split('#');
                string[] ratingArray = tempArray[5].Split(" ");
                if (int.Parse(ratingArray[0]) < 4)
                {
                    completeLine = completedFile.ReadLine();
                    continue;
                }
                else
                {
                    favoriteActivities[FavoriteActivities.GetCount()] = new FavoriteActivities(tempArray[0], tempArray[2],
                    tempArray[5]);
                    FavoriteActivities.IncCount();
                    completeLine = completedFile.ReadLine();
                }
            }
            completedFile.Close();
            return 1;
        }
        //Writes favorite activities to the FavActivities file
        public void FavoritesToFile(FavoriteActivities[] favoriteActivities)
        {
            Prompts.FavoritesReportLocation();
            if (File.Exists("FavActivities.txt"))
            {
                StreamWriter outFile = new StreamWriter("FavActivities.txt");
                for (int i = 0; i < FavoriteActivities.GetCount(); i++)
                {
                    outFile.Write($"{favoriteActivities[i].GetName()} | ");
                    outFile.WriteLine($"{favoriteActivities[i].GetRating()}");
                }
                outFile.Close();
                Prompts.ReportSuccessful();
            }
            else
            {
                Prompts.FavoritesReportFailed();
            }
        }
    }
}