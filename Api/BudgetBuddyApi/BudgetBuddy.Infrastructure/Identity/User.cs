using BudgetBuddy.Domain.Models;
using BudgetBuddy.Infrastructure.Identity.Enums;

using Microsoft.AspNetCore.Identity;

namespace BudgetBuddy.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        internal User(
            string email,
            string language,
            string country,
            string currency)
            : base(email)
        {
            this.Email = email;
            this.Language = language;
            this.Country = country;
            this.Currency = currency;
            this.NotificationsEnabled = false;
            this.Theme = Theme.Default;
            this.DateFormat = "MM/dd/yyyy";
            this.TimeFormat = "HH:mm";
            this.Budgets = new HashSet<Budgets>();
            this.SharedBudgets = new HashSet<BudgetSharing>();
            this.Incomes = new HashSet<Incomes>();
        }

        public new string Email { get; }

        public string Language { get; set; }

        public string Country { get; set; }

        public string Currency { get; set; }

        public bool NotificationsEnabled { get; set; }

        public Theme Theme { get; set; }

        public string DateFormat { get; set; }

        public string TimeFormat { get; set; }

        public ICollection<Budgets> Budgets { get; }

        public ICollection<BudgetSharing> SharedBudgets { get; }

        public ICollection<Incomes> Incomes { get; }
    }
}
