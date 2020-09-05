using Microsoft.EntityFrameworkCore;
using NewApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiTest.Context
{
    public class FarmAppContext : DbContext
    {
        public FarmAppContext(DbContextOptions<FarmAppContext> options)
            : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users","dist");
                //entity.Property(p => p.Login).HasMaxLength(400);
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(40);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(40);
                entity.Property(p => p.UserName).IsRequired().HasMaxLength(40);
                entity.Property(p => p.RoleId).IsRequired().HasDefaultValueSql("((2))");
                entity.Property(p => p.PasswordHash).IsRequired();
                entity.Property(p => p.PasswordSalt).IsRequired();
                entity.Property(p => p.IsDeleted).IsRequired().HasDefaultValueSql("((0))");
                entity.HasOne(h => h.Role).WithMany(w => w.Users).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "dist");
                entity.Property(p => p.RoleName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.IsDeleted).IsRequired().HasDefaultValueSql("(0)");
            });
        }
    }
}
