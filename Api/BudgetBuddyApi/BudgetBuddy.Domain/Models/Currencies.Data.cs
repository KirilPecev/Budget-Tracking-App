using BudgetBuddy.Domain.Common;

namespace BudgetBuddy.Domain.Models
{
    internal class CurrenciesData : IInitialData
    {
        public Type EntityType => typeof(Currencies);

        public IEnumerable<object> GetData()
           => new List<Currencies>
           {
                new Currencies("Bulgarian Lev", "BGN", "лв"),
                new Currencies("US Dollar", "USD", "$"),
                new Currencies("Euro", "EUR", "€"),
                new Currencies("Japanese Yen", "JPY", "¥"),
                new Currencies("British Pound", "GBP", "£"),
                new Currencies("Swiss Franc", "CHF", "CHF"),
                new Currencies("Canadian Dollar", "CAD", "CA$"),
                new Currencies("Australian Dollar", "AUD", "A$"),
                new Currencies("Chinese Yuan", "CNY", "¥"),
                new Currencies("Indian Rupee", "INR", "₹"),
                new Currencies("Brazilian Real", "BRL", "R$")
           };
    }
}
