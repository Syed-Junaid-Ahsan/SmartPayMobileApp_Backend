using Microsoft.EntityFrameworkCore;
using SmartPayMobileApp_Backend.Models.Entities;

namespace SmartPayMobileApp_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User entity configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Map columns to camelCase
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("name");
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50).HasColumnName("email");
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15).HasColumnName("phoneNumber");
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(512).HasColumnName("passwordHash");
                entity.Property(e => e.CnicNumber).IsRequired().HasMaxLength(13).HasColumnName("cnicNumber");
                entity.Property(e => e.ConsumerNumber).IsRequired().HasMaxLength(30).HasColumnName("consumerNumber");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()").HasColumnName("createdAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
                entity.Property(e => e.IsActive).HasColumnName("isActive");
                
                // Index for better performance
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.ConsumerNumber).IsUnique();
                entity.HasIndex(e => e.PhoneNumber).IsUnique();
            });
        }
    }
}
