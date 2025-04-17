using Microsoft.EntityFrameworkCore;
using RSGymPT.Clients.Models;
using RSGymPT.Clients.Constants;

namespace RSGymPT.Clients.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (context.Customers.Any())
            {
                return; 
            }

            var PaymentTypes = new PaymentType[]
            {
                new PaymentType 
                {
                    PaymentTypeName = "Monthly",
                    Amount = PricingConstants.MonthlyPrice * (1 - PricingConstants.DiscountPercentage)
                },
                new PaymentType 
                { 
                    PaymentTypeName = "Per Session",
                    Amount = PricingConstants.PerSessionPrice
                }
            };
            context.PaymentTypes.AddRange(PaymentTypes);
            context.SaveChanges(); 

            var Categories = new Category[]
            {
                new Category { CategoryName = "Monthly" },
                new Category { CategoryName = "Per Session" }
            };
            context.Categories.AddRange(Categories);
            context.SaveChanges(); 

            var Customers = new Customer[]
            {
                new Customer
                {
                    CustomerName = "Paulo Melo",
                    IsFidelized = true
                },
                new Customer
                {
                    CustomerName = "Maria Santos",
                    IsFidelized = false
                }
            };
            context.Customers.AddRange(Customers);
            context.SaveChanges(); 

            var CustomerCategories = new CustomerCategory[]
            {
                new CustomerCategory
                {
                    CustomerId = Customers[0].CustomerId,
                    CategoryId = Categories[0].CategoryId
                },
                new CustomerCategory
                {
                    CustomerId = Customers[1].CustomerId,
                    CategoryId = Categories[1].CategoryId
                }
            };
            context.CustomerCategories.AddRange(CustomerCategories);
            context.SaveChanges(); 

            var payments = new Payment[]
            {
                new Payment
                {
                    CustomerId = Customers[0].CustomerId,
                    PaymentDate = DateTime.UtcNow,
                    PaymentTypeId = PaymentTypes[0].PaymentTypeId
                },
                new Payment
                {
                    CustomerId = Customers[1].CustomerId,
                    PaymentDate = DateTime.UtcNow,
                    PaymentTypeId = PaymentTypes[1].PaymentTypeId
                }
            };
            context.Payments.AddRange(payments);
            context.SaveChanges(); 
        }
    }
}
