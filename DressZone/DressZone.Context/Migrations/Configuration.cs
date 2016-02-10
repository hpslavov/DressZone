namespace DressZone.Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DressZone.Context;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using DressZone.Models.Account;
    public sealed class Configuration : DbMigrationsConfiguration<DressZoneDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DressZoneDbContext context)
        {
            var passHasher = new PasswordHasher();

            if (!context.Roles.Any(r => r.Name == "Admin" || r.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "Admin" };
                var customerRole = new IdentityRole { Name = "Customer" };
                manager.Create(adminRole);
                manager.Create(customerRole);
            }

            if (!context.Users.Any(u => u.UserName == "slavov.hristo@gmail.com"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var adminUser = new User
                {
                    UserName = "slavov.hristo@gmail.com",
                    Email = "slavov.hristo@gmail.com",
                    PasswordHash = passHasher.HashPassword("ickata")
                };

                manager.Create(adminUser);
                manager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}
