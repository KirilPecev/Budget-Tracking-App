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
                .HasMany(u => u.Budgets)
                .WithOne()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
