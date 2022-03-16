using System;
namespace mis221_pa5_Dnsavage
{
    public class RecommendationsReport
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
        //No args constructor for RecommendationsReport
        public RecommendationsReport()
        {

        }
        //Constructor for RecommendationsReport
        public RecommendationsReport(EventsCat[] events, FoodDrinkCat[] foodDrinks, 
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
        //Displays all recommendations
        public void DisplayRecommendations()
        {
            Prompts.RecommendedMessage();
            if (EventsCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(1)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < EventsCat.GetCount(); i++)
                {
                    Console.Write($"{events[i].GetName()} | ");
                    Console.Write($"{events[i].GetRating()} | ");
                    Console.WriteLine($"${events[i].GetSpent()}");
                }
            }
            if (FoodDrinkCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(2)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < FoodDrinkCat.GetCount(); i++)
                {
                    Console.Write($"{foodDrinks[i].GetName()} | ");
                    Console.Write($"{foodDrinks[i].GetRating()} | ");
                    Console.WriteLine($"${foodDrinks[i].GetSpent()}");
                }
            }
            if (GamesCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(3)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < GamesCat.GetCount(); i++)
                {
                    Console.Write($"{games[i].GetName()} | ");
                    Console.Write($"{games[i].GetRating()} | ");
                    Console.WriteLine($"${games[i].GetSpent()}");
                }
            }
            if (MuseumsCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(4)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < MuseumsCat.GetCount(); i++)
                {
                    Console.Write($"{museums[i].GetName()} | ");
                    Console.Write($"{museums[i].GetRating()} | ");
                    Console.WriteLine($"${museums[i].GetSpent()}");
                }
            }
            if (NatureCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(5)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < NatureCat.GetCount(); i++)
                {
                    Console.Write($"{natures[i].GetName()} | ");
                    Console.Write($"{natures[i].GetRating()} | ");
                    Console.WriteLine($"${natures[i].GetSpent()}");
                }
            }
            if (NightLifeCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(6)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < NightLifeCat.GetCount(); i++)
                {
                    Console.Write($"{nightLives[i].GetName()} | ");
                    Console.Write($"{nightLives[i].GetRating()} | ");
                    Console.WriteLine($"${nightLives[i].GetSpent()}");
                }
            }
            if (ShoppingCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(7)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < ShoppingCat.GetCount(); i++)
                {
                    Console.Write($"{shoppings[i].GetName()} | ");
                    Console.Write($"{shoppings[i].GetRating()} | ");
                    Console.WriteLine($"${shoppings[i].GetSpent()}");
                }
            }
            if (ToursCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(8)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < ToursCat.GetCount(); i++)
                {
                    Console.Write($"{tours[i].GetName()} | ");
                    Console.Write($"{tours[i].GetRating()} | ");
                    Console.WriteLine($"${tours[i].GetSpent()}");
                }
            }
            if (WorkshopsCat.GetCount() > 0)
            {
                Console.WriteLine();
                Console.WriteLine(Prompts.AssignCatLanguage(9)+":");
                Prompts.SpendingAndRecommendFormatHeader();
                for (int i = 0; i < WorkshopsCat.GetCount(); i++)
                {
                    Console.Write($"{workshops[i].GetName()} | ");
                    Console.Write($"{workshops[i].GetRating()} | ");
                    Console.WriteLine($"${workshops[i].GetSpent()}");
                }
            }
            Prompts.EnterToContinueMessage();
        }
    }
}