using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Budget;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;

namespace BudgetBuddy.Domain.Models
{
    public class Budgets : Entity<int>
    {
        private static readonly IEnumerable<Currencies> AllowedCurrencies
           = new CurrenciesData().GetData().Cast<Currencies>();

        public string UserId { get; } = default!;

        public string Name { get; } = default!;

        public DateTime StartDate { get; }

        public DateTime? EndDate { get; }

        public decimal TargetAmount { get; }

        public decimal? CurrentAmount { get; }

        public Currencies Currency { get; } = default!;

        public bool IsActive { get; }

        public bool IsShared { get; }

        public DateTime CreatedOn { get; }

        public DateTime? LastUpdated { get; }

        public ICollection<Expenses> Expenses { get; }

        internal Budgets(
            string userId,
            string name,
            DateTime startDate,
            decimal targetAmount,
            Currencies currency)
        {
            this.Validate(userId, name, startDate, targetAmount, currency);

            this.UserId = userId;
            this.Name = name;
            this.StartDate = startDate;
            this.TargetAmount = targetAmount;
            this.CurrentAmount = Zero;
            this.IsActive = true;
            this.IsShared = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Currency = currency;
            this.Expenses = new HashSet<Expenses>();
        }

        // This ctor is used for scaffolding to avoid error:
        // The exception 'No suitable constructor was found for entity type 'Budgets'.
        // The following constructors had parameters that could not be bound to properties of the entity type: 
        // Cannot bind 'currency' in 'Budgets( string userId, string name, DateTime startDate, decimal targetAmount, Currencies currency)'
        private Budgets(
            string userId,
            string name,
            DateTime startDate,
            decimal targetAmount)
        {
            this.UserId = userId;
            this.Name = name;
            this.StartDate = startDate;
            this.TargetAmount = targetAmount;
            this.CurrentAmount = Zero;
            this.IsActive = true;
            this.IsShared = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Expenses = new HashSet<Expenses>();
        }

        private void Validate(string userId, string name, DateTime startDate, decimal targetAmount, Currencies currency)
        {
            this.ValidateUser(userId);
            this.ValidateName(name);
            this.ValidateStartDate(startDate);
            this.ValidateTargetAmount(targetAmount);
            this.ValidateCurrency(currency);
        }

        private void ValidateUser(string userId)
            => Guard.AgainstEmptyString<InvalidBudgetException>(userId, nameof(this.UserId));

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidBudgetException>(name, MinNameLength, MaxNameLength, nameof(this.Name));

        private void ValidateStartDate(DateTime startDate)
             => Guard.AgainstEmptyDate<InvalidBudgetException>(startDate, nameof(this.StartDate));

        private void ValidateTargetAmount(decimal targetAmount)
            => Guard.AgainstOutOfRange<InvalidBudgetException>(targetAmount, Zero, TargetAmountMaxValue, nameof(this.TargetAmount));

        private void ValidateCurrency(Currencies currencies)
        {
            string? name = currencies?.Name;

            if (AllowedCurrencies.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedCurrencies.Select(c => $"'{c.Name}'"));

            throw new InvalidBudgetException($"'{name}' is not a valid currency. Allowed values are: {allowedNames}.");
        }
    }
}
