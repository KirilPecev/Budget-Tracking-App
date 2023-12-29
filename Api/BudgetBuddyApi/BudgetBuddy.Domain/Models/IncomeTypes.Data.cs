using BudgetBuddy.Domain.Common;

namespace BudgetBuddy.Domain.Models
{
    internal class IncomeTypesData : IInitialData
    {
        public Type EntityType => typeof(IncomeTypes);

        public IEnumerable<object> GetData()
           => new List<IncomeTypes>
           {
                new IncomeTypes("Salary", "Regular income received as part of employment, often on a monthly or bi-weekly basis."),
                new IncomeTypes("Freelance/Contract Income", "Income earned through freelancing or contract work."),
                new IncomeTypes("Business Income", "Profits generated from a business or self-employment."),
                new IncomeTypes("Bonuses", "Additional payments beyond the regular salary, often based on performance or achievements."),
                new IncomeTypes("Overtime Pay", "Additional compensation for working beyond regular working hours."),
                new IncomeTypes("Commission", "Income earned as a percentage of sales or transactions."),
                new IncomeTypes("Investment Income", "Earnings from investments, such as dividends, interest, or capital gains."),
                new IncomeTypes("Rental Income", "Income generated from renting out property."),
                new IncomeTypes("Side Hustle Income", "Income earned from part-time or side business activities.")
           };
    }
}
