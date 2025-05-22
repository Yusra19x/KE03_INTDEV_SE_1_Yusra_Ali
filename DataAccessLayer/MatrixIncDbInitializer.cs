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
                new Product { ProductName = "Neural Connector Port", Category = "Interface Modules", Stock = 25, Quantity = 1, Price = 149.00M, ImageUrl = "/img/neural-port.png" },
                new Product { ProductName = "Red Pill Protocol Capsule", Category = "Transmissie Tools", Stock = 99, Quantity = 1, Price = 19.99M, ImageUrl = "/img/red-pill.png" },
                new Product { ProductName = "Sentinel Tentacle Segment", Category = "Mecha-onderdelen", Stock = 10, Quantity = 1, Price = 259.50M, ImageUrl = "/img/sentinel-tentacle.png" },
                new Product { ProductName = "Hovercraft Power Relay", Category = "Energiecomponenten", Stock = 15, Quantity = 1, Price = 189.00M, ImageUrl = "/img/hovercraft-relay.png" },
                new Product { ProductName = "EMP Discharge Coil", Category = "Defensiesystemen", Stock = 8, Quantity = 1, Price = 349.00M, ImageUrl = "/img/emp-coil.png" }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var klant1 = context.Customers.First();
            var orders = new Order[]
            {
            new Order { CustomerId = klant1.ID, ProductName = "Neural Connector Port", Quantity = 2, Address = klant1.Address, Price = 298.00M, Date = DateTime.Now.AddDays(-2) },
            new Order { CustomerId = klant1.ID, ProductName = "EMP Discharge Coil", Quantity = 1, Address = klant1.Address, Price = 349.00M, Date = DateTime.Now.AddDays(-5) }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
