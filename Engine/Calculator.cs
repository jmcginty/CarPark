using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Calculator
    {
        public static decimal HourlyRate => 5;
        public static decimal EarlyBirdRate => 13;
        public static decimal NightRate => 6.50m;
        public static decimal WeekendRate => 10;
        public static decimal DayRate => HourlyRate * 4;

        public static BaseRate Calculate(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                throw new Exception("Start date must be earlier than end date");
            }

            TimeSpan time = endDate - startDate;
            TimeSpan days = endDate.Date - startDate.Date;

            // Early Bird Rate
            if (days.Days == 0)
            {
                if (startDate.TimeOfDay.TotalHours >= 6
                    && startDate.TimeOfDay.TotalHours <= 9
                    && endDate.TimeOfDay.TotalHours >= 15.5
                    && endDate.TimeOfDay.TotalHours <= 23.5)
                {
                    return new EarlyBirdRate()
                    {
                        TotalPrice = EarlyBirdRate,
                    };
                }
            }

            // Night Rate
            if (startDate.TimeOfDay.TotalHours >= 18
                && endDate.TimeOfDay.TotalHours < 6
                && startDate.DayOfWeek != DayOfWeek.Saturday
                && startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                return new NightRate()
                {
                    TotalPrice = NightRate,
                };
            }

            // Weekend Rate
            if ((startDate.DayOfWeek == DayOfWeek.Saturday
                || startDate.DayOfWeek == DayOfWeek.Sunday)
                &&
                (endDate.DayOfWeek == DayOfWeek.Saturday
                || endDate.DayOfWeek == DayOfWeek.Sunday)
                
                && days.Days < 2
                )
            {
                return new WeekendRate()
                {
                    TotalPrice = WeekendRate,
                };
            }

            // Weekend Rate
            if (startDate.TimeOfDay.TotalHours >= 18
                && endDate.TimeOfDay.TotalHours < 6
                && startDate.DayOfWeek != DayOfWeek.Saturday
                && startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                return new NightRate()
                {
                    TotalPrice = NightRate,
                };
            }

            // Standard Rates
            if (time.TotalHours <= 3)
            {
                return new StandardRate()
                {
                    TotalPrice = HourlyRate * (decimal)Math.Truncate(time.TotalHours),                    
                };
            }
            
            if (time.TotalHours > 3)
            {
                if (days.Days > 0)
                {
                    return new StandardRate()
                    {
                        TotalPrice = DayRate * (days.Days + 1),
                    };
                }

                return new StandardRate()
                {
                    TotalPrice = DayRate,
                };
            }

            return null;
        }
    }
}
