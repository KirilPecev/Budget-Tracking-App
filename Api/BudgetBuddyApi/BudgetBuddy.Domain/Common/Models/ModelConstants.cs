namespace BudgetBuddy.Domain.Common.Models
{
    public class ModelConstants
    {
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
            public const int Zero = 0;
            public const decimal TargetAmountMaxValue = decimal.MaxValue;
        }
    }
}
