using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class ExpenseTypesConfiguration : IEntityTypeConfiguration<ExpenseTypes>
    {
        public void Configure(EntityTypeBuilder<ExpenseTypes> builder)
        {
            builder
                .HasKey(b => b.Name);

            builder
                .HasIndex(c => c.Name)
                .IsUnique();

            builder
                .Property(b => b.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .Property(b => b.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();

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

            builder.ToTable(t => t.HasCheckConstraint("CK_ExpenseTypes_AmountType", $"AmountType in ('{AmountTypeValue}', '{AmountTypePercent}')"));

            builder
                .HasMany(b => b.Expenses)
                .WithOne(b => b.Type)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(b => b.Limits)
               .WithOne(b => b.Type)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
