using Microsoft.AspNetCore.Mvc;
using Misericordia.Models;
using Misericordia.Data;
using Microsoft.EntityFrameworkCore;

namespace misericordia.Controllers
{
    internal class login{
        public string username { get; set; }
        public string password { get; set; }
    }
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
        {   login registro = new login();
            if (!string.IsNullOrEmpty(names) && !string.IsNullOrEmpty(passwords))
            {
                if (int.TryParse(names, out int documentNumber))
                {
                    var user = await _context.Employees.FirstOrDefaultAsync(u => u.DocumentNumber == documentNumber || u.Password == passwords);

                    if (user != null){

                        if(user.DocumentNumber == documentNumber && user.Password == passwords){

                         HttpContext.Session.SetInt32("EmployeeId", user.Id);
                        return RedirectToAction("GestionEspera", "Recepcion");
                        }

                        else if(user.DocumentNumber == documentNumber && user.Password != passwords){
                            registro.username = "1";
                            registro.password = "0";
                        }

                        else{
                            registro.username = "0";
                            registro.password = "0";
                        }
                    }
                    else
                    {
                        registro.username = "0";
                        registro.password = "0";
                        ViewBag.Error = "Invalid username or password.";
                    }
                }
                else
                {
                    registro.username = "0";
                    registro.password = "0";
                    ViewBag.Error = "Invalid username or password.";
                }
            }else{
                registro.username = "-1";
                registro.password = "-1";

            return View(registro);
            }

            return View(registro);
        }
    }
}


