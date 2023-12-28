namespace BudgetBuddy.Domain.Common
{
    internal interface IInitialData
    {
        Type EntityType { get; }

        IEnumerable<object> GetData();
    }
}
