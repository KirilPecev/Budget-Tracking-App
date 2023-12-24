using BudgetBuddy.Domain.Common.Models;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Budget;

namespace BudgetBuddy.Domain.Models
{
    public class Budgets : Entity<int>
    {
        public string UserId { get; } = default!;

        public string Name { get; } = default!;

        public DateTime StartDate { get; }

        public DateTime? EndDate { get; }

        public double TargetAmount { get; }

        public double? CurrentAmount { get; }

        public bool IsActive { get; }

        public bool IsShared { get; }

        public DateTime CreatedOn { get; }

        public DateTime? LastUpdated { get; }

        internal Budgets(
            string userId,
            string name,
            DateTime startDate,
            double targetAmount)
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

        private void Validate(string userId, string name, DateTime startDate, double targetAmount)
        {

        }
    }
}
