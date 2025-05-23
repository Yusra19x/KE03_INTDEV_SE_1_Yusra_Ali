using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_1_Yusra_Ali.Pages.Orders
{
    public class HistoryModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public IEnumerable<Order> Orders { get; set; }

        public HistoryModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
            Orders = _orderRepository.GetAllOrders();
        }
    }
}
