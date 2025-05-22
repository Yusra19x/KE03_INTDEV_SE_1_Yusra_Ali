using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace KE03_INTDEV_SE_1_Yusra_Ali.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepo;

        public List<Product> Products { get; set; } = new();

        public IndexModel(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public void OnGet()
        {
            Products = _productRepo.GetAllProducts().ToList();
        }

        [BindProperty]
        public int ProductId { get; set; }

        public IActionResult OnPostAddToCart(int productId)
        {
            var product = _productRepo.GetProductById(productId); // haalt product op uit database

            var winkelwagenJson = HttpContext.Session.GetString("Winkelwagen");
            var winkelwagen = string.IsNullOrEmpty(winkelwagenJson)
                ? new List<Product>()
                : JsonSerializer.Deserialize<List<Product>>(winkelwagenJson);

            winkelwagen.Add(product);

            HttpContext.Session.SetString("Winkelwagen", JsonSerializer.Serialize(winkelwagen));

            return RedirectToPage("/Products/Index"); // terug naar productpagina
        }
    }
}
