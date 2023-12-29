using BudgetBuddy.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Configurations
{
    public class ExpenseAttachmentsConfiguration : IEntityTypeConfiguration<ExpenseAttachments>
    {
        public void Configure(EntityTypeBuilder<ExpenseAttachments> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.BlobUrl)
                .HasMaxLength(MaxUrlLength)
                .IsRequired();

            builder
                .Property(b => b.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();

            builder
                .HasOne(b => b.Expense)
                .WithMany(b => b.Attachments);
        }
    }
}
