using System;
namespace mis221_pa5_Dnsavage
{
    public class RemainingActivitiesUtil
    {
        private RemainingActivities[] remainActivities;
        //No args constructor for RemainingActivitiesUtil
        public RemainingActivitiesUtil()
        {

        }
        //Constructor for RemainingActivitiesUtil
        public RemainingActivitiesUtil(RemainingActivities[] remainActivities)
        {
            this.remainActivities = remainActivities;
        }
        //Sorts remaining activities by category
        public void SortByCategory(int sortChoice)
        {
            for (int i = 0; i < RemainingActivities.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < RemainingActivities.GetCount(); j++)
                {
                    if (sortChoice == 2)
                    {
                        if (remainActivities[max].CatCompareTo(remainActivities[j]) > 0)
                        {
                            max = j;
                        }
                    }
                    else
                    {
                        if (remainActivities[max].CatCompareTo(remainActivities[j]) < 0)
                        {
                            max = j;
                        }
                    }
                    
                }
                if (max != i)
                {
                    Swap(max, i);
                }
            }
        }
        //Sorts remaining activities by time
        public void SortByTime(int sortChoice)
        {
            
            //Need to split TimeNeeded field (int-minutes/hours/days)
            for (int i = 0; i < RemainingActivities.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < RemainingActivities.GetCount(); j++)
                {
                    
                    int[] amount = ConvertTimeToMinutes(i, j);
                    int maxAmount = amount[0];
                    int nextAmount = amount[1];
                    if (sortChoice == 4)
                    {
                        if (nextAmount < maxAmount)
                        {
                            max = j;
                        }
                    }
                    else
                    {
                        if (nextAmount > maxAmount)
                        {
                            max = j;
                        }
                    }
                    
                }
                if (max != i)
                {
                    Swap(max, i);
                }
            }
        }
        //Converts all time values to minutes
        public int[] ConvertTimeToMinutes(int i, int j)
        {
            const int MINUTES_IN_A_DAY = 1440;
            const int MINUTES_IN_AN_HOUR = 60;
            int[] maxAndMinTimes = new int[2];
            string[] tempArrayMax = remainActivities[i].GetTimeNeeded().Split("-");
            int maxAmount = int.Parse(tempArrayMax[0]);//# of minutes/hours/days
            string maxCat = tempArrayMax[1];//minutes/hours/days
            if (maxCat == "Days" || maxCat == "Day")
            {
                maxAmount *= MINUTES_IN_AN_HOUR;
            }
            else if (maxCat == "Hours" || maxCat == "Hour")
            {
                maxAmount *= MINUTES_IN_AN_HOUR;
            }
            string[] tempArrayNext = remainActivities[j].GetTimeNeeded().Split("-");
            int nextAmount = int.Parse(tempArrayNext[0]);//# of minutes/hours/days
            string nextCat = tempArrayNext[1];//minutes/hours/days
            if (nextCat == "Days" || nextCat == "Day")
            {
                nextAmount *= MINUTES_IN_A_DAY;
            }
            else if (nextCat == "Hours" || nextCat == "Hour")
            {
                nextAmount *= MINUTES_IN_AN_HOUR;
            }
            maxAndMinTimes[0] = maxAmount;
            maxAndMinTimes[1] = nextAmount;
            return maxAndMinTimes;
        }
        //Sorts remaining activities by price
        public void SortByPrice(int sortChoice)
        {
            for (int i = 0; i < RemainingActivities.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < RemainingActivities.GetCount(); j++)
                {
                    switch (sortChoice)
                    {
                        case 6: if (int.Parse(remainActivities[max].GetPriceMin()) > int.Parse(remainActivities[j].GetPriceMin()))
                                {
                                    max = j;
                                }
                                else if (int.Parse(remainActivities[max].GetPriceMin()) == int.Parse(remainActivities[j].GetPriceMin()))
                                {
                                    if (int.Parse(remainActivities[max].GetPriceMax()) > int.Parse(remainActivities[j].GetPriceMax()))
                                    {
                                        max = j;
                                    }
                                }
                            break;
                        case 7: if (int.Parse(remainActivities[max].GetPriceMin()) < int.Parse(remainActivities[j].GetPriceMin()))
                                {
                                    max = j;
                                }
                                else if (int.Parse(remainActivities[max].GetPriceMin()) == int.Parse(remainActivities[j].GetPriceMin()))
                                {
                                    if (int.Parse(remainActivities[max].GetPriceMax()) < int.Parse(remainActivities[j].GetPriceMax()))
                                    {
                                        max = j;
                                    }
                                }
                            break;
                        case 8: if (int.Parse(remainActivities[max].GetPriceMax()) > int.Parse(remainActivities[j].GetPriceMax()))
                                {
                                    max = j;
                                }
                                else if (int.Parse(remainActivities[max].GetPriceMax()) == int.Parse(remainActivities[j].GetPriceMax()))
                                {
                                    if (int.Parse(remainActivities[max].GetPriceMin()) > int.Parse(remainActivities[j].GetPriceMin()))
                                    {
                                        max = j;
                                    }
                                }
                            break;
                        default: if (int.Parse(remainActivities[max].GetPriceMax()) < int.Parse(remainActivities[j].GetPriceMax()))
                                {
                                    max = j;
                                }
                                else if (int.Parse(remainActivities[max].GetPriceMax()) == int.Parse(remainActivities[j].GetPriceMax()))
                                {
                                    if (int.Parse(remainActivities[max].GetPriceMin()) < int.Parse(remainActivities[j].GetPriceMin()))
                                    {
                                        max = j;
                                    }
                                }
                            break;
                    }
                }
                if (max != i)
                {
                    Swap(max, i);
                }
            }
        }
        //Sorts remaining activities by ticket necessity
        public void SortByTicketNeed(int sortChoice)
        {
            for (int i = 0; i < RemainingActivities.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < RemainingActivities.GetCount(); j++)
                {
                    if (sortChoice == 7)
                    {
                        if (remainActivities[max].TicketCompareTo(remainActivities[j]) > 0)
                        {
                            max = j;
                        }
                    }
                    else
                    {
                        if (remainActivities[max].TicketCompareTo(remainActivities[j]) < 0)
                        {
                            max = j;
                        }
                    }
                }
                if (max != i)
                {
                    Swap(max, i);
                }
            }
        }

        //Swaps order of remaining activities
        public void Swap(int x, int y)
        {
            RemainingActivities temp = remainActivities[x];
            remainActivities[x] = remainActivities[y];
            remainActivities[y] =  temp;
        }
    }
}