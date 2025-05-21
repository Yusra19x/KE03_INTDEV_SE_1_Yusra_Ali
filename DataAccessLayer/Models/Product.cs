using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("PRODUCT")]
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public string Category { get; set; }

        public int Quantity { get; set; }
        public int Stock { get; set; }

        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
