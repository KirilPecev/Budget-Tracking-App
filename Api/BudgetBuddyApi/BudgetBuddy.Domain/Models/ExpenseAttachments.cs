using BudgetBuddy.Domain.Common;
using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Domain.Models
{
    public class ExpenseAttachments : Entity<int>, IAuditable
    {
        public Expenses Expense { get; } = default!;

        public string BlobUrl { get; }

        public string Description { get; }

        internal ExpenseAttachments(Expenses expense, string blobUrl, string description)
        {
            this.Validate(blobUrl, description);

            this.Expense = expense;
            this.BlobUrl = blobUrl;
            this.Description = description;
        }

        private ExpenseAttachments(string blobUrl, string description)
        {
            this.BlobUrl = blobUrl;
            this.Description = description;
        }

        private void Validate(string blobUrl, string description)
        {
            Guard.ForValidUrl<InvalidExpenseException>(
               blobUrl,
               nameof(this.BlobUrl));

            Guard.ForStringLength<InvalidExpenseException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
