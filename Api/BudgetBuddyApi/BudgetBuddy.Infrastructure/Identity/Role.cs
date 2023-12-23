using Microsoft.AspNetCore.Identity;

namespace BudgetBuddy.Infrastructure.Identity
{
    public class Role : IdentityRole
    {
        internal Role(string name, string description) : base(name)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Description { get; private set; }
    }
}
