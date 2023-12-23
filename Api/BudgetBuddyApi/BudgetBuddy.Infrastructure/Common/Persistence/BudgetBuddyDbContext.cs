using BudgetBuddy.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Domain
{
    public class BudgetBuddyDbContext : IdentityDbContext<User, Role, string>
    {
        public BudgetBuddyDbContext(DbContextOptions<BudgetBuddyDbContext> options) : base(options) { }
    }
}
