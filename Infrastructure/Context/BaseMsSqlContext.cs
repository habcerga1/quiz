using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class BaseMsSqlContext : IdentityDbContext
{
    public BaseMsSqlContext(DbContextOptions<BaseMsSqlContext> options)
        : base(options)
    { }
    
    
}