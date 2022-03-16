using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class RecommendationsFile
    {
        private EventsCat[] events;
        private FoodDrinkCat[] foodDrinks;
        private GamesCat[] games;
        private MuseumsCat[] museums;
        private NatureCat[] natures;
        private NightLifeCat[] nightLives;
        private ShoppingCat[] shoppings;
        private ToursCat[] tours;
        private WorkshopsCat[] workshops;
        //No args constructor for RecommendationsFile
        public RecommendationsFile()
        {

        }
        //Constructor for RecommendationsFile
        public RecommendationsFile(EventsCat[] events, FoodDrinkCat[] foodDrinks, 
        GamesCat[] games, MuseumsCat[] museums, NatureCat[] natures, NightLifeCat[] nightLives, 
        ShoppingCat[] shoppings, ToursCat[] tours, WorkshopsCat[] workshops)
        {
            this.events = events;
            this.foodDrinks = foodDrinks;
            this.games = games;
            this.museums = museums;
            this.natures = natures;
            this.nightLives = nightLives;
            this.shoppings = shoppings;
            this.tours = tours;
            this.workshops = workshops;
        }
        //Pulls all recommendations from file and assign them to their respective categories
        public int GetRecommendations() 
        {
            Recommendations.SetCount(0);
            EventsCat.SetCount(0);
            FoodDrinkCat.SetCount(0);
            GamesCat.SetCount(0);
            MuseumsCat.SetCount(0);
            NatureCat.SetCount(0);
            NightLifeCat.SetCount(0);
            ShoppingCat.SetCount(0);
            ToursCat.SetCount(0);
            WorkshopsCat.SetCount(0);

            StreamReader completedFile = new StreamReader("completed.txt");
            string completeLine = completedFile.ReadLine();
            if (completeLine == null)
            {
                Prompts.NoneCompleted();
                completedFile.Close();
                return -1;
            }

            if (completeLine == null && Recommendations.GetCount() < 1)
            {
                Prompts.NoneRecommended();
                completedFile.Close();
                return -1;
            }

            while (completeLine != null)
            {
                string[] tempArray = completeLine.Split('#');
                if (tempArray[7] == "No" || tempArray[7] == "Non" || tempArray[7] == "Nein")
                {
                    completeLine = completedFile.ReadLine();
                    continue;
                }
                else
                {
                    StreamReader catFile = new StreamReader("MenuDisplays/CategoryMenu.txt");
                    string catLine = catFile.ReadLine();
                    bool endCategoryLoop = false;

                    string spentNum = tempArray[4].TrimStart('$');
                    while (catLine != null && (endCategoryLoop == false))
                    {
                        string[] catField = catLine.Split('#');
                        string[] fieldSplit = catField[2].Split(' ');
                        if (tempArray[8] == fieldSplit[1])
                        {
                            if (catField[2].Contains("1"))
                            {
                                events[EventsCat.GetCount()] = new EventsCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                EventsCat.IncCount();
                            }
                            else if (catField[2].Contains("2"))
                            {
                                foodDrinks[FoodDrinkCat.GetCount()] = new FoodDrinkCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                FoodDrinkCat.IncCount();
                            }
                            else if (catField[2].Contains("3"))
                            {
                                games[GamesCat.GetCount()] = new GamesCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                GamesCat.IncCount();
                            }
                            else if (catField[2].Contains("4"))
                            {
                                museums[MuseumsCat.GetCount()] = new MuseumsCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                MuseumsCat.IncCount();
                            }
                            else if (catField[2].Contains("5"))
                            {
                                natures[NatureCat.GetCount()] = new NatureCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                NatureCat.IncCount();
                            }
                            else if (catField[2].Contains("6"))
                            {
                                nightLives[NightLifeCat.GetCount()] = new NightLifeCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                NightLifeCat.IncCount();
                            }
                            else if (catField[2].Contains("7"))
                            {
                                shoppings[ShoppingCat.GetCount()] = new ShoppingCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                ShoppingCat.IncCount();
                            }
                            else if (catField[2].Contains("8"))
                            {
                                tours[ToursCat.GetCount()] = new ToursCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                ToursCat.IncCount();
                            }
                            else if (catField[2].Contains("9"))
                            {
                                workshops[WorkshopsCat.GetCount()] = new WorkshopsCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                WorkshopsCat.IncCount();
                            }
                            else
                            {

                            }
                            Recommendations.IncCount();
                            endCategoryLoop = true;
                        }
                        else
                        {
                            catLine = catFile.ReadLine();
                        }
                    }
                    completeLine = completedFile.ReadLine();
                }
            }
            completedFile.Close();
            return 1;
        }
        //Writes Recommendations to the Recommendations file
        public void RecommendationsToFile(EventsCat[] events, FoodDrinkCat[] foodDrinks, 
        GamesCat[] games, MuseumsCat[] museums, NatureCat[] natures, NightLifeCat[] nightLives, 
        ShoppingCat[] shoppings, ToursCat[] tours, WorkshopsCat[] workshops)
        {
            Prompts.RecommendReportLocation();
            if (File.Exists("Recommendations.txt"))
            {
                StreamWriter outFile = new StreamWriter("Recommendations.txt");
                if (EventsCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(1)+":");
                    for (int i = 0; i < EventsCat.GetCount(); i++)
                    {
                        outFile.Write($"{events[i].GetName()} | ");
                        outFile.Write($"{events[i].GetRating()} | ");
                        outFile.WriteLine($"${events[i].GetSpent()}");
                    }
                }
                if (FoodDrinkCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(2)+":");
                    for (int i = 0; i < FoodDrinkCat.GetCount(); i++)
                    {
                        outFile.Write($"{foodDrinks[i].GetName()} | ");
                        outFile.Write($"{foodDrinks[i].GetRating()} | ");
                        outFile.WriteLine($"${foodDrinks[i].GetSpent()}");
                    }
                }
                if (GamesCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(3)+":");
                    for (int i = 0; i < GamesCat.GetCount(); i++)
                    {
                        outFile.Write($"{games[i].GetName()} | ");
                        outFile.Write($"{games[i].GetRating()} | ");
                        outFile.WriteLine($"${games[i].GetSpent()}");
                    }
                }
                if (MuseumsCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(4)+":");
                    for (int i = 0; i < MuseumsCat.GetCount(); i++)
                    {
                        outFile.Write($"{museums[i].GetName()} | ");
                        outFile.Write($"{museums[i].GetRating()} | ");
                        outFile.WriteLine($"${museums[i].GetSpent()}");
                    }
                }
                if (NatureCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(5)+":");
                    for (int i = 0; i < NatureCat.GetCount(); i++)
                    {
                        outFile.Write($"{natures[i].GetName()} | ");
                        outFile.Write($"{natures[i].GetRating()} | ");
                        outFile.WriteLine($"${natures[i].GetSpent()}");
                    }
                }
                if (NightLifeCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(6)+":");
                    for (int i = 0; i < NightLifeCat.GetCount(); i++)
                    {
                        outFile.Write($"{nightLives[i].GetName()} | ");
                        outFile.Write($"{nightLives[i].GetRating()} | ");
                        outFile.WriteLine($"${nightLives[i].GetSpent()}");
                    }
                }
                if (ShoppingCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(7)+":");
                    for (int i = 0; i < ShoppingCat.GetCount(); i++)
                    {
                        outFile.Write($"{shoppings[i].GetName()} | ");
                        outFile.Write($"{shoppings[i].GetRating()} | ");
                        outFile.WriteLine($"${shoppings[i].GetSpent()}");
                    }
                }
                if (ToursCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(8)+":");
                    for (int i = 0; i < ToursCat.GetCount(); i++)
                    {
                        outFile.Write($"{tours[i].GetName()} | ");
                        outFile.Write($"{tours[i].GetRating()} | ");
                        outFile.WriteLine($"${tours[i].GetSpent()}");
                    }
                }
                if (WorkshopsCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(9)+":");
                    for (int i = 0; i < WorkshopsCat.GetCount(); i++)
                    {
                        outFile.Write($"{workshops[i].GetName()} | ");
                        outFile.Write($"{workshops[i].GetRating()} | ");
                        outFile.WriteLine($"${workshops[i].GetSpent()}");
                    }
                }
                outFile.Close();
                Prompts.ReportSuccessful();
            }
            else
            {
                Prompts.RecommendReportFailed();
            }
        }
    }
}