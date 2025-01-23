
using Microsoft.AspNetCore.Mvc;

namespace BmatApplication.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
           
            return View();
        }
    }
}
