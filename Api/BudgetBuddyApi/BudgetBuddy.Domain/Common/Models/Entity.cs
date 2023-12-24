namespace BudgetBuddy.Domain.Common.Models
{
    public class Entity<TId>
        where TId : struct
    {
        public TId Id { get; private set; }
    }
}
