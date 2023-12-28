using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Budget;

namespace BudgetBuddy.Domain.Models
{
    public class Budgets : Entity<int>
    {
        public string UserId { get; } = default!;

        public string Name { get; } = default!;

        public DateTime StartDate { get; }

        public DateTime? EndDate { get; }

        public decimal TargetAmount { get; }

        public decimal? CurrentAmount { get; }

        public bool IsActive { get; }

        public bool IsShared { get; }

        public DateTime CreatedOn { get; }

        public DateTime? LastUpdated { get; }

        internal Budgets(
            string userId,
            string name,
            DateTime startDate,
            decimal targetAmount)
        {
            this.Validate(userId, name, startDate, targetAmount);

            this.UserId = userId;
            this.Name = name;
            this.StartDate = startDate;
            this.TargetAmount = targetAmount;
            this.CurrentAmount = Zero;
            this.IsActive = true;
            this.IsShared = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        private void Validate(string userId, string name, DateTime startDate, decimal targetAmount)
        {
            this.ValidateUser(userId);
            this.ValidateName(name);
            this.ValidateStartDate(startDate);
            this.ValidateTargetAmount(targetAmount);
        }

        private void ValidateUser(string userId)
            => Guard.AgainstEmptyString<InvalidBudgetException>(userId, nameof(this.UserId));

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidBudgetException>(name, MinNameLength, MaxNameLength, nameof(this.Name));

        private void ValidateStartDate(DateTime startDate)
             => Guard.AgainstEmptyDate<InvalidBudgetException>(startDate, nameof(this.StartDate));

        private void ValidateTargetAmount(decimal targetAmount)
            => Guard.AgainstOutOfRange<InvalidBudgetException>(targetAmount, Zero, TargetAmountMaxValue, nameof(this.TargetAmount));
    }
}
