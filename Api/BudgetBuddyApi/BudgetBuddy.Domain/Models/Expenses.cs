using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Domain.Models
{
    public class Expenses : Entity<int>
    {
        private static readonly IEnumerable<ExpenseTypes> AllowedTypes
           = new ExpenseTypesData().GetData().Cast<ExpenseTypes>();

        public int BudgetId { get; }

        public decimal Amount { get; }

        public DateTime TransactionDateTime { get; }

        public ExpenseTypes Type { get; set; } = default!;

        public string? Description { get; }

        internal Expenses(
            decimal amount,
            DateTime transactionDateTime,
            ExpenseTypes type,
            string? description = default)
        {
            this.Validate(amount, transactionDateTime, type);

            this.Amount = amount;
            this.TransactionDateTime = transactionDateTime;
            this.Type = type;
            this.Description = description;
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
        }

        private void Validate(decimal amount, DateTime transactionDateTime, ExpenseTypes type)
        {
            this.ValidateAmount(amount);
            this.ValidateTransactionDateTime(transactionDateTime);
            this.ValidateExpenseType(type);
        }

        private void ValidateAmount(decimal amount)
            => Guard.AgainstOutOfRange<InvalidExpenseException>(amount, Zero, MaxAmountValue, nameof(this.Amount));

        private void ValidateTransactionDateTime(DateTime transactionDateTime)
             => Guard.AgainstEmptyDate<InvalidExpenseException>(transactionDateTime, nameof(this.TransactionDateTime));

        private void ValidateExpenseType(ExpenseTypes expenseType)
        {
            string? name = expenseType?.Name;

            if (AllowedTypes.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedTypes.Select(c => $"'{c.Name}'"));

            throw new InvalidExpenseException($"'{name}' is not a valid category. Allowed values are: {allowedNames}.");
        }
    }
}
