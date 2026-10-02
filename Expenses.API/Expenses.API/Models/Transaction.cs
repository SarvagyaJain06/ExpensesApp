using Expenses.API.Models.Base;

namespace Expenses.API.Models
{
    public class Transaction : BaseEntitiy
    {
        public string Type { get; set; }
        public double Amount { get; set; } 
        public string Category { get; set; }
    }
}
