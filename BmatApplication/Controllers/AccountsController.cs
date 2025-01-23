using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using BmatApplication.Models;
using BmatApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BmatApplication.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(
            ILogger<AccountsController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Hardcoded user credentials
            string hardcodedEmail = "testuser@example.com";
            string hardcodedPassword = "password123";

            // Check if provided credentials match the hardcoded ones
            if (email == hardcodedEmail && password == hardcodedPassword)
            {
                // Simulate successful login by redirecting to a secure area
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Dashboard", "Dashboard");
            }

            // Add error message if login fails
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login", "Accounts"); // Redirect to Login page after logout
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home"); // Redirect to the secure area
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model); // Return the view with errors
        }




        //private readonly ILogger<AccountsController> _logger;

        //public AccountsController(ILogger<AccountsController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Login()
        //{
        //    return View("Login", null);
        //}

        //public IActionResult Register()
        //{
        //    return View();
        //}

        public IActionResult Profile()
        {
            return View();
        }

        // POST: Register
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Register(RegisterViewModel model)
         {
             if (ModelState.IsValid)
             {
                 // Map ViewModel to Domain Model
                 var user = new User
                 {
                     Email = model.Email,
                     Password = model.Password,
                     ConfirmPassword = model.ConfirmPassword,
                 };

                 // Save the user to the database
                 _context.Users.Add(user);
                 await _context.SaveChangesAsync();

                 return RedirectToAction("Index", "Home");
             }
             return View(model);

         }
     }


                 public IActionResult Clients()
         {
             return View();
         } */


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
