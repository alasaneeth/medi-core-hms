using MediCoreHMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediCoreHMS.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Roles Seed
        if (!await context.Roles.AnyAsync())
        {
            var roles = new List<Role>
            {
                new() { Name = "SystemAdministrator", Description = "Full system access" },
                new() { Name = "Receptionist", Description = "Front desk operations" },
                new() { Name = "Doctor", Description = "Medical consultations" },
                new() { Name = "LaboratoryTechnician", Description = "Lab operations" },
                new() { Name = "Pharmacist", Description = "Pharmacy operations" },
                new() { Name = "BillingOfficer", Description = "Billing and payments" },
                new() { Name = "HospitalManager", Description = "Reports and analytics" }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }

        // Admin User Seed
        if (!await context.Users.AnyAsync())
        {
            var adminRole = await context.Roles
                .FirstOrDefaultAsync(r => r.Name == "SystemAdministrator");

            if (adminRole != null)
            {
                var admin = new User
                {
                    FullName = "System Administrator",
                    Email = "admin@medicore.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    IsActive = true,
                    RoleId = adminRole.Id
                };

                await context.Users.AddAsync(admin);
                await context.SaveChangesAsync();
            }
        }
    }
}