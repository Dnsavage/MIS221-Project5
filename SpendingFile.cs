using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class SpendingFile
    {
        private Spending[] expenditures;
        private EventsCat[] events;
        private FoodDrinkCat[] foodDrinks;
        private GamesCat[] games;
        private MuseumsCat[] museums;
        private NatureCat[] natures;
        private NightLifeCat[] nightLives;
        private ShoppingCat[] shoppings;
        private ToursCat[] tours;
        private WorkshopsCat[] workshops;
        //No args constructor for SpendingFile
        public SpendingFile()
        {

        }
        //Constructor for SpendingFile
        public SpendingFile(Spending[] expenditures, EventsCat[] events, FoodDrinkCat[] foodDrinks, 
        GamesCat[] games, MuseumsCat[] museums, NatureCat[] natures, NightLifeCat[] nightLives, 
        ShoppingCat[] shoppings, ToursCat[] tours, WorkshopsCat[] workshops)
        {
            this.expenditures = expenditures;
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
        //Assigns total expenditures for each category based on queries from the completion file
        public int GetExpenditures() 
        {
            Spending.SetCount(0);
            EventsCat.SetCount(0);
            FoodDrinkCat.SetCount(0);
            GamesCat.SetCount(0);
            MuseumsCat.SetCount(0);
            NatureCat.SetCount(0);
            NightLifeCat.SetCount(0);
            ShoppingCat.SetCount(0);
            ToursCat.SetCount(0);
            WorkshopsCat.SetCount(0);
            EventsCat.SetTotSpentCat("0");
            FoodDrinkCat.SetTotSpentCat("0");
            GamesCat.SetTotSpentCat("0");
            MuseumsCat.SetTotSpentCat("0");
            NatureCat.SetTotSpentCat("0");
            NightLifeCat.SetTotSpentCat("0");
            ShoppingCat.SetTotSpentCat("0");
            ToursCat.SetTotSpentCat("0");
            WorkshopsCat.SetTotSpentCat("0");

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
                int spent = 0;
                string amountSpent = tempArray[4].TrimStart('$');
                if (!int.TryParse(amountSpent, out spent))
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
                                EventsCat.SetTotSpentCat((int.Parse(EventsCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                EventsCat.IncCount();
                            }
                            else if (catField[2].Contains("2"))
                            {
                                foodDrinks[FoodDrinkCat.GetCount()] = new FoodDrinkCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                FoodDrinkCat.SetTotSpentCat((int.Parse(FoodDrinkCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                FoodDrinkCat.IncCount();
                            }
                            else if (catField[2].Contains("3"))
                            {
                                games[GamesCat.GetCount()] = new GamesCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                GamesCat.SetTotSpentCat((int.Parse(GamesCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                GamesCat.IncCount();
                            }
                            else if (catField[2].Contains("4"))
                            {
                                museums[MuseumsCat.GetCount()] = new MuseumsCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                MuseumsCat.SetTotSpentCat((int.Parse(MuseumsCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                MuseumsCat.IncCount();
                            }
                            else if (catField[2].Contains("5"))
                            {
                                natures[NatureCat.GetCount()] = new NatureCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                NatureCat.SetTotSpentCat((int.Parse(NatureCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                NatureCat.IncCount();
                            }
                            else if (catField[2].Contains("6"))
                            {
                                nightLives[NightLifeCat.GetCount()] = new NightLifeCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                NightLifeCat.SetTotSpentCat((int.Parse(NightLifeCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                NightLifeCat.IncCount();
                            }
                            else if (catField[2].Contains("7"))
                            {
                                shoppings[ShoppingCat.GetCount()] = new ShoppingCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                ShoppingCat.SetTotSpentCat((int.Parse(ShoppingCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                ShoppingCat.IncCount();
                            }
                            else if (catField[2].Contains("8"))
                            {
                                tours[ToursCat.GetCount()] = new ToursCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                ToursCat.SetTotSpentCat((int.Parse(ToursCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                ToursCat.IncCount();
                            }
                            else if (catField[2].Contains("9"))
                            {
                                workshops[WorkshopsCat.GetCount()] = new WorkshopsCat(tempArray[2], 
                                spentNum, tempArray[5]);
                                WorkshopsCat.SetTotSpentCat((int.Parse(WorkshopsCat.GetTotSpentCat())+int.Parse(spentNum)).ToString());
                                WorkshopsCat.IncCount();
                            }
                            else
                            {

                            }
                            Spending.IncCount();
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
        //Writes the spending report to the file
        public void SpendingToFile(Spending[] expenditures)
        {
            Prompts.SpendingReportLocation();
            if (File.Exists("SpendingReport.txt"))
            {
                StreamWriter outFile = new StreamWriter("SpendingReport.txt");
                Console.WriteLine();
                outFile.WriteLine(Prompts.SpendingReportTotal());
                if (EventsCat.GetCount() > 0)
                {
                    outFile.WriteLine();
                    outFile.WriteLine(Prompts.AssignCatLanguage(1)+": $"+EventsCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(2)+": $"+FoodDrinkCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(3)+": $"+GamesCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(4)+": $"+MuseumsCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(5)+": $"+NatureCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(6)+": $"+NightLifeCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(7)+": $"+ShoppingCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(8)+": $"+ToursCat.GetTotSpentCat());
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
                    outFile.WriteLine(Prompts.AssignCatLanguage(9)+": $"+WorkshopsCat.GetTotSpentCat());
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
                Prompts.SpendingReportFailed();
            }
        }
    }
}