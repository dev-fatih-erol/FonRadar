using FonRadar.Infrastructure.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FonRadar.Infrastructure.Persistence
{
    public class Seeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public Seeder(
            ApplicationDbContext dbContext,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            _dbContext.Database.Migrate();

            await SeedRoles();
            await SeedUser();
        }

        private async Task SeedUser()
        {
            var user1 = await _userManager.FindByNameAsync("buyer-1@email.com");
            if (user1 == null)
            {
                user1 = new User
                {
                    Name = "Buyer-1",
                    UserName = "buyer-1@email.com",
                    Email = "buyer-1@email.com"
                };

                var result = await _userManager.CreateAsync(user1, "Buyer-123");
                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(user1, "Buyer");
            }

            var user2 = await _userManager.FindByNameAsync("supplier-1@email.com");
            if (user2 == null)
            {
                user2 = new User
                {
                    Name = "Supplier-1",
                    UserName = "supplier-1@email.com",
                    Email = "supplier-1@email.com"
                };

                var result = await _userManager.CreateAsync(user2, "Supplier-123");
                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(user2, "Supplier");
            }

            var user3 = await _userManager.FindByNameAsync("financial-institution-1@email.com");
            if (user3 == null)
            {
                user3 = new User
                {
                    Name = "Financial-Institution-1",
                    UserName = "financial-institution-1@email.com",
                    Email = "financial-institution-1@email.com"
                };

                var result = await _userManager.CreateAsync(user3, "Financial-institution123");
                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(user3, "Financial-Institution");
            }
        }

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Buyer"))
                await _roleManager.CreateAsync(new Role { Name = "Buyer" });

            if (!await _roleManager.RoleExistsAsync("Supplier"))
                await _roleManager.CreateAsync(new Role { Name = "Supplier" });

            if (!await _roleManager.RoleExistsAsync("Financial-Institution"))
                await _roleManager.CreateAsync(new Role { Name = "Financial-Institution" });
        }
    }
}