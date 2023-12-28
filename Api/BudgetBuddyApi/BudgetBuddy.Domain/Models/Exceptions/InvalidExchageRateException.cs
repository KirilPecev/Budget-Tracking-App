using BudgetBuddy.Domain.Common;

namespace BudgetBuddy.Domain.Models.Exceptions
{
    internal class InvalidExchageRateException : BaseDomainException
    {
        public InvalidExchageRateException() { }

        public InvalidExchageRateException(string message) => this.Message = message;
    }
}
