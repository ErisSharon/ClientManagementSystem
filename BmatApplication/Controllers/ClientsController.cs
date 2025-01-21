using BmatApplication.Models;
using BmatApplication.ViewModels;
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

    public IActionResult ListClients(string searchQuery = "", int pageNumber = 1)
    {
        // Define the number of clients to display per page
        int pageSize = 10;

        var query = _context.Clients.AsQueryable();

        // Filter by search query (if any)
        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(c => c.Name.Contains(searchQuery) || c.Product.Contains(searchQuery));
        }

        // Count the total number of clients after filtering (for pagination)
        int totalClients = query.Count();

        // Paginate the query
        var clients = query.Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();

        var model = new ClientsViewModel
        {
            Clients = clients,
            PageNumber = pageNumber,
            TotalClients = totalClients,
            SortOrder = "Name" // Example: Sorting by Name (this could be dynamic)
        };

        return View(model);
    }



    // GET: Display the form to add a new client
    public IActionResult AddClients()
    {
        return View();
    }

    public IActionResult ManageClients(int id)
    {
        var client = _context.Clients.FirstOrDefault(c => c.ClientId == id);
        if (client == null)
        {
            return NotFound(); // Return a 404 if the client doesn't exist
        }
        return View(client);
    }


    //POST: Handles form submission for adding a client
    [HttpPost]
    public IActionResult AddClients(ClientsModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Clients.Add(model);
            _context.SaveChanges();
            return RedirectToAction("ListClients");
        }
        return View(model);
    }

    

  
}

