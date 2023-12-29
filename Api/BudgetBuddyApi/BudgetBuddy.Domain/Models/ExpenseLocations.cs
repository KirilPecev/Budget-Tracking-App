using BudgetBuddy.Domain.Common.Models;

namespace BudgetBuddy.Domain.Models
{
    public class ExpenseLocations : Entity<int>
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public string? Address { get; }

        public ICollection<Expenses> Expenses { get; }

        internal ExpenseLocations(double latitude, double longitude, string? address = default)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Address = address;
            this.Expenses = new HashSet<Expenses>();
        }
    }
}
