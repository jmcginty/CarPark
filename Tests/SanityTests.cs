using System;
using Xunit;
using Engine;

namespace Tests
{
    public class SanityTests
    {
        [Fact]
        public void StartDateMustBeLessThanEndDate()
        {
            var startTime = new DateTime(2019, 01, 01, 4, 0, 0);
            var endTime = startTime;

            var rate = Calculator.Calculate(startTime, endTime);
            Assert.Equal("Start date must be earlier than end date", rate.Error);
        }
    }
}
