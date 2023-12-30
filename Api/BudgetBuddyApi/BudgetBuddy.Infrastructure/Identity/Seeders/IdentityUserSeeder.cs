namespace BudgetBuddy.Infrastructure.Identity.Seeders
{
    using Microsoft.AspNetCore.Identity;

    using static BudgetBuddy.Application.Identity.Common.UserRoles;

    internal static class IdentityUserSeeder
    {
        private static Dictionary<string, string> roles = new()
        {
            { User, UserDescription },
            { Administrator, AdministratorDescription }
        };

        public static void SeedData(
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedRoles(RoleManager<Role> roleManager)
        {
            foreach (var item in roles)
            {
                bool exists = roleManager.RoleExistsAsync(item.Key).Result;

                if (!exists)
                {
                    Role role = new Role(item.Key, item.Value);
                    _ = roleManager.CreateAsync(role).Result;
                }
            }
        }

        private static void SeedUsers(UserManager<User> userManager)
        {
            bool exists = userManager.FindByNameAsync("admin").Result != null;
            if (!exists)
            {
                User user = new User("admin@localhost", "BG", "BG", "BGN");

                IdentityResult result = userManager.CreateAsync(user, "admin@localhost123").Result;

                if (result.Succeeded)
                {
                    _ = userManager.AddToRoleAsync(user, Administrator).Result;
                    _ = userManager.AddToRoleAsync(user, User).Result;
                }
            }
        }
    }
}
