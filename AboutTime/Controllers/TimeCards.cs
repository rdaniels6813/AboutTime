using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using AboutTime.Models;
using AboutTime.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AboutTime.Controllers
{
    [Route("api/[controller]")]
    public class TimeCards : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<ITimeCard> Get()
        {
            return new ITimeCard[] { new TimeCard() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ITimeCard Get(Guid id)
        {
            return new TimeCard();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ITimeCard value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]ITimeCard value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
