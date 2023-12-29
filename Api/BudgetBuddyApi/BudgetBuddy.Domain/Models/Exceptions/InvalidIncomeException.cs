using BudgetBuddy.Domain.Common;

namespace BudgetBuddy.Domain.Models.Exceptions
{
    internal class InvalidIncomeException : BaseDomainException
    {
        public InvalidIncomeException() { }

        public InvalidIncomeException(string message) => this.Message = message;
    }
}
