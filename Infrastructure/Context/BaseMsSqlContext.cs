using Domain.Common;
using Domain.Models.Base;
using Domain.Token;
using Infrastructure.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class BaseMsSqlContext : IdentityDbContext<User,IdentityRole,string>
{
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<ShortQuizDescription> ShortQuizDescriptions { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserSolutionResult> UserSolutionResults { get; set; }
    public BaseMsSqlContext(DbContextOptions<BaseMsSqlContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region USERS ROLES
        
        //Seeding a  'User' role to AspNetRoles table
        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole {Id = "2798ef7e-81cb-4a19-8eca-7ad898498c4c", Name = "User", NormalizedName = "USER".ToUpper() });
        //Seeding a  'Subscriber' role to AspNetRoles table
        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole {Id = "9e9d3a1a-7003-4071-9b0e-beb9e97f3b41", Name = "Subscriber", NormalizedName = "SUBSCRIBER".ToUpper() });
        //Seeding a  'Administrator' role to AspNetRoles table
        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole {Id = "498c3025-a4f4-4d5c-88b2-7370ac7f9e43", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
        
        //a hasher to hash the password before seeding the user to the db
        var hasher = new PasswordHasher<User>();

        //Seeding the 'User' User to AspNetUsers table
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Guid = Guid.Parse("86a0a442-ddae-4b5c-9593-d44483fa7c4a"), // primary key
                UserName = "user@mail.com",
                NormalizedUserName = "USER@MAIL.COM",
                PasswordHash = hasher.HashPassword(null, "7am8a5up3R!"),
                FullName = "User user",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM",
            }
        );
        //Seeding the 'Subscriber' User to AspNetUsers table
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Guid = Guid.Parse("948e1d09-8785-4779-b649-daa3ec5c157f"), // primary key
                UserName = "subscriber@mail.com",
                NormalizedUserName = "SUBSCRIBER@MAIL.COM",
                PasswordHash = hasher.HashPassword(null, "7am8a5up3R!"),
                FullName = "Subscriber Subscriber",
                Email = "subscriber@mail.com",
                NormalizedEmail = "SUBSCRIBER@MAIL.COM",
            }
        );
        //Seeding the 'Administrator' User to AspNetUsers table
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Guid = Guid.Parse("e6aa01ab-f765-4270-87dc-774c5a2ce447"), // primary key
                UserName = "administrator@mail.com",
                NormalizedUserName = "ADMINISTRATOR@MAIL.COM",
                PasswordHash = hasher.HashPassword(null, "7am8a5up3R!"),
                FullName = "Administrator Administrator",
                Email = "Administrator@mail.com",
                NormalizedEmail = "ADMINISTRATOR@MAIL.COM",
            }
        );
        
        //Seeding the relation between our Administrator user and  Administrator role to AspNetUserRoles table
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2798ef7e-81cb-4a19-8eca-7ad898498c4c", 
                UserId = "86a0a442-ddae-4b5c-9593-d44483fa7c4a"
            }
        );
        //Seeding the relation between our Subscriber user and  Subscriber role to AspNetUserRoles table
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "9e9d3a1a-7003-4071-9b0e-beb9e97f3b41", 
                UserId = "948e1d09-8785-4779-b649-daa3ec5c157f"
            }
        );
        //Seeding the relation between our User user and  User role to AspNetUserRoles table
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "498c3025-a4f4-4d5c-88b2-7370ac7f9e43", 
                UserId = "e6aa01ab-f765-4270-87dc-774c5a2ce447"
            }
        );
        
        #endregion
    }

}