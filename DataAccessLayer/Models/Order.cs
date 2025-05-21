using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("ORDER")]
    public class Order
    {
        public int ID { get; set; }

        public int CustomerId { get; set; } 
        public Customer? Customer { get; set; } 
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
