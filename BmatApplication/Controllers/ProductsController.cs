
using Microsoft.AspNetCore.Mvc;

namespace BmatApplication.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult ViewProducts()
        {
            var products = new List<ProductModel>
    {
        new ProductModel { Name = "Mobile Money", Description = "Seamlessly manage payments." },
        new ProductModel { Name = "Agency Banking", Description = "Expand your financial services reach." },
        new ProductModel { Name = "Internet Banking", Description = "Secure and convenient banking." },
        new ProductModel { Name = "Automated Clearing House", Description = "Speed up clearing processes." }
    };
            return View();
        }
    }
}
