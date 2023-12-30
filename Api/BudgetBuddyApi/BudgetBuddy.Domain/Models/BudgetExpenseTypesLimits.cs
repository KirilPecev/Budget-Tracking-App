using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Domain.Models
{
    public class BudgetExpenseTypesLimits : Entity<int>
    {
        private static readonly IEnumerable<ExpenseTypes> AllowedTypes
           = new ExpenseTypesData().GetData().Cast<ExpenseTypes>();

        private static readonly IEnumerable<Currencies> AllowedCurrencies
           = new CurrenciesData().GetData().Cast<Currencies>();

        public Budgets Budget { get; } = default!;

        public ExpenseTypes Type { get; } = default!;

        public decimal Amount { get; }

        public Currencies? Currency { get; }

        public string AmountType { get; }

        internal BudgetExpenseTypesLimits(
            Budgets budget,
            ExpenseTypes type,
            decimal amount,
            Currencies currency,
            string amountType)
        {
            this.Validate(type, amount, currency, amountType);

            this.Budget = budget;
            this.Type = type;
            this.Amount = amount;
            this.Currency = currency;
            this.AmountType = amountType;
        }

        private BudgetExpenseTypesLimits(
            decimal amount,
            string amountType)
        {
            this.Amount = amount;
            this.AmountType = amountType;
        }

        private void Validate(ExpenseTypes type, decimal amount, Currencies currency, string amountType)
        {
            this.ValidateExpenseType(type);

            Guard.AgainstOutOfRange<InvalidExpenseException>(
              amount,
              Zero,
              MaxAmountValue,
              nameof(this.Amount));

            if (amountType != AmountTypeValue
               || amountType != AmountTypePercent)
            {
                throw new InvalidExpenseException($"Invalid {nameof(this.AmountType)} should be value: {AmountTypeValue} or percent: {AmountTypePercent}");
            }

            if (currency != null)
            {
                this.ValidateCurrency(currency);
            }
        }

        private void ValidateExpenseType(ExpenseTypes expenseType)
        {
            string? name = expenseType?.Name;

            if (AllowedTypes.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedTypes.Select(c => $"'{c.Name}'"));

            throw new InvalidExpenseException($"'{name}' is not a valid type. Allowed values are: {allowedNames}.");
        }

        private void ValidateCurrency(Currencies currency)
        {
            string? name = currency?.Name;

            if (AllowedCurrencies.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedCurrencies.Select(c => $"'{c.Name}'"));

            throw new InvalidExpenseException($"'{name}' is not a valid currency. Allowed values are: {allowedNames}.");
        }
    }
}
