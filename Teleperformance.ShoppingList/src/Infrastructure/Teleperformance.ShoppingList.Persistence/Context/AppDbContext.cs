using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teleperformance.Bootcamp.Domain.Entities;
using Teleperformance.Bootcamp.Domain.Entities.Identity;
using Teleperformance.Bootcamp.Persistence.Context.Configurations;

namespace Teleperformance.Bootcamp.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());


            builder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<ShoppingList>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            base.OnModelCreating(builder);
        }    
    }
}
