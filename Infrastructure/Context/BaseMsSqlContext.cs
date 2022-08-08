using Domain.Models.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class BaseMsSqlContext : IdentityDbContext<User,IdentityRole,string>
{
    public BaseMsSqlContext(DbContextOptions<BaseMsSqlContext> options)
        : base(options)
    { }
    
    
}