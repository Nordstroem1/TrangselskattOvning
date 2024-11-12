using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
namespace TrängselskattGBG
{
    public class TrangselSkattLogik
    {
        public int CalculateCostBasedOnTime(string dates)
        {
            int totalCost = 0;
            List<string> costList = CreateCostList();

            var times = dates.Split(',');
            List<DateTime> timesList = new List<DateTime>();

            foreach (var date in times)
            {
                timesList.Add(DateTime.Parse(date));
            }

            totalCost = CalculateTotalCost(costList, timesList);

            return totalCost;
        }

        private static int CalculateTotalCost(List<string> costList, List<DateTime> timesList)
        {
            int totalCost = 0;
            var groupedByDay = timesList.GroupBy(t => t.Date);

            foreach (var totalDays in groupedByDay)
            {
                int dailyCost = 0;

                foreach (var time in totalDays)
                {
                    foreach (var costTime in costList)
                    {
                        var parts = costTime.Split(',');
                        var startTime = TimeSpan.Parse(parts[0]);
                        var endTime = TimeSpan.Parse(parts[1]);
                        var costPerHour = int.Parse(parts[2]);
                        var timeOfDay = time.TimeOfDay;

                        if (timeOfDay >= startTime && timeOfDay <= endTime)
                        {
                            dailyCost += costPerHour;

                            if (dailyCost > 60)
                            {
                                dailyCost = 60;
                                break;
                            }
                        }
                    }
                }

                totalCost += dailyCost;
            }

            return totalCost;
        }

        private static List<string> CreateCostList()
        {
            return new List<string>()
                {
                    { "06:00,06:29, 8"},
                    { "06:30,06:59, 13"},
                    { "07:00,07:59, 18"},
                    { "08:00,08:29, 13"},
                    { "08:30,14:59, 8"},
                    { "15:00,15:29, 13"},
                    { "15:30,16:59, 18"},
                    { "17:00,17:59, 13"},
                    { "18:00,18:29, 8"},
                    { "18:30,05:59, 0"}
                };
        }
    }
}
