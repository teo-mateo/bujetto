using Bujetto.webapi.BujettoDB.Models;
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
                    Budget.LoadCategories(_db, budget);
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

        //update all categories of a budget
        [HttpPost("{id}/setcategories")]
        public Budget Post(int id, [FromBody]IEnumerable<Category> categories)
        {
            var budget = _db.Budgets.FirstOrDefault(b => b.id == id);
            if(budget == null)
            {
                Response.StatusCode = 400;
                return null;
            }

            //delete existing
            var existing = _db.BudgetsCategories.Where(b => b.budgetid == id).ToArray();
            var toDelete = existing.Where(c1 => !categories.Any(c2 => c2.id == c1.categoryid)).ToArray();
            var toAdd = categories.Where(c1 => !existing.Any(c2 => c2.categoryid == c1.id)).ToArray();

            if (toDelete.Length > 0)
            {
                _db.BudgetsCategories.RemoveRange(toDelete);
            }

            if(toAdd.Length > 0)
            {
                _db.BudgetsCategories.AddRange(
                    toAdd.Select(
                        c => new BudgetToCategory()
                        {
                            budgetid = id,
                            categoryid = c.id
                        }).ToArray());
            }

            _db.SaveChanges();

            Budget.LoadCategories(_db, budget);

            return budget;
        }

        //update budget
        [HttpPut]
        public Budget Put([FromBody]Budget budget)
        {
            if(budget.id == 0)
            {
                Response.StatusCode = 400;
                return null;
            }
            else
            {
                var existing = _db.Budgets.FirstOrDefault(b => b.id == budget.id);
                if(existing == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                else
                {
                    existing.name = budget.name;
                    existing.startdate = budget.startdate;
                    existing.expirationdate = budget.expirationdate;
                    existing.value = budget.value;
                    _db.SaveChanges();
                    return existing;
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
