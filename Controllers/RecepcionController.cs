using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Misericordia.Data;

namespace Misericordia.Controllers{
    public class MisericordiaController : Controller{
        readonly MisericordiaContext _context;

        public MisericordiaController(MisericordiaContext context){
            _context = context;
        }

        public IActionResult GestionEspera(){
            return View();
        }

        public IActionResult Index(){
            return View();
        }


    }
}