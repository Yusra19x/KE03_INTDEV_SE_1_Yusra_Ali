using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);
        Order? GetOrderById(int id);
    }
}
