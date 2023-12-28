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
                .HasKey(b => b.Id);

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
        }
    }
}
