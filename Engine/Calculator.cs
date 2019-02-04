using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Calculator
    {
        public const decimal HourlyRate = 5;
        public const decimal EarlyBirdRate = 13;
        public const decimal NightRate = 6.50m;
        public const decimal WeekendRate = 10;
        public const decimal DayRate = HourlyRate * 4;

        public static BaseRate Calculate(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                return new StandardRate()
                {
                    Error = "Start date must be earlier than end date"
                };
            }

            TimeSpan time = endDate - startDate;
            TimeSpan days = endDate.Date - startDate.Date;

            // Standard Rate for one hour or less
            if (time.TotalHours <= 1)
            {
                return new StandardRate()
                {
                    TotalPrice = HourlyRate,
                };
            }

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

            // Weekday Night Rate
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
