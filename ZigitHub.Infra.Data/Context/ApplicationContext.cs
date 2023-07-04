using Microsoft.EntityFrameworkCore;
using ZigitHub.Domain.Models;

namespace ZigitHub.Infra.Data.Context
{
    public partial class ApplicationContext : DbContext
    {

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Full_name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Is_admin).HasColumnName("is_admin");

                entity.Property(e => e.Registration_date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            }); 

            OnModelCreatingPartial(modelBuilder);
        }

        //protected override void Seed(ApplicationContext context)
        //{
           
        //    context.Users.Add(new User { Id = 1, Full_name = "Test User", Email = "test@gmail.com" });
        //}
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
