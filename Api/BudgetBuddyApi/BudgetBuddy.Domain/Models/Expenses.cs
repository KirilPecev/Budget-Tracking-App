﻿using BudgetBuddy.Domain.Common;
using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Domain.Models
{
    public class Expenses : Entity<int>, IAuditable
    {
        private static readonly IEnumerable<ExpenseTypes> AllowedTypes
           = new ExpenseTypesData().GetData().Cast<ExpenseTypes>();

        private static readonly IEnumerable<Currencies> AllowedCurrencies
           = new CurrenciesData().GetData().Cast<Currencies>();

        public Budgets Budget { get; } = default!;

        public decimal Amount { get; }

        public Currencies Currency { get; } = default!;

        public DateTime TransactionDateTime { get; }

        public ExpenseTypes Type { get; } = default!;

        public string? Description { get; }

        public ExpenseLocations Location { get; } = default!;

        public ICollection<ExpenseAttachments> Attachments { get; }

        internal Expenses(
            Budgets budget,
            decimal amount,
            Currencies currency,
            DateTime transactionDateTime,
            ExpenseTypes type,
            ExpenseLocations location,
            string? description = default)
        {
            this.Validate(amount, currency, transactionDateTime, type);

            this.Budget = budget;
            this.Amount = amount;
            this.Currency = currency;
            this.TransactionDateTime = transactionDateTime;
            this.Type = type;
            this.Description = description;
            this.Location = location;
            this.Attachments = new HashSet<ExpenseAttachments>();
        }

        // This ctor is used for scaffolding to avoid error:
        // The exception 'No suitable constructor was found for entity type 'Expenses'.
        // The following constructors had parameters that could not be bound to properties of the entity type: 
        // Cannot bind 'type' in 'Expenses(decimal amount, DateTime transactionDateTime, ExpenseTypes type, string description)'
        private Expenses(
            decimal amount,
            DateTime transactionDateTime,
            string? description = default)
        {
            this.Amount = amount;
            this.TransactionDateTime = transactionDateTime;
            this.Description = description;
            this.Attachments = new HashSet<ExpenseAttachments>();
        }

        private void Validate(decimal amount, Currencies currency, DateTime transactionDateTime, ExpenseTypes type)
        {
            this.ValidateAmount(amount);
            this.ValidateCurrency(currency);
            this.ValidateTransactionDateTime(transactionDateTime);
            this.ValidateExpenseType(type);
        }

        private void ValidateAmount(decimal amount)
            => Guard.AgainstOutOfRange<InvalidExpenseException>(amount, Zero, MaxAmountValue, nameof(this.Amount));

        private void ValidateTransactionDateTime(DateTime transactionDateTime)
             => Guard.AgainstEmptyDate<InvalidExpenseException>(transactionDateTime, nameof(this.TransactionDateTime));

        private void ValidateCurrency(Currencies currencies)
        {
            string? name = currencies?.Name;

            if (AllowedCurrencies.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedCurrencies.Select(c => $"'{c.Name}'"));

            throw new InvalidExpenseException($"'{name}' is not a valid currency. Allowed values are: {allowedNames}.");
        }

        private void ValidateExpenseType(ExpenseTypes expenseType)
        {
            string? name = expenseType?.Name;

            if (AllowedTypes.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedTypes.Select(c => $"'{c.Name}'"));

            throw new InvalidExpenseException($"'{name}' is not a valid type. Allowed values are: {allowedNames}.");
        }
    }
}
