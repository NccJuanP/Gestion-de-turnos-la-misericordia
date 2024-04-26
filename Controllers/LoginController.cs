using Microsoft.AspNetCore.Mvc;
using misericordia.Models;
using Misericordia.Data;
using Microsoft.EntityFrameworkCore;

namespace misericordia.Controllers
{
    public class LoginController : Controller
    {
        readonly MisericordiaContext _context;
        string name;
        string password;
        public LoginController(MisericordiaContext context)
        {
            _context = context;
        }
  public async Task<IActionResult> Index(string names, string passwords)
{
    if (!string.IsNullOrEmpty(names) && !string.IsNullOrEmpty(passwords))
    {
        if (int.TryParse(names, out int documentNumber))
        {
            var user = await _context.Employees
                .FirstOrDefaultAsync(u => u.DocumentNumber == documentNumber && u.Password == passwords);

            if (user != null)
            {
                HttpContext.Session.SetString("username", names);
                HttpContext.Session.SetString("userpassword", passwords);
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                ViewBag.Error = "Invalid username or password.";
            }
        }
        else
        {
            ViewBag.Error = "Invalid username or password.";
        }
    }

    return View();
}
}
    }


