using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    }
}
