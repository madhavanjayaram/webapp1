using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp1.Models;
using webapp1.Services;

namespace webapp1.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        public void OnGet()
        {
            ProductService productService= new ProductService();
            Products = productService.GetProducts();
        }
    }
}