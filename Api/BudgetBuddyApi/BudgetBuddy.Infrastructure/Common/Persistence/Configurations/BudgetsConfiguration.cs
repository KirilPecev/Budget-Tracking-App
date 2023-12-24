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
                .Property(b => b.TargetAmount)
                .IsRequired();
        }
    }
}
