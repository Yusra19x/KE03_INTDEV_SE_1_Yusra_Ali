using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("CUSTOMER")]
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNr { get; set; } = string.Empty;

        // Navigatie: één klant heeft meerdere orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
