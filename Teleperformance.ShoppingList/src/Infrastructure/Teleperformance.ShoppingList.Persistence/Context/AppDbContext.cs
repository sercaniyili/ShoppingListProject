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


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    //Remove cascade delete unless explicit set below

        //    //var cascadeFKs = builder.Model
        //    //    .GetEntityTypes()
        //    //    .SelectMany(t => t.GetForeignKeys())
        //    //    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        //    //foreach (var fk in cascadeFKs)
        //    //{
        //    //    fk.DeleteBehavior = DeleteBehavior.Restrict;
        //    //}

        //    // explicit set cascade delete
        //    // Remove security assignments when group deleted
        //    //builder.Entity<ShoppingList>().HasMany(x => x.Products).WithOne(x => x.Id).HasForeignKey(x => x.).OnDelete(DeleteBehavior.Cascade);

        //}
    }
}
