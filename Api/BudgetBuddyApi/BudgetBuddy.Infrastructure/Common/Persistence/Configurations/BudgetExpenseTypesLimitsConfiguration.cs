using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class BudgetExpenseTypesLimitsConfiguration : IEntityTypeConfiguration<BudgetExpenseTypesLimits>
    {
        public void Configure(EntityTypeBuilder<BudgetExpenseTypesLimits> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .HasOne(b => b.Budget)
                .WithMany(b => b.Limits)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Type)
                .WithMany(b => b.Limits)
                .HasForeignKey("ExpenseType")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.Amount)
                .IsRequired();

            builder
                .HasOne(b => b.Currency)
                .WithMany()
                .HasForeignKey("CurrencyCode")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.AmountType)
                .HasMaxLength(AmountMaxLength)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_BudgetExpenseTypesLimits_AmountType", $"AmountType in ('{AmountTypeValue}', '{AmountTypePercent}')"));
        }
    }
}
