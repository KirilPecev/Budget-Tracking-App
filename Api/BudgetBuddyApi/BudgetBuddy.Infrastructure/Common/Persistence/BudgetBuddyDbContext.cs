﻿using System.Reflection;

using BudgetBuddy.Domain.Models;
using BudgetBuddy.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infrastructure.Common.Persistence
{
    public class BudgetBuddyDbContext : IdentityDbContext<User, Role, string>
    {
        public BudgetBuddyDbContext(DbContextOptions<BudgetBuddyDbContext> options) : base(options) { }

        public DbSet<Budgets> Budgets { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}