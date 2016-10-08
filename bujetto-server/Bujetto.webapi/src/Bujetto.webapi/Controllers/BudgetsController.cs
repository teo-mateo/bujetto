﻿using Bujetto.webapi.BujettoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Bujetto.webapi.Controllers
{
    [Route("/api/[controller]")]
    public class BudgetsController : BujettoController
    {
        public BudgetsController(BujettoDB.BujettoDbContext db) : base(db) { }

        [HttpGet("{id}")]
        public Budget Get(int id)
        {
            if(id == 0)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                var budget = _db.Budgets.AsNoTracking()
                    .Include(b => b.expenses)
                    .FirstOrDefault(b => b.id == id);
                if(budget == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                else
                {
                    return budget;
                }
            }
        }

        //create budget
        [HttpPost]
        public Budget Post(int userid, [FromBody]Budget budget)
        {
            if (budget.userid == 0)
            {
                this.HttpContext.Response.StatusCode = 400; //bad request
                return null;
            }
            else
            {
                var user = _db.Users.FirstOrDefault(u => u.id == budget.userid);
                if(user == null)
                {
                    this.Response.StatusCode = 400; //bad request
                    return null;
                }
                else
                {
                    _db.Budgets.Add(budget);
                    _db.SaveChanges();
                    this.Response.StatusCode = 201; // created
                    return budget;
                }
            }
        }

        [HttpDelete]
        public void Delete([FromBody]Budget budget)
        {
            if(budget.id == 0)
            {
                Response.StatusCode = 400; // bad request
                return;
            }
            else
            {
                budget = _db.Budgets.FirstOrDefault(b => b.id == budget.id);
                if(budget == null)
                {
                    Response.StatusCode = 400;
                    return;
                }
                else
                {
                    _db.Budgets.Remove(budget);
                    _db.SaveChanges();
                    return;
                }
            }
        }
    }
}