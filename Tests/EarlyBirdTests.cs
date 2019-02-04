using System;
using Xunit;
using Engine;

namespace Tests
{
    public class EarlyBirdTests
    {
        private Calculator calculator = new Calculator();

        [Fact]
        public void EnterBetween6amAnd9amExitBetween3pmAnd1130pmIsEarlyBirdRate()
        {
            var startTime = new DateTime(2019, 01, 01, 6, 0, 0);
            var endTime = new DateTime(2019, 01, 01, 23, 30, 0);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.Equal(Calculator.EarlyBirdRate, rate.TotalPrice);
            Assert.IsType<EarlyBirdRate>(rate);
            Assert.Equal("Early Bird", rate.Name);
        }

        [Fact]
        public void EarlyBirdRateOnlyAvailableSameDay()
        {
            var startTime = new DateTime(2019, 01, 01, 6, 0, 0);
            var endTime = new DateTime(2019, 01, 02, 23, 30, 0);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<EarlyBirdRate>(rate);
        }

        [Fact]
        public void EnterBefore6amNoEarlyBirdRate()
        {
            var startTime = new DateTime(2019, 01, 01, 5, 59, 59);
            var endTime = new DateTime(2019, 01, 01, 23, 30, 0);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<EarlyBirdRate>(rate);
        }

        [Fact]
        public void EnterAfter9amNoEarlyBirdRate()
        {
            var startTime = new DateTime(2019, 01, 01, 9, 0, 1);
            var endTime = new DateTime(2019, 01, 01, 23, 30, 0);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<EarlyBirdRate>(rate);
        }


        [Fact]
        public void ExitBefore330pmNoEarlyBirdRate()
        {
            var startTime = new DateTime(2019, 01, 01, 6, 0, 0);
            var endTime = new DateTime(2019, 01, 01, 15, 29, 59);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<EarlyBirdRate>(rate);
        }

        [Fact]
        public void ExitAfter1130pmNoEarlyBirdRate()
        {
            var startTime = new DateTime(2019, 01, 01, 6, 0, 0);
            var endTime = new DateTime(2019, 01, 01, 23, 30, 1);

            var rate = calculator.Calculate(startTime, endTime);
            Assert.IsNotType<EarlyBirdRate>(rate);
        }
    }
}
