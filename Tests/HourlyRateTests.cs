using System;
using Xunit;
using Engine;

namespace Tests
{
    public class HourlyRateTests
    {
        [Fact]
        public void ExitInOneHourIsOneHourlyRate()
        {
            var startTime = new DateTime(2019, 01, 01, 4, 0, 0);
            var endTime = startTime.AddHours(1);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.HourlyRate, rate.TotalPrice);
            Assert.Equal(RateType.Hourly, rate.Type);
            Assert.Equal("Standard", rate.Name);
        }

        [Fact]
        public void ExitInTwoHoursIsTwoHourlyRates()
        {
            var startTime = new DateTime(2019, 01, 01, 4, 0, 0);
            var endTime = startTime.AddHours(2);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.HourlyRate * 2, rate.TotalPrice);
            Assert.Equal(RateType.Hourly, rate.Type);
            Assert.Equal("Standard", rate.Name);
        }

        [Fact]
        public void ExitInThreeHoursIsThreeHourlyRates()
        {
            var startTime = new DateTime(2019, 01, 01, 4, 0, 0);
            var endTime = startTime.AddHours(3);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.HourlyRate * 3, rate.TotalPrice);
            Assert.Equal(RateType.Hourly, rate.Type);
            Assert.Equal("Standard", rate.Name);
        }

        [Fact]
        public void ExitInMoreThanThreeHoursIsFlatDayRate()
        {
            var startTime = new DateTime(2019, 01, 01, 4, 0, 0);
            var endTime = startTime.AddHours(3).AddMinutes(1);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.HourlyRate * 4, rate.TotalPrice);
            Assert.Equal(RateType.Hourly, rate.Type);
            Assert.Equal("Standard", rate.Name);
        }

        [Fact]
        public void LessThanTwentyFourHoursInTheSameDayIsTheDayRate()
        {
            var startTime = new DateTime(2019, 01, 01, 0, 0, 0);
            var endTime = startTime.AddHours(23).AddMinutes(59).AddSeconds(59);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.HourlyRate * 4, rate.TotalPrice);
            Assert.Equal(RateType.Hourly, rate.Type);
            Assert.Equal("Standard", rate.Name);
        }

        [Fact]
        public void MoreThan3HoursOverTwoCalendayDaysIsTwoDayRates()
        {
            var startTime = new DateTime(2019, 01, 01, 17, 0, 0);
            var endTime = startTime.AddHours(12);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.DayRate * 2, rate.TotalPrice);
            Assert.Equal(RateType.Hourly, rate.Type);
            Assert.Equal("Standard", rate.Name);
        }

        [Fact]
        public void HourlyRatePreferredOverWeekendRateFor1HourOrLess()
        {
            var startTime = new DateTime(2019, 02, 03, 17, 0, 0);
            var endTime = startTime.AddHours(1);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.HourlyRate, rate.TotalPrice);
            Assert.Equal(RateType.Hourly, rate.Type);
            Assert.Equal("Standard", rate.Name);
        }
    }
}
