using Domain.Models.Base;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc;

public static class DependencyContainer
{
    public static void AddIoCService(this IServiceCollection services)
    {
        // IoC - Inversion Of Control
        // Application
       

        // Domain.Interfaces > Infrastructure.Data.Repositories
        // User for entity 
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<BaseMsSqlContext>();
        
       
    }
}