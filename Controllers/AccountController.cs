using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Replace with real authentication logic
                if (model.Email == "admin@example.com" && model.Password == "password123")
                {
                    // Example: store session or cookie
                    HttpContext.Session.SetString("User", model.Email);

                    // 👇 Redirect to Home/Index after login
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            // If invalid, redisplay the login form
            return View(model);
        }
    }
}
