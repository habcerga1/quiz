using Domain.Models.Base;
using Domain.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class BaseMsSqlContext : IdentityDbContext<User,IdentityRole,string>
{
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public BaseMsSqlContext(DbContextOptions<BaseMsSqlContext> options)
        : base(options)
    {
       
    }

}