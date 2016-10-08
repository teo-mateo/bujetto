using Bujetto.webapi.BujettoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bujetto.webapi.Controllers
{
    [Route("/api/[controller]")]
    public class UsersController : BujettoController
    {
        public UsersController(BujettoDB.BujettoDbContext db) : base(db) { }

        //get all users
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users;
        }

        [HttpPost]
        public User Post([FromBody]string name)
        {
            if (name != null && !String.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
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

        [HttpPut]
        public User Put([FromBody]User user)
        {
            if (user.id == 0)
            {
                this.HttpContext.Response.StatusCode = 404;
                return null;
            }
            else
            {
                var dbUser = _db.Users.FirstOrDefault(u => u.id == user.id || u.name.Equals(user.name.Trim()));
                if(dbUser == null)
                {
                    this.HttpContext.Response.StatusCode = 404;
                    return null;
                }
                else
                {
                    dbUser.name = user.name;
                    _db.SaveChanges();

                    this.HttpContext.Response.StatusCode = 200;
                    return dbUser;
                }
            }
        }
    }
}
