using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Domain.Models
{
    public class ExpenseTypes
    {
        private static readonly IEnumerable<Currencies> AllowedCurrencies
           = new CurrenciesData().GetData().Cast<Currencies>();

        public string Name { get; }

        public string Description { get; }

        public decimal Amount { get; }

        public Currencies? Currency { get; }

        public string AmountType { get; }

        public ICollection<Expenses> Expenses { get; }

        public ICollection<BudgetExpenseTypesLimits> Limits { get; }

        internal ExpenseTypes(
            string name,
            string description,
            decimal amount,
            Currencies? currency,
            string amountType)
        {
            this.Validate(name, description, amount, currency, amountType);

            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Currency = currency;
            this.AmountType = amountType;
            this.Expenses = new HashSet<Expenses>();
            this.Limits = new HashSet<BudgetExpenseTypesLimits>();
        }

        private ExpenseTypes(
            string name,
            string description,
            decimal amount,
            string amountType)
        {
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.AmountType = amountType;
            this.Expenses = new HashSet<Expenses>();
            this.Limits = new HashSet<BudgetExpenseTypesLimits>();
        }

        private void Validate(string name, string description, decimal amount, Currencies currency, string amountType)
        {
            Guard.ForStringLength<InvalidExpenseException>(
               name,
               MinNameLength,
               MaxNameLength,
               nameof(this.Name));

            Guard.ForStringLength<InvalidExpenseException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));

            Guard.AgainstOutOfRange<InvalidExpenseException>(
               amount,
               Zero,
               MaxAmountValue,
               nameof(this.Amount));

            if (amountType != AmountTypeValue
               && amountType != AmountTypePercent)
            {
                throw new InvalidExpenseException($"Invalid {nameof(this.AmountType)} should be value: {AmountTypeValue} or percent: {AmountTypePercent}");
            }

            if (currency != null)
            {
                this.ValidateCurrency(currency);
            }
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
