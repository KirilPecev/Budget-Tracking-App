using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Currency;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class CurrenciesConfiguration : IEntityTypeConfiguration<Currencies>
    {
        public void Configure(EntityTypeBuilder<Currencies> builder)
        {
            builder
                .HasKey(b => b.Code);

            builder
                .HasIndex(c => c.Code)
                .IsUnique();

            builder
                .Property(b => b.Code)
                .HasMaxLength(MaxCodeLength)
                .IsRequired();

            builder
                .Property(b => b.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .Property(b => b.Symbol)
                .IsRequired(false);
        }
    }
}
