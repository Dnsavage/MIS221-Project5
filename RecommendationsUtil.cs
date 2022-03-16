using System.IO;
namespace mis221_pa5_Dnsavage
{
    public class RecommendationsUtil
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
        //No args constructor for RecommendationsUtil
        public RecommendationsUtil()
        {

        }
        //Constructor for RecommendationsUtil
        public RecommendationsUtil(EventsCat[] events, FoodDrinkCat[] foodDrinks, 
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
        //Sorts recommendations by price
        public void SortByPrice()
        {
            for (int i = 0; i < EventsCat.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < EventsCat.GetCount(); j++)
                {
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
        //Swaps activities in the Events category
        public void SwapEvents(int x, int y)
        {
            EventsCat temp = events[x];
            events[x] = events[y];
            events[y] =  temp;
        }
        //Swaps activities in the Food and Drink category
        public void SwapFood(int x, int y)
        {
            FoodDrinkCat temp = foodDrinks[x];
            foodDrinks[x] = foodDrinks[y];
            foodDrinks[y] =  temp;
        }
        //Swaps activities in the Games category
        public void SwapGames(int x, int y)
        {
            GamesCat temp = games[x];
            games[x] = games[y];
            games[y] =  temp;
        }
        //Swaps activities in the Museums category
        public void SwapMuseums(int x, int y)
        {
            MuseumsCat temp = museums[x];
            museums[x] = museums[y];
            museums[y] =  temp;
        }
        //Swaps activities in the Nature category
        public void SwapNatures(int x, int y)
        {
            NatureCat temp = natures[x];
            natures[x] = natures[y];
            natures[y] =  temp;
        }
        //Swaps activities in the Night Life category
        public void SwapNightLives(int x, int y)
        {
            NightLifeCat temp = nightLives[x];
            nightLives[x] = nightLives[y];
            nightLives[y] =  temp;
        }
        //Swaps activities in the Shopping category
        public void SwapShoppings(int x, int y)
        {
            ShoppingCat temp = shoppings[x];
            shoppings[x] = shoppings[y];
            shoppings[y] =  temp;
        }
        //Swaps activities in the Tours category
        public void SwapTours(int x, int y)
        {
            ToursCat temp = tours[x];
            tours[x] = tours[y];
            tours[y] =  temp;
        }
        //Swaps activities in the Workshops category
        public void SwapWorkshops(int x, int y)
        {
            WorkshopsCat temp = workshops[x];
            workshops[x] = workshops[y];
            workshops[y] =  temp;
        }
    }
}