using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;


namespace WebApp.Context;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<UserRoleEntity> UserRole { get; set; }
}
