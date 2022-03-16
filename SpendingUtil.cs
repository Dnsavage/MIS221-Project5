using System;
using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class SpendingUtil
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
        //No args constructor for SpendingUtil
        public SpendingUtil()
        {

        }
        //Constructor for SpendingUtil
        public SpendingUtil(Spending[] expenditures, EventsCat[] events, FoodDrinkCat[] foodDrinks, 
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
        //Sort completions in the spending report by price
        public void SortByPrice()
        {
            for (int i = 0; i < EventsCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < EventsCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(events[j].GetSpent()) > int.Parse(events[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapEvents(max, i);
                }
            }
            for (int i = 0; i < FoodDrinkCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < FoodDrinkCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(foodDrinks[j].GetSpent()) > int.Parse(foodDrinks[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapFood(max, i);
                }
            }
            for (int i = 0; i < GamesCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < GamesCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(games[j].GetSpent()) > int.Parse(games[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapGames(max, i);
                }
            }
            for (int i = 0; i < MuseumsCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < MuseumsCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(museums[j].GetSpent()) > int.Parse(museums[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapMuseums(max, i);
                }
            }
            for (int i = 0; i < NatureCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < NatureCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(natures[j].GetSpent()) > int.Parse(natures[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapNatures(max, i);
                }
            }
            for (int i = 0; i < NightLifeCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < NightLifeCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(nightLives[j].GetSpent()) > int.Parse(nightLives[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapNightLives(max, i);
                }
            }
            for (int i = 0; i < ShoppingCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < ShoppingCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(shoppings[j].GetSpent()) > int.Parse(shoppings[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapShoppings(max, i);
                }
            }
            for (int i = 0; i < ToursCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < ToursCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(tours[j].GetSpent()) > int.Parse(tours[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapTours(max, i);
                }
            }
            for (int i = 0; i < WorkshopsCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < WorkshopsCat.GetCount(); j++)
                {
                    //Years
                    if (int.Parse(workshops[j].GetSpent()) > int.Parse(workshops[i].GetSpent()))
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    SwapWorkshops(max, i);
                }
            }
        }
        //Calculate the total amount spent across all activities
        public void GetSpendingSum()
        {
            Spending.SetTotalSpent("0");
            Spending.SetTotalSpent((int.Parse(EventsCat.GetTotSpentCat()) + int.Parse(FoodDrinkCat.GetTotSpentCat())
            + int.Parse(GamesCat.GetTotSpentCat()) + int.Parse(MuseumsCat.GetTotSpentCat()) + int.Parse(NatureCat.GetTotSpentCat()) 
            + int.Parse(NightLifeCat.GetTotSpentCat()) + int.Parse(ShoppingCat.GetTotSpentCat()) + int.Parse(ToursCat.GetTotSpentCat()) 
            + int.Parse(WorkshopsCat.GetTotSpentCat())).ToString());
        }
        //Swap completed activities in the Events category
        public void SwapEvents(int x, int y)
        {
            EventsCat temp = events[x];
            events[x] = events[y];
            events[y] =  temp;
        }
        //Swap completed activities in the Food and Drink category
        public void SwapFood(int x, int y)
        {
            FoodDrinkCat temp = foodDrinks[x];
            foodDrinks[x] = foodDrinks[y];
            foodDrinks[y] =  temp;
        }
        //Swap completed activities in the Games category
        public void SwapGames(int x, int y)
        {
            GamesCat temp = games[x];
            games[x] = games[y];
            games[y] =  temp;
        }
        //Swap completed activities in the Museums category
        public void SwapMuseums(int x, int y)
        {
            MuseumsCat temp = museums[x];
            museums[x] = museums[y];
            museums[y] =  temp;
        }
        //Swap completed activities in the Nature category
        public void SwapNatures(int x, int y)
        {
            NatureCat temp = natures[x];
            natures[x] = natures[y];
            natures[y] =  temp;
        }
        //Swap completed activities in the Night Life category
        public void SwapNightLives(int x, int y)
        {
            NightLifeCat temp = nightLives[x];
            nightLives[x] = nightLives[y];
            nightLives[y] =  temp;
        }
        //Swap completed activities in the Shopping category
        public void SwapShoppings(int x, int y)
        {
            ShoppingCat temp = shoppings[x];
            shoppings[x] = shoppings[y];
            shoppings[y] =  temp;
        }
        //Swap completed activities in the Tours category
        public void SwapTours(int x, int y)
        {
            ToursCat temp = tours[x];
            tours[x] = tours[y];
            tours[y] =  temp;
        }
        //Swap completed activities in the Workshops category
        public void SwapWorkshops(int x, int y)
        {
            WorkshopsCat temp = workshops[x];
            workshops[x] = workshops[y];
            workshops[y] =  temp;
        }
    }
}