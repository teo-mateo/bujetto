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

        //get all budgets for user
        [HttpGet("{userid}/budgets")]
        public IEnumerable<Budget> GetUserBudgets(int userid)
        {
            return _db.Budgets.Where(b => b.user.id == userid);
        }



        //create user
        [HttpPost]
        public User Post([FromBody]User user)
        {
            if (user.name != null && !String.IsNullOrWhiteSpace(user.name))
            {
                user.name = user.name.Trim();
                var existing = _db.Users.FirstOrDefault(u => u.name.Equals(user.name));
                if (existing != null)
                {
                    this.HttpContext.Response.StatusCode = 302; //found
                    return existing;
                }

                user.id = 0;

                _db.Users.Add(user);
                _db.SaveChanges();

                this.HttpContext.Response.StatusCode = 201; //created
                return user;
            }
            else
            {
                this.HttpContext.Response.StatusCode = 400; //bad request
                return null;
            }
        }

        //update user
        [HttpPut]
        public User Put([FromBody]User user)
        {
            if(user == null)
            {
                this.HttpContext.Response.StatusCode = 400; // bad request
                return null;
            }

            if (user.id == 0)
            {
                this.HttpContext.Response.StatusCode = 404; // user not found
                return null;
            }
            else
            {
                var dbUser = _db.Users.FirstOrDefault(u => u.id == user.id);
                if(dbUser == null)
                {
                    this.HttpContext.Response.StatusCode = 404; // user not found
                    return null;
                }
                else
                {
                    if(dbUser.name.Equals(user.name))
                    {
                        this.HttpContext.Response.StatusCode = 304; // not modified
                        return dbUser;
                    }

                    dbUser.name = user.name;
                    _db.SaveChanges();

                    this.HttpContext.Response.StatusCode = 200;
                    return dbUser;
                }
            }
        }
    }
}
