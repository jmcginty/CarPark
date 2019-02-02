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

            Assert.Throws<Exception>(() => Calculator.Calculate(startTime, endTime));
        }
    }
}
