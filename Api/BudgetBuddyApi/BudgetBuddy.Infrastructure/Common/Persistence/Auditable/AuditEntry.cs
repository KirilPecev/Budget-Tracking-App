using BudgetBuddy.Domain.Common.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BudgetBuddy.Infrastructure.Common.Persistence.Auditable
{
    public class AuditEntry : Entity<int>
    {
        private const string InsertState = "INSERT";
        private const string DeleteState = "DELETE";
        private const string UpdateState = "UPDATE";

        public string EntityName { get; }

        public string ActionType { get; }

        public string UserId { get; }

        public DateTime TimeStamp { get; }

        public string EntityId { get; private set; } = default!;

        public Dictionary<string, object> Changes { get; }

        public List<PropertyEntry> TempProperties { get; }

        internal AuditEntry(EntityEntry entry, string userId)
        {
            EntityName = entry.Metadata.ClrType.Name;
            ActionType = entry.State == EntityState.Added ? InsertState : entry.State == EntityState.Deleted ? DeleteState : UpdateState;
            UserId = userId;
            TimeStamp = DateTime.UtcNow;
            EntityId = entry.Properties.Single(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString();
            Changes = entry.Properties.Select(p => new { p.Metadata.Name, p.CurrentValue }).ToDictionary(i => i.Name, i => i.CurrentValue);

            // TempProperties are properties that are only generated on save, e.g. ID's
            // These properties will be set correctly after the audited entity has been saved
            TempProperties = entry.Properties.Where(p => p.IsTemporary).ToList();
        }

        private AuditEntry(
            string entityName,
            string actionType,
            string userId,
            DateTime timeStamp,
            string entityId)
        {
            EntityName = entityName;
            ActionType = actionType;
            UserId = userId;
            TimeStamp = timeStamp;
            EntityId = entityId;
            Changes = new();
            TempProperties = new();
        }

        public void UpdateEntityId(string entityId)
        {
            this.EntityId = entityId;
        }
    }
}
