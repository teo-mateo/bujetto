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
                return expenses.Sum(ex => ex.value);
            }
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
        public virtual ExpenseCategory category { get; set; }
        public DateTime? date { get; set; }
        public string description { get; set; }
    }

    [Table("expense_category")]
    public class ExpenseCategory
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
