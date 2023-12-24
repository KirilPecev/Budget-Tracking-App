using BudgetBuddy.Domain.Models;

using Microsoft.AspNetCore.Identity;

namespace BudgetBuddy.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        internal User(string email) : base(email)
        {
            this.Email = email;
            this.Budgets = new HashSet<Budgets>();
        }

        public new string Email { get; }

        public ICollection<Budgets> Budgets { get; }
    }
}
