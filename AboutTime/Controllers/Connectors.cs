using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AboutTime.Interfaces;
using AboutTime.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AboutTime.Controllers
{
    [Route("api/[controller]")]
    public class Connectors : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<IConnector> Get()
        {
            return new IConnector[] { new Connector() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IConnector Get(Guid id)
        {
            return new Connector();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]IConnector value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]IConnector value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
