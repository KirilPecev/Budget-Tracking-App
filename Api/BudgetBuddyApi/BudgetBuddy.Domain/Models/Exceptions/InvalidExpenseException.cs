using BudgetBuddy.Domain.Common;

namespace BudgetBuddy.Domain.Models.Exceptions
{
    internal class InvalidExpenseException : BaseDomainException
    {
        public InvalidExpenseException() { }

        public InvalidExpenseException(string message) => this.Message = message;
    }
}
