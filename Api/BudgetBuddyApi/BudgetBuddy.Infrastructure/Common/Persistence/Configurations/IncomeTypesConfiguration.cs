using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Income;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class IncomeTypesConfiguration : IEntityTypeConfiguration<IncomeTypes>
    {
        public void Configure(EntityTypeBuilder<IncomeTypes> builder)
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

            builder
                .HasMany(b => b.Incomes)
                .WithOne(b => b.Type)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
