using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using RSGymPT.Clients.Models;

namespace RSGymPT.Clients.Data
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerCategory> CustomerCategories { get; set; }
    }
}