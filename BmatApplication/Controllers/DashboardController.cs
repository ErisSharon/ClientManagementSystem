using Microsoft.AspNetCore.Mvc;

namespace BmatApplication.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Clients()
        {
            return View();
        }
    }
}
