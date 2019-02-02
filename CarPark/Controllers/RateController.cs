using System;
using Engine;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        // GET: api/Rate
        [HttpGet]
        public BaseRate Get(DateTime startDate, DateTime endDate)
        {
            return Calculator.Calculate(startDate, endDate);
        }

        // GET: api/Rate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rate
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
