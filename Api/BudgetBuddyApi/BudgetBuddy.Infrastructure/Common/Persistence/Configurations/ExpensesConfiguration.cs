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
                .Property(b => b.Amount)
                .IsRequired();

            builder
                .Property(b => b.TransactionDateTime)
                .IsRequired();

            builder
                .HasOne(b => b.Type)
                .WithMany()
                .HasForeignKey("ExpenseTypeId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired(false);
        }
    }
}
