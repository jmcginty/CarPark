using System;
using Xunit;
using Engine;

namespace Tests
{
    public class WeekendRateTests
    {
        [Fact]
        public void EnterAfterMidnightFridayAndExitBeforeMidnightSundayIsWeekendRate()
        {
            var startTime = new DateTime(2019, 02, 02, 0, 0, 0);
            var endTime = new DateTime(2019, 02, 03, 23, 59, 59);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.WeekendRate, rate.TotalPrice);
            Assert.IsType<WeekendRate>(rate);
            Assert.Equal("Weekend", rate.Name);
        }

        [Fact]
        public void WeekendRateNotValidIfStayMoreThan2Days()
        {
            // Start Saturday one week, and leave Sunmday the next week!
            var startTime = new DateTime(2019, 02, 02, 0, 0, 0);
            var endTime = new DateTime(2019, 02, 10, 23, 59, 59);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.IsNotType<WeekendRate>(rate);
        }

        [Fact]
        public void StartBeforeMidnightOnFridayDoesNotQualify()
        {
            var startTime = new DateTime(2019, 02, 01, 23, 59, 59);
            var endTime = new DateTime(2019, 02, 03, 23, 59, 59);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.IsNotType<WeekendRate>(rate);
        }

        [Fact]
        public void LeavingAfterMidnightOnSundayDoesNotQualify()
        {
            var startTime = new DateTime(2019, 02, 01, 0, 0, 0);
            var endTime = new DateTime(2019, 02, 03, 0, 0, 1);

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.IsNotType<WeekendRate>(rate);
        }
    }
}
