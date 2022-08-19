using Domain.Models.Base;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Seed;

public class MsSqlSeedData
{
    private readonly BaseMsSqlContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;

    public MsSqlSeedData(BaseMsSqlContext context,RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async void SeedAdminUser()
    {
        
        var roleStore = new RoleStore<IdentityRole>(_context);

        if (!_context.Roles.Any(r => r.Name == "Admin"))
        {
            await roleStore.CreateAsync(new IdentityRole { Name = "User", NormalizedName = "USER" });
            await roleStore.CreateAsync(new IdentityRole { Name = "Subscriber", NormalizedName = "SUBSCRIBER" });
            await roleStore.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
        }
        
        await _context.SaveChangesAsync();
        
        var user = new User
        {
            UserName = "Email@email.com",
            NormalizedUserName = "email@email.com",
            Email = "Email@email.com",
            NormalizedEmail = "email@email.com",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
        };
        
        var userCreated = await _userManager.CreateAsync(user, "7am8a5up3R!");
        var userFromDb = await _userManager.FindByEmailAsync(user.Email);
        await _userManager.AddToRoleAsync(userFromDb,"Admin");

    }
}
