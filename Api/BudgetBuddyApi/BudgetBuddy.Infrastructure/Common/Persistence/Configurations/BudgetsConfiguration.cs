using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Budget;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class BudgetsConfiguration : IEntityTypeConfiguration<Budgets>
    {
        public void Configure(EntityTypeBuilder<Budgets> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.UserId)
                .IsRequired();

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(b => b.StartDate)
                .IsRequired();

            builder
                .Property(b => b.EndDate)
                .IsRequired(false);

            builder
                .Property(b => b.TargetAmount)
                .IsRequired();

            builder
                .Property(b => b.CurrentAmount)
                .IsRequired(false);

            builder
                .Property(b => b.IsActive)
                .IsRequired();

            builder
                .Property(b => b.IsShared)
                .IsRequired();

            builder
                .Property(b => b.CreatedOn)
                .IsRequired();

            builder
                .Property(b => b.LastUpdated)
                .IsRequired(false);
        }
    }
}
