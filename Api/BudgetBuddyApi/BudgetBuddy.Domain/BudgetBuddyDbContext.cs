using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Domain
{
    public class BudgetBuddyDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public BudgetBuddyDbContext(DbContextOptions<BudgetBuddyDbContext> options) : base(options) { }
    }
}
