using Microsoft.EntityFrameworkCore;
using RSGymPT.Clients.Models;

namespace RSGymPT.Clients.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento Muitos para Muitos entre Customer e Category
            modelBuilder.Entity<CustomerCategory>()
                .HasKey(cc => new { cc.CustomerId, cc.CategoryId }); // Chave composta

            modelBuilder.Entity<CustomerCategory>()
                .HasOne(cc => cc.Customer)
                .WithMany(c => c.CustomerCategories)
                .HasForeignKey(cc => cc.CustomerId);

            modelBuilder.Entity<CustomerCategory>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.CustomerCategories)
                .HasForeignKey(cc => cc.CategoryId);
        }
    }
}