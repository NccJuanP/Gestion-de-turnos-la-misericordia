using Microsoft.AspNetCore.Mvc;
using Misericordia.Data;

namespace Misericordia.Controllers{
    public class RecepcionController : Controller{
        readonly MisericordiaContext _context;

        public RecepcionController(MisericordiaContext context){
            _context = context;
        }

        public IActionResult GestionEspera(){
            return View();
        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult GestionUsuario(){
            return View();
        }


    }
}