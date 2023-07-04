using Microsoft.EntityFrameworkCore;
using ZigitHub.Domain.Models;

namespace ZigitHub.Infra.Data.Context
{
    public partial class ApplicationContext : DbContext
    {
        //all tables should be here
        public DbSet<User> users { get; set; }

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

        protected void Seed(ApplicationContext context)
        {
            context.users.Add(new User { Full_name = "John Doe", Email = "john@gmail.com" });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
