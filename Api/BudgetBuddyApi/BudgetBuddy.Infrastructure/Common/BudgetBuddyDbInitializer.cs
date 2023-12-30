using System.Reflection;

using BudgetBuddy.Domain.Common;
using BudgetBuddy.Infrastructure.Common.Persistence;
using BudgetBuddy.Infrastructure.Identity;
using BudgetBuddy.Infrastructure.Identity.Seeders;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infrastructure.Common
{
    internal class BudgetBuddyDbInitializer : IInitializer
    {
        private readonly BudgetBuddyDbContext db;
        private readonly IEnumerable<IInitialData> initialDataProviders;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public BudgetBuddyDbInitializer(
            BudgetBuddyDbContext db,
            IEnumerable<IInitialData> initialDataProviders,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            this.db = db;
            this.initialDataProviders = initialDataProviders;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();

            foreach (IInitialData provider in initialDataProviders)
            {
                if (this.IsDateSetEmpty(provider.EntityType))
                {
                    IEnumerable<object> data = provider.GetData();

                    foreach (object entity in data)
                    {
                        this.db.Add(entity);
                    }
                }
            }

            IdentityUserSeeder.SeedData(this.userManager, this.roleManager);

            this.db.SaveChanges();
        }

        private bool IsDateSetEmpty(Type type)
        {
            MethodInfo setMethod = GetType()
                .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(type);

            object? set = setMethod.Invoke(this, Array.Empty<object>());

            MethodInfo countMethod = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
                .MakeGenericMethod(type);

            int result = (int)countMethod.Invoke(null, new[] { set })!;

            return result == 0;
        }

        private DbSet<TEntity> GetSet<TEntity>()
           where TEntity : class
           => this.db.Set<TEntity>();
    }
}
