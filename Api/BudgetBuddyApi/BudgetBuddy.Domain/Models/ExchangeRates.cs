using BudgetBuddy.Domain.Common.Models;
using BudgetBuddy.Domain.Models.Exceptions;

using static BudgetBuddy.Domain.Common.Models.ModelConstants.Common;
using static BudgetBuddy.Domain.Common.Models.ModelConstants.ExchangeRate;

namespace BudgetBuddy.Domain.Models
{
    public class ExchangeRates : Entity<int>
    {
        private static readonly IEnumerable<Currencies> AllowedCurrencies
           = new CurrenciesData().GetData().Cast<Currencies>();

        public Currencies FromCurrency { get; } = default!;

        public Currencies ToCurrency { get; } = default!;

        public decimal Rate { get; }

        public DateTime Date { get; }

        internal ExchangeRates(
            Currencies fromCurrency,
            Currencies toCurrency,
            decimal rate,
            DateTime date)
        {
            this.Validate(fromCurrency, toCurrency, rate, date);

            this.FromCurrency = fromCurrency;
            this.ToCurrency = toCurrency;
            this.Rate = rate;
            this.Date = date;
        }

        // This ctor is used for scaffolding to avoid error:
        // The exception 'No suitable constructor was found for entity type 'ExchangeRates'.
        // The following constructors had parameters that could not be bound to properties of the entity type: 
        // Cannot bind 'fromCurrency', 'toCurrency' in 'ExchangeRates(Currencies fromCurrency, Currencies toCurrency, decimal rate, DateTime date)'
        private ExchangeRates(
            decimal rate,
            DateTime date)
        {
            this.Rate = rate;
            this.Date = date;
        }

        private void Validate(Currencies fromCurrency, Currencies toCurrency, decimal rate, DateTime date)
        {
            this.ValidateCurrency(fromCurrency);
            this.ValidateCurrency(toCurrency);

            Guard.AgainstOutOfRange<InvalidExchageRateException>(rate, Zero, MaxRateValue, nameof(this.Rate));
            Guard.AgainstEmptyDate<InvalidExchageRateException>(date, nameof(this.Date));
        }

        private void ValidateCurrency(Currencies currencies)
        {
            string? name = currencies?.Name;

            if (AllowedCurrencies.Any(c => c.Name == name)) return;

            string allowedNames = string.Join(", ", AllowedCurrencies.Select(c => $"'{c.Name}'"));

            throw new InvalidExchageRateException($"'{name}' is not a valid currency. Allowed values are: {allowedNames}.");
        }
    }
}
