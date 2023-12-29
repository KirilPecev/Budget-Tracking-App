using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Income;

namespace BudgetBuddy.Domain.Models
{
    public class IncomeTypes : Entity<int>
    {
        public string Name { get; }

        public string Description { get; }

        public ICollection<Incomes> Incomes { get; }

        internal IncomeTypes(string name, string description)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
            this.Incomes = new HashSet<Incomes>();
        }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidIncomeException>(
               name,
               MinNameLength,
               MaxNameLength,
               nameof(this.Name));

            Guard.ForStringLength<InvalidIncomeException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
