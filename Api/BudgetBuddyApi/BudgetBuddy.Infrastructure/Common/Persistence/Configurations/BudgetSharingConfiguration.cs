using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class BudgetSharingConfiguration : IEntityTypeConfiguration<BudgetSharing>
    {
        public void Configure(EntityTypeBuilder<BudgetSharing> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.ReceiverId)
                .IsRequired();

            builder
                .Property(b => b.SharedAt)
                .IsRequired();

            builder
                .HasOne(b => b.Budget)
                .WithMany(b => b.Sharings);
        }
    }
}
