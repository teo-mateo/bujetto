using Bujetto.webapi.BujettoDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bujetto.webapi.BujettoDB
{
    public class BujettoDbContext : DbContext
    {
        public BujettoDbContext(DbContextOptions<BujettoDbContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BudgetToCategory> BudgetsCategories { get; set; }
    }
}
