using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bujetto.webapi.BujettoDB.Models
{
    [Table("budget")]
    public class Budget
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? expirationdate { get; set; }
        public decimal value { get; set; }
        public int userid { get; set; }
        public virtual User user { get; set; }
        public virtual IList<Expense> expenses { get; set; }
        [NotMapped]
        public decimal totalexpenses
        {
            get
            {
                return expenses == null? 0 : expenses.Sum(ex => ex.value);
            }
        }
        [NotMapped]
        public IEnumerable<Category> categories { get; set; }

        public static void LoadCategories(BujettoDbContext db, Budget budget)
        {
            budget.categories = (from c in db.Categories
                                 join bc in db.BudgetsCategories on c.id equals bc.categoryid
                                 where bc.budgetid == budget.id
                                 select c).ToArray();
        }
    }

    [Table("user")]
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    [Table("expense")]
    public class Expense
    {
        public int id { get; set; }
        public decimal value { get; set; }
        public int budgetid { get; set; }
        public int categoryid { get; set; }
        public virtual Category category { get; set; }
        public DateTime? date { get; set; }
        public string description { get; set; }
    }

    [Table("expense_category")]
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    [Table("budgets_categories_m2m")]
    public class BudgetToCategory
    {
        public int id { get; set; }
        public int budgetid { get; set; }
        public Budget budget { get; set; }

        public int categoryid { get; set; }
        public Category category { get; set; }
    }
}
