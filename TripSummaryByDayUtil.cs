using System;//TEMP FOR DEBUGGING
namespace mis221_pa5_Dnsavage
{
    public class TripSummaryByDayUtil
    {
        private TripSummaryByDay[] dayByDayCompletions;
        //No args constructor for TripSummaryByDayUtil
        public TripSummaryByDayUtil()
        {

        }
        //Constructor for TripSummaryByDayUtil
        public TripSummaryByDayUtil(TripSummaryByDay[] dayByDayCompletions)
        {
            this.dayByDayCompletions = dayByDayCompletions;
        }
        //Sort summary report activities by completion date
        public void SortByDay()
        {
            for (int i = 0; i < TripSummaryByDay.GetCount()-1; i++)
            {
                int max = i;
                for (int j = i+1; j < TripSummaryByDay.GetCount(); j++)
                {
                    string[] maxDateArray = dayByDayCompletions[max].GetDateComplete().Split("/");
                    string[] nextDateArray = dayByDayCompletions[j].GetDateComplete().Split("/");
                    if (int.Parse(nextDateArray[2]) >= int.Parse(maxDateArray[2]))
                    {
                        if (int.Parse(nextDateArray[0]) >= int.Parse(maxDateArray[0]))
                        {
                            if (int.Parse(nextDateArray[1]) > int.Parse(maxDateArray[1]))
                            {
                                max = j;
                            }
                            else if((int.Parse(nextDateArray[1]) <= int.Parse(maxDateArray[1])) && 
                            (int.Parse(nextDateArray[0]) > int.Parse(maxDateArray[0])))
                            {
                                max = j;
                            }
                        }
                        else if ((int.Parse(nextDateArray[0]) < int.Parse(maxDateArray[0])) && 
                            (int.Parse(nextDateArray[2]) > int.Parse(maxDateArray[2])))
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
        //Swap order of summary report activities
        public void Swap(int x, int y)
        {
            TripSummaryByDay temp = dayByDayCompletions[x];
            dayByDayCompletions[x] = dayByDayCompletions[y];
            dayByDayCompletions[y] =  temp;
        }
    }
}