using Bujetto.webapi.BujettoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bujetto.webapi.Controllers
{
    [Route("/api/[controller]")]
    public class ExpenseCategoriesController : BujettoController
    {
        public ExpenseCategoriesController(BujettoDB.BujettoDbContext db) : base(db) { }

        //get all categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _db.Categories;
        }

        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            category.id = 0;
            if(String.IsNullOrWhiteSpace(category.name))
            {
                Response.StatusCode = 400; // bad request
                return null;
            }
            else
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return category;
            }
        }

        [HttpDelete]
        public void Delete([FromBody]Category category)
        {
            if(category.id == 0)
            {
                Response.StatusCode = 400; // bad request
                return;
            }
            else
            {
                category = _db.Categories.FirstOrDefault(c => c.id == category.id);
                if(category == null)
                {
                    Response.StatusCode = 404;
                    return;
                }
                else
                {
                    var expenses = _db.Expenses.Where(ex => ex.category.id == category.id);
                    _db.Expenses.RemoveRange(expenses.ToArray());

                    _db.Categories.Remove(category);
                    _db.SaveChanges();
                }
            }
        }
    }
}
