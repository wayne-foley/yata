using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIServer.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        // GET api/todo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //throw new NotImplementedException("TDD");
            return new string[] { };
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException("TDD");
            //return "value";
        }

        // POST api/todo
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException("TDD");
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException("TDD");
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException("TDD");
        }
    }
}
