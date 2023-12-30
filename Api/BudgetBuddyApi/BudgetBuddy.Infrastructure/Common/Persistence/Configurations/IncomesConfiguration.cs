using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class IncomesConfiguration : IEntityTypeConfiguration<Incomes>
    {
        public void Configure(EntityTypeBuilder<Incomes> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
               .Property(b => b.UserId)
               .IsRequired();

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
                .Property(b => b.IncomeDate)
                .IsRequired();

            builder
                .HasOne(b => b.Type)
                .WithMany(b => b.Incomes)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
