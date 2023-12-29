namespace BudgetBuddy.Domain.Common.Models
{
    internal static class Guard
    {
        private const string DefaultName = "Value";

        internal static void AgainstEmptyString<TException>(string value, string name = DefaultName)
           where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null or empty.");
        }

        internal static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = DefaultName)
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (value.Length >= minLength && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {minLength} and {maxLength} symbols.");
        }

        internal static void AgainstOutOfRange<TException>(int number, int min, int max, string name = DefaultName)
            where TException : BaseDomainException, new()
        {
            if (number >= min && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        internal static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = DefaultName)
            where TException : BaseDomainException, new()
        {
            if (number >= min && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        internal static void Against<TException>(object actualValue, object unexpectedValue, string name = DefaultName)
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}.");
        }

        internal static void AgainstEmptyDate<TException>(DateTime startDate, string name = DefaultName)
             where TException : BaseDomainException, new()
        {
            if (DateTime.MinValue != startDate)
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null or empty.");
        }

        public static void ForValidUrl<TException>(string url, string name = DefaultName)
            where TException : BaseDomainException, new()
        {
            if (url.Length <= ModelConstants.Common.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            ThrowException<TException>($"{name} must be a valid URL.");
        }

        private static void ThrowException<TException>(string message) where TException : BaseDomainException, new()
            => throw new TException { Message = message };
    }
}
