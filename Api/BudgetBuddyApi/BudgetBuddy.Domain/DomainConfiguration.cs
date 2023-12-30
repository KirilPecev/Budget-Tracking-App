using BudgetBuddy.Domain.Common;
using BudgetBuddy.Domain.Models;

using Microsoft.Extensions.DependencyInjection;

namespace BudgetBuddy.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .AddTransient<IInitialData, CurrenciesData>()
                .AddTransient<IInitialData, ExpenseTypesData>()
                .AddTransient<IInitialData, IncomeTypesData>();
    }
}
