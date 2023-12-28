using BudgetBuddy.Domain.Common;

namespace BudgetBuddy.Domain.Models
{
    internal class ExpenseTypesData : IInitialData
    {
        public Type EntityType => typeof(ExpenseTypes);

        public IEnumerable<object> GetData()
           => new List<ExpenseTypes>
           {
                new ExpenseTypes("Housing", "The amount you pay to have a roof over your head constitutes a housing cost. This includes everything from rent or mortgage payments to property taxes, HOA dues, and home maintenance costs. For most budgeters, this category is by far the biggest."),
                new ExpenseTypes("Transportation", "Regardless of your location or lifestyle, everyone needs to get from point A to point B. Typically, this budget category includes car payments, registration and DMV fees, gas, maintenance, parking, tolls, ridesharing costs, and public transit."),
                new ExpenseTypes("Food", "While food is a survival necessity for humans, it’s also a budget area for the savvy financial planner. Whether you’re grocery shopping and cooking at home, or sampling the culinary scene in your geographic locale, it’s crucial to account for food expenses. Many budgeters include grocery shopping and dining out in this category (e.g., restaurant meals, work lunches, food delivery, etc.)."),
                new ExpenseTypes("Utilities", "Utilities generally include your gas, electricity, water, and sewage bills. Households can also factor in their “connectivity” expenses, like your cell phone bill, cable or streaming services, and internet expenses."),
                new ExpenseTypes("Insurance", "As the old adage goes, “health is wealth.” Maintaining both your health and overall well-being are essential, so it’s critical to include enough in your budget to cover these costs. If you plan for routine medical care, like yearly physicals, dental appointments, and mental health care, you’ll live a much healthier life in the long run."),
                new ExpenseTypes("Medical & Healthcare", "Dedicated to managing expenses related to your health and well-being. This category encompasses a range of healthcare-related costs, ensuring that you can prioritize your physical and mental well-being without financial stress."),
                new ExpenseTypes("Saving, Investing, & Debt Payments", "Designed to empower you in achieving your financial goals, building a secure future, and managing debt responsibly. This comprehensive category covers a spectrum of financial activities aimed at both saving for the future and strategically managing existing debts."),
                new ExpenseTypes("Personal Spending", "This category is a catch-all for anything that could be considered a personal care or “lifestyle” expense."),
                new ExpenseTypes("Recreation & Entertainment", "It’s extremely important to have fun — we’re definitely advocates for a good time! Your recreation and entertainment category is how much you’ll spend for your leisure time, and it’s best to be mindful and moderate in this particular category."),
                new ExpenseTypes("Miscellaneous", "This budget category is reserved for anything that isn’t already covered in your basic budget categories. It can also be used as an “overflow” category when you need a little extra somewhere else."),
           };
    }
}
