using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Text.Json;

namespace KE03_INTDEV_SE_1_Yusra_Ali.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepo;

        public List<Product> Winkelwagen { get; set; } = new();

        public CreateModel(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IActionResult OnGet(int? add)
        {
            // Session ophalen of nieuwe lijst maken
            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(cartJson)!;

            // Als er een product wordt toegevoegd
            if (add.HasValue)
            {
                cart.Add(add.Value);
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            }

            // Haal de producten op op basis van ID's
            Winkelwagen = cart
                .Select(id => _productRepo.GetProductById(id))
                .Where(p => p != null)
                .ToList();

            return Page();
        }
    }
}