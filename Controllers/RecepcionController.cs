using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Misericordia.Data;
using Misericordia.Models;

namespace Misericordia.Controllers{
    internal class UserFormat : User{
        
    }
    public class RecepcionController : Controller{
        readonly MisericordiaContext _context;

        public RecepcionController(MisericordiaContext context){
            _context = context;
        }

        public IActionResult GestionEspera(){
            return View();
        }

        public async Task <IActionResult> Index(){
            User us1 = new User();
            us1.DocumentType= 1;
            var otro = from user in _context.Users join atention in _context.Attentions on user.Id equals atention.UserId select new {solicitud = atention.NumAttention};
            Console.WriteLine(us1.DocumentType);
            UserFormat us2 = new UserFormat();
            
            Console.WriteLine(us2.DocumentType);
            return View();
        }


    }
}