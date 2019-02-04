using System;
using Engine;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private ICalculator calculator;

        public RateController(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        // GET: api/Rate
        [HttpGet]
        public BaseRate Get(DateTime startDate, DateTime endDate)
        {
            return calculator.Calculate(startDate, endDate);
        }
    }
}
