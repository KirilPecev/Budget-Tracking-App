namespace BudgetBuddy.Domain.Common.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class User
        {
            public const int MinEmailLength = 5;
            public const int MaxEmailLength = 50;
            public const int MaxPasswordLength = 100;
            public const int MinUsernameLength = 1;
            public const int MaxUsernameLength = 100;
        }

        public class Budget
        {
            public const int MinNameLength = 1;
            public const int MaxNameLength = 100;
            public const decimal TargetAmountMaxValue = decimal.MaxValue;
        }

        public class Expense
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;

            public const decimal MaxAmountValue = decimal.MaxValue;

            public const int MinDescriptionLength = 5;
            public const int MaxDescriptionLength = 1000;
        }

        public class Currency
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;

            public const int MinCodeLength = 3;
            public const int MaxCodeLength = 3;
        }

        public class ExchangeRate
        {
            public const decimal MaxRateValue = decimal.MaxValue;
        }

        public class Income
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;

            public const decimal MaxAmountValue = decimal.MaxValue;

            public const int MinDescriptionLength = 5;
            public const int MaxDescriptionLength = 1000;
        }
    }
}
