using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Currency;

namespace BudgetBuddy.Domain.Models
{
    public class Currencies
    {
        public string Code { get; }

        public string Name { get; }

        public string? Symbol { get; }

        public ICollection<ExchangeRates> ExchangeRates { get; set; }

        internal Currencies(
            string name,
            string code,
            string? symbol)
        {
            this.Validate(name, code);

            this.Name = name;
            this.Code = code;
            this.Symbol = symbol;
            this.ExchangeRates = new HashSet<ExchangeRates>();
        }

        private void Validate(string name, string code)
        {
            Guard.ForStringLength<InvalidExpenseException>(
               name,
               MinNameLength,
               MaxNameLength,
               nameof(this.Name));

            Guard.ForStringLength<InvalidExpenseException>(
                code,
                MinCodeLength,
                MaxCodeLength,
                nameof(this.Code));
        }
    }
}
