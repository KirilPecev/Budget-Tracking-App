using System.Reflection;

using BudgetBuddy.Domain.Models;
using BudgetBuddy.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infrastructure.Common.Persistence
{
    public class BudgetBuddyDbContext : IdentityDbContext<User, Role, string>
    {
        public BudgetBuddyDbContext(DbContextOptions<BudgetBuddyDbContext> options) : base(options) { }

        public DbSet<Budgets> Budgets { get; set; } = default!;

        public DbSet<Expenses> Expenses { get; set; } = default!;

        public DbSet<ExpenseTypes> ExpenseTypes { get; set; } = default!;

        public DbSet<ExpenseAttachments> ExpenseAttachments { get; set; } = default!;

        public DbSet<Currencies> Currencies { get; set; } = default!;

        public DbSet<ExchangeRates> ExchangeRates { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
