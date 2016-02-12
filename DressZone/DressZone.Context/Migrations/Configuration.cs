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
                    PasswordHash = passHasher.HashPassword("ickata"),
                    CreatedOn = DateTime.Now
                };

                manager.Create(adminUser);
                manager.AddToRole(adminUser.Id, "Admin");
            }

            if (!context.GenderTypes.Any(g => g.Name == "Male"))
            {
                var seeder = new SeedData();
                foreach (var gender in seeder.GenderTypes)
                {
                    context.GenderTypes.Add(gender);
                }

                foreach (var size in seeder.Sizes)
                {
                    context.Sizes.Add(size);

                }

                foreach (var color in seeder.Colors)
                {
                    context.Colors.Add(color);
                }

                foreach (var shipping in seeder.ShippingTypes)
                {
                    context.Shippings.Add(shipping);
                }

                foreach (var category in seeder.Categories)
                {
                    context.Categories.Add(category);
                }
            }

           
        }
    }
}
