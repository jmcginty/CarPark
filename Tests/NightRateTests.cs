using System;
using Xunit;
using Engine;

namespace Tests
{
    public class NightRateTests
    {
        private Calculator calculator = new Calculator();

        [Fact]
        public void EnterAt6pmOrAfterAndExitBefore6amIsNightRate()
        {
            var startTime = new DateTime(2019, 02, 04, 18, 0, 0);
            var endTime = new DateTime(2019, 02, 05, 5, 59, 59);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.NightRate, rate.TotalPrice);
            Assert.IsType<NightRate>(rate);
            Assert.Equal("Night", rate.Name);
        }

        [Fact]
        public void StartingBefore6pmDisqaulifiesNightRate()
        {
            var startTime = new DateTime(2019, 02, 04, 17, 59, 59);
            var endTime = new DateTime(2019, 02, 05, 5, 59, 59);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<NightRate>(rate);
        }

        [Fact]
        public void Exiting6amOrAfterDisqaulifiesNightRate()
        {
            var startTime = new DateTime(2019, 02, 04, 18, 0, 0);
            var endTime = new DateTime(2019, 02, 05, 6, 0, 0);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<NightRate>(rate);
        }

        [Fact]
        public void NightRateNotValidToStartOnWeekend()
        {
            // This is a Saturday
            var startTime = new DateTime(2019, 02, 02, 18, 0, 0);
            var endTime = new DateTime(2019, 02, 03, 5, 59, 59);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<NightRate>(rate);

            // This is a Sunday
            startTime = new DateTime(2019, 02, 03, 18, 0, 0);
            endTime = new DateTime(2019, 02, 04, 5, 59, 59);

            rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<NightRate>(rate);
        }
    }
}
