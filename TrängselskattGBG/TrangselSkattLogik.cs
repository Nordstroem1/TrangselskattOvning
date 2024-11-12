using System;
using System.Collections.Generic;
using System.Linq;
namespace TrängselskattGBG
{
    public class TrangselSkattLogik
    {
        public int CalculateCostBasedOnTime(string dates)
        {
            int cost = 0;
            Dictionary<string, int> costDic = new Dictionary<string, int>()
            {
                { "06:00-06:29", 8 },
                { "06:30-06:59", 13 },
                { "07:00-07:59", 18 },
                { "08:00-08:29", 13 },
                { "08:30-14:59", 8 },
                { "15:00-15:29", 13 },
                { "15:30-16:59", 18 },
                { "17:00-17:59", 13 },
                { "18:00-18:29", 8 },
                { "18:30-05:59", 0 }
            };

            dates.Split(',').ToList().ForEach(date =>
            {
                DateTime convertedDate = DateTime.Parse(date);
                var acutalDay = convertedDate.DayOfWeek;
                int totalCost = 0;
                TimeSpan timeOfNow = convertedDate.TimeOfDay;

                foreach (var entry in costDic)
                {
                    var times = entry.Key.Split('-');
                    TimeSpan start = TimeSpan.Parse(times[0]);
                    TimeSpan end = TimeSpan.Parse(times[1]);

                    if (timeOfNow >= start && timeOfNow <= end)
                    {
                        cost += entry.Value;
                    }
                }
            });

            return cost;
        }
    }
}
