using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infrastructure.Identity.Configurations
{
    public class BudgetsConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Email)
                .IsRequired();

            builder
              .Property(u => u.Language)
              .IsRequired();

            builder
                .Property(u => u.Country)
                .IsRequired();

            builder
                .Property(u => u.Currency)
                .IsRequired();

            builder
                .Property(u => u.NotificationsEnabled)
                .IsRequired();

            builder
                .Property(u => u.Theme)
                .IsRequired();

            builder
                .Property(u => u.DateFormat)
                .IsRequired();

            builder
                .Property(u => u.TimeFormat)
                .IsRequired();

            builder
                .HasMany(u => u.Budgets)
                .WithOne()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
