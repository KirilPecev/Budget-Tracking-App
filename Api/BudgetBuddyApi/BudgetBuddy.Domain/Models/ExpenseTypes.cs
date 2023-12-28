using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Expense;

namespace BudgetBuddy.Domain.Models
{
    public class ExpenseTypes : Entity<int>
    {
        public string Name { get; }

        public string Description { get; }

        internal ExpenseTypes(string name, string description)
        {
            this.Validate(name, description);

            Name = name;
            Description = description;
        }

        private void Validate(string name, string description)
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
        }
    }
}
