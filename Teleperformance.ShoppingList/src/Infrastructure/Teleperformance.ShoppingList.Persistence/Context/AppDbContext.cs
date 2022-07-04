using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teleperformance.Bootcamp.Domain.Entities;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

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
            builder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<ShoppingList>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            //builder.Entity<ShoppingList>()
            //.HasOne(e => e.Products)
            //.WithMany(e => e.)
            //.HasForeignKey(e => e.BId)
            //.OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ShoppingList>().HasMany(b => b.Products).WithOne(p => p.ShoppingList)
            .HasForeignKey(p => p.ShoppingListId)
            .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(builder);
        }    
    }
}
