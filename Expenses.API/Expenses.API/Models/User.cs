using Expenses.API.Models.Base;

namespace Expenses.API.Models
{
    public class User: BaseEntitiy
    {
        
        public string Email {  get; set; }
        public string Password { get; set; }
        
    }
}
