using Microsoft.AspNetCore.Identity;

namespace BudgetBuddy.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        internal User(string email) : base(email)
           => this.Email = email;

        public new string Email { get; private set; }
    }
}
