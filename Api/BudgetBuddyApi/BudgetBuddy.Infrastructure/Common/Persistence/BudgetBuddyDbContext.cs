using System.Reflection;
using System.Security.Claims;

using BudgetBuddy.Domain.Common;
using BudgetBuddy.Domain.Models;
using BudgetBuddy.Infrastructure.Common.Persistence.Auditable;
using BudgetBuddy.Infrastructure.Identity;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infrastructure.Common.Persistence
{
    public class BudgetBuddyDbContext : IdentityDbContext<User, Role, string>
    {
        private readonly string userId;

        public BudgetBuddyDbContext(
            DbContextOptions<BudgetBuddyDbContext> options,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            ClaimsPrincipal? user = httpContextAccessor.HttpContext?.User;
            this.userId = user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Unauthenticated user";
        }

        public DbSet<Budgets> Budgets { get; set; } = default!;

        public DbSet<BudgetSharing> BudgetSharing { get; set; } = default!;

        public DbSet<BudgetExpenseTypesLimits> BudgetExpenseTypesLimits { get; set; } = default!;

        public DbSet<Expenses> Expenses { get; set; } = default!;

        public DbSet<ExpenseTypes> ExpenseTypes { get; set; } = default!;

        public DbSet<ExpenseAttachments> ExpenseAttachments { get; set; } = default!;

        public DbSet<ExpenseLocations> ExpenseLocations { get; set; } = default!;

        public DbSet<Currencies> Currencies { get; set; } = default!;

        public DbSet<ExchangeRates> ExchangeRates { get; set; } = default!;

        public DbSet<Incomes> Incomes { get; set; } = default!;

        public DbSet<IncomeTypes> IncomeTypes { get; set; } = default!;

        public DbSet<AuditEntry> AuditEntries { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            List<AuditEntry> auditEntries = this.OnBeforeSaveChanges();

            int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            await this.OnAfterSaveChangesAsync(auditEntries);

            return result;
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            List<AuditEntry> entries = new();

            foreach (var entry in this.ChangeTracker.Entries())
            {
                // Dot not audit entities that are not tracked, not changed, or not of type IAuditable
                if (entry.State == EntityState.Detached
                    || entry.State == EntityState.Unchanged
                    || !(entry.Entity is IAuditable))
                    continue;

                AuditEntry auditEntry = new AuditEntry(entry, userId);

                entries.Add(auditEntry);
            }

            return entries;
        }

        private Task OnAfterSaveChangesAsync(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0) return Task.CompletedTask;

            // For each temporary property in each audit entry - update the value in the audit entry to the actual (generated) value
            foreach (var entry in auditEntries)
            {
                foreach (var prop in entry.TempProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        entry.UpdateEntityId(prop.CurrentValue.ToString());
                    }

                    entry.Changes[prop.Metadata.Name] = prop.CurrentValue;
                }
            }

            this.AuditEntries.AddRange(auditEntries);

            return SaveChangesAsync();
        }
    }
}
