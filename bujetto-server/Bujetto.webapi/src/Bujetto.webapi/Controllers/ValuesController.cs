using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Bujetto.webapi.BujettoDB.Models;

namespace Bujetto.webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private BujettoDB.BujettoDbContext _db;

        public ValuesController(BujettoDB.BujettoDbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public User Post([FromBody]string value)
        {
            if (value != null && !String.IsNullOrWhiteSpace(value))
            {
                var name = value.Trim();
                var existing = _db.Users.FirstOrDefault(u => u.name.Equals(name));
                if (existing != null)
                {
                    this.HttpContext.Response.StatusCode = 302;
                    return existing;
                }

                var newUser = new BujettoDB.Models.User() { name = name };
                _db.Users.Add(newUser);
                _db.SaveChanges();

                this.HttpContext.Response.StatusCode = 201;
                return newUser;
            }
            else
            {
                this.HttpContext.Response.StatusCode = 400;
                return null;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
