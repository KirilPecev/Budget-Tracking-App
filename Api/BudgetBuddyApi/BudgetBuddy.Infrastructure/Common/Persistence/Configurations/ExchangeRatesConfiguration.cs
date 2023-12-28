using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class ExchangeRatesConfiguration : IEntityTypeConfiguration<ExchangeRates>
    {
        public void Configure(EntityTypeBuilder<ExchangeRates> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .HasOne(b => b.FromCurrency)
                .WithMany(b => b.ExchangeRates)
                .HasForeignKey("FromCurrencyCode")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.ToCurrency)
                .WithMany()
                .HasForeignKey("ToCurrencyCode")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.Rate)
                .IsRequired();

            builder
                .Property(b => b.Date)
                .IsRequired();
        }
    }
}
