using BudgetBuddy.Domain.Common;

namespace BudgetBuddy.Domain.Models.Exceptions
{
    internal class InvalidBudgetException : BaseDomainException
    {
        public InvalidBudgetException() { }

        public InvalidBudgetException(string message) => this.Message = message;
    }
}
