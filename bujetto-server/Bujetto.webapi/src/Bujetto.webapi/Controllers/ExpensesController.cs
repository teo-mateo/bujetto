using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bujetto.webapi.BujettoDB;
using Bujetto.webapi.BujettoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bujetto.webapi.Controllers
{
    [Route("/api/[controller]")]
    public class ExpensesController : BujettoController
    {
        public ExpensesController(BujettoDbContext db) : base(db)
        {
        }

        [HttpGet("{id}")]
        public Expense Get(int id)
        {
            var expense = _db.Expenses.FirstOrDefault(ex => ex.id == id);
            if(expense == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                return expense;
            }
        }

        [HttpPost]
        public Expense Post([FromBody]Expense expense)
        {
            if (expense == null || expense.categoryid == 0 || expense.budgetid == 0 || expense.value == 0)
            {
                Response.StatusCode = 400;
                return null;
            }

            _db.Expenses.Add(expense);
            _db.SaveChanges();
            return expense;
        }

        [HttpPut]
        public Expense Put([FromBody]Expense expense)
        {
            if (expense == null || expense.categoryid == 0 || expense.budgetid == 0 || expense.value == 0)
            {
                Response.StatusCode = 400;
                return null;
            }

            if(!_db.Budgets.Any(b=>b.id == expense.budgetid) || 
                !_db.ExpenseCategories.Any(c=>c.id == expense.categoryid))
            {
                Response.StatusCode = 400;
                return null;
            }

            var existing = _db.Expenses.FirstOrDefault(ex => ex.id == expense.id);
            if (existing == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            existing.budgetid = expense.budgetid;
            existing.categoryid = expense.categoryid;
            existing.date = expense.date;
            existing.value = expense.value;
            existing.description = expense.description;

            _db.SaveChanges();
            return existing;
        }


    }
}
