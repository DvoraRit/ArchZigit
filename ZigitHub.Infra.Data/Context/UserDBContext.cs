using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZigitHub.Domain.Models;

namespace ZigitHub.Infra.Data.Context
{
    public class UsersDBContext : DbContext
    {
        public UsersDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("Users");

            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.Full_name)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.Is_admin).HasColumnName("is_admin");

            //    entity.Property(e => e.Registration_date)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("(getdate())");
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        public DbSet<User> users { get; set; }
    }
}
