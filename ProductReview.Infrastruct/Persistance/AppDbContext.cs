using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Infrastruct.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> ops)
            : base(ops)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
               .HasMany(x => x.Permissions)
               .WithMany(x => x.Roles)
               .UsingEntity<RolePermission>();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)  
                .WithMany(u => u.Products)  
                .HasForeignKey(p => p.UserId); 

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Product)  
                .WithMany(p => p.Comments) 
                .HasForeignKey(c => c.ProductId); 

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
