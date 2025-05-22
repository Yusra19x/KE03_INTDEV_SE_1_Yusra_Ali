using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Text.Json;

namespace KE03_INTDEV_SE_1_Yusra_Ali.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public List<Product> Winkelwagen { get; set; } = new();

        public CreateModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
            var winkelwagenJson = HttpContext.Session.GetString("Winkelwagen");
            Winkelwagen = string.IsNullOrEmpty(winkelwagenJson)
                ? new List<Product>()
                : JsonSerializer.Deserialize<List<Product>>(winkelwagenJson);
        }

        public IActionResult OnPost()
        {
            // Simuleer ophalen van winkelwagen producten
            var winkelwagenJson = HttpContext.Session.GetString("Winkelwagen");
            var winkelwagen = string.IsNullOrEmpty(winkelwagenJson)
                ? new List<Product>()
                : JsonSerializer.Deserialize<List<Product>>(winkelwagenJson);

            if (winkelwagen == null || !winkelwagen.Any())
            {
                return RedirectToPage("/Products/Index"); // Niks te bestellen
            }

            foreach (var product in winkelwagen)
            {
                var nieuweOrder = new Order
                {
                    ProductName = product.ProductName,
                    Quantity = product.Quantity,
                    Price = product.Price * product.Quantity,
                    Address = "Adres invullen of opvragen",
                    Date = DateTime.Now,
                    CustomerId = 1 // Dummy of ingelogde klant
                };

                _orderRepository.CreateOrder(nieuweOrder);
            }

            HttpContext.Session.Remove("Winkelwagen");

            return RedirectToPage("/Orders/History");
        }

        public IActionResult OnPostRemove(int productId)
        {
            var winkelwagenJson = HttpContext.Session.GetString("Winkelwagen");
            var winkelwagen = string.IsNullOrEmpty(winkelwagenJson)
                ? new List<Product>()
                : JsonSerializer.Deserialize<List<Product>>(winkelwagenJson);

            var teVerwijderen = winkelwagen.FirstOrDefault(p => p.ProductID == productId);
            if (teVerwijderen != null)
            {
                winkelwagen.Remove(teVerwijderen);
            }

            HttpContext.Session.SetString("Winkelwagen", JsonSerializer.Serialize(winkelwagen));
            return RedirectToPage();
        }

        public IActionResult OnPostIncrease(int productId)
        {
            return UpdateQuantity(productId, +1);
        }

        public IActionResult OnPostDecrease(int productId)
        {
            return UpdateQuantity(productId, -1);
        }

        private IActionResult UpdateQuantity(int productId, int verschil)
        {
            var winkelwagenJson = HttpContext.Session.GetString("Winkelwagen");
            var winkelwagen = string.IsNullOrEmpty(winkelwagenJson)
                ? new List<Product>()
                : JsonSerializer.Deserialize<List<Product>>(winkelwagenJson);

            var item = winkelwagen.FirstOrDefault(p => p.ProductID == productId);
            if (item != null)
            {
                item.Quantity += verschil;
                if (item.Quantity < 1)
                    item.Quantity = 1; // ondergrens: minimaal 1
            }

            HttpContext.Session.SetString("Winkelwagen", JsonSerializer.Serialize(winkelwagen));
            return RedirectToPage();
        }
    }
}