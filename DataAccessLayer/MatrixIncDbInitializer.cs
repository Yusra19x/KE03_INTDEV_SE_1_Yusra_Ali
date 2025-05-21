using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Check of er al klanten zijn
            if (context.Customers.Any())
                return;

            var customers = new Customer[]
            {
                new Customer { FirstName = "Sanne", LastName = "de Jong", Address = "Leliestraat 12", City = "Amsterdam", Province = "Noord-Holland", Email = "sanne.dejong@example.com", PhoneNr = "0612345678" },
                new Customer { FirstName = "Daan", LastName = "van Dijk", Address = "Kerkstraat 8", City = "Utrecht", Province = "Utrecht", Email = "daan.vandijk@example.com", PhoneNr = "0687654321" }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product { ProductName = "Agatha Schoudertas", Category = "Charles & Keith", Stock = 10, Quantity = 1, Price = 79.00M, ImageUrl = "/img/agatha.png" },
                new Product { ProductName = "Lane Chain-Link", Category = "Charles & Keith", Stock = 8, Quantity = 1, Price = 95.00M, ImageUrl = "/img/lane.png" },
                new Product { ProductName = "Halvemaan Hobotas", Category = "Charles & Keith", Stock = 5, Quantity = 1, Price = 149.00M, ImageUrl = "/img/moon.png" },
                new Product { ProductName = "Teri Hobo - Aardbei", Category = "Coach", Stock = 6, Quantity = 1, Price = 229.00M, ImageUrl = "/img/teri-strawberry.png" },
                new Product { ProductName = "Teri Hobo - Signature", Category = "Coach", Stock = 7, Quantity = 1, Price = 229.00M, ImageUrl = "/img/teri-signature.png" }
            };
            context.Products.AddRange(products);
            context.SaveChanges(); ;

            var klant1 = context.Customers.First();
            var orders = new Order[]
            {
                new Order { CustomerId = klant1.ID, ProductName = "Toetsenbord, Muis", Quantity = 2, Address = klant1.Address, Price = 39.99M, Date = DateTime.Now.AddDays(-1) },
                new Order { CustomerId = klant1.ID, ProductName = "Monitor", Quantity = 1, Address = klant1.Address, Price = 149.99M, Date = DateTime.Now.AddDays(-3) }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
