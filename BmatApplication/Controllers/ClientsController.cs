using BmatApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ClientsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientsController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult AddClients()
    {
        return View();
    }
        
    public IActionResult ListClients()
    {
        return View();
    }
}

//    // GET: Clients
//    public IActionResult AddClients()
//    {
//        var model = new ClientsViewModel
//        {
//            Clients = _context.Clients.ToList()
//        };
//        return View(model);
//    }


//    // POST: Clients/AddClient
//    [HttpPost]
//    public IActionResult AddClients(ClientsModel model)
//    {
//        if (ModelState.IsValid)
//        {
//            _context.Clients.Add(model.client);
//            _context.SaveChanges();
//            return RedirectToAction("AddClients");
//        }

//        // Refill the list in case of validation errors
//        model.ClientId = _context.Clients.ToList();
//        return View(model);
//    }

//}




