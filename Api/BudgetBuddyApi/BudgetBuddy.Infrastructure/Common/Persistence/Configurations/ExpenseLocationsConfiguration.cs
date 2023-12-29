using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class ExpenseLocationsConfiguration : IEntityTypeConfiguration<ExpenseLocations>
    {
        public void Configure(EntityTypeBuilder<ExpenseLocations> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Latitude)
                .IsRequired();

            builder
                .Property(b => b.Longitude)
                .IsRequired();

            builder
                .Property(b => b.Address)
                .IsRequired(false);

            builder
                .HasMany(b => b.Expenses)
                .WithOne(b => b.Location);
        }
    }
}
