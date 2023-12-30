using BudgetBuddy.Domain.Common;
using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

namespace BudgetBuddy.Domain.Models
{
    public class BudgetSharing : Entity<int>, IAuditable
    {
        public Budgets Budget { get; } = default!;

        public string ReceiverId { get; }

        public DateTime SharedAt { get; }

        internal BudgetSharing(
            Budgets budget,
            string receiverId,
            DateTime sharedAt)
        {
            this.Validate(receiverId, sharedAt);

            this.Budget = budget;
            this.ReceiverId = receiverId;
            this.SharedAt = sharedAt;
        }

        private BudgetSharing(
            string receiverId,
            DateTime sharedAt)
        {
            this.ReceiverId = receiverId;
            this.SharedAt = sharedAt;
        }

        private void Validate(string receiverId, DateTime sharedAt)
        {
            Guard.AgainstEmptyString<InvalidBudgetException>(receiverId, nameof(this.ReceiverId));
            Guard.AgainstEmptyDate<InvalidBudgetException>(sharedAt, nameof(this.SharedAt));
        }
    }
}
