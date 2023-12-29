using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.Income;

namespace BudgetBuddy.Domain.Models
{
    public class Incomes : Entity<int>
    {
        private static readonly IEnumerable<IncomeTypes> AllowedTypes
           = new IncomeTypesData().GetData().Cast<IncomeTypes>();

        private static readonly IEnumerable<Currencies> AllowedCurrencies
           = new CurrenciesData().GetData().Cast<Currencies>();

        public string UserId { get; }

        public decimal Amount { get; }

        public Currencies Currency { get; } = default!;

        public IncomeTypes Type { get; } = default!;

        public DateTime IncomeDate { get; }

        internal Incomes(string userId, decimal amount, Currencies currency, IncomeTypes type, DateTime incomeDate)
        {
            this.Validate(userId, amount, currency, type, incomeDate);

            this.UserId = userId;
            this.Amount = amount;
            this.Currency = currency;
            this.Type = type;
            this.IncomeDate = incomeDate;
        }

        private Incomes(string userId, decimal amount, DateTime incomeDate)
        {
            this.UserId = userId;
            this.Amount = amount;
            this.IncomeDate = incomeDate;
        }

        private void Validate(string userId, decimal amount, Currencies currency, IncomeTypes type, DateTime incomeDate)
        {
            this.ValidateUser(userId);
            this.ValidateAmount(amount);
            this.ValidateCurrency(currency);
            this.ValidateIncomeType(type);
            this.ValidateIncomeDate(incomeDate);
        }

        private void ValidateUser(string userId)
            => Guard.AgainstEmptyString<InvalidIncomeException>(userId, nameof(this.UserId));

        private void ValidateAmount(decimal amount)
            => Guard.AgainstOutOfRange<InvalidIncomeException>(amount, Zero, MaxAmountValue, nameof(this.Amount));

        private void ValidateIncomeDate(DateTime incomeDate)
             => Guard.AgainstEmptyDate<InvalidIncomeException>(incomeDate, nameof(this.IncomeDate));

        private void ValidateCurrency(Currencies currencies)
        {
            string? name = currencies?.Name;

            if (AllowedCurrencies.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedCurrencies.Select(c => $"'{c.Name}'"));

            throw new InvalidIncomeException($"'{name}' is not a valid currency. Allowed values are: {allowedNames}.");
        }

        private void ValidateIncomeType(IncomeTypes expenseType)
        {
            string? name = expenseType?.Name;

            if (AllowedTypes.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedTypes.Select(c => $"'{c.Name}'"));

            throw new InvalidIncomeException($"'{name}' is not a valid type. Allowed values are: {allowedNames}.");
        }
    }
}
