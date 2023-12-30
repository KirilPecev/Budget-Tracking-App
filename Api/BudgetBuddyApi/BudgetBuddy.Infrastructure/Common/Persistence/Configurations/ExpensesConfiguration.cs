using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class ExpensesConfiguration : IEntityTypeConfiguration<Expenses>
    {
        public void Configure(EntityTypeBuilder<Expenses> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .HasOne(b => b.Budget)
                .WithMany(b => b.Expenses)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.Amount)
                .IsRequired();

            builder
                .HasOne(b => b.Currency)
                .WithMany()
                .HasForeignKey("CurrencyCode")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.TransactionDateTime)
                .IsRequired();

            builder
                .HasOne(b => b.Type)
                .WithMany(b => b.Expenses)
                .HasForeignKey("ExpenseTypeId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired(false);

            builder
                .HasMany(b => b.Attachments)
                .WithOne(b => b.Expense)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Location)
                .WithMany(b => b.Expenses)
                .HasForeignKey("ExpenseLocationId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
