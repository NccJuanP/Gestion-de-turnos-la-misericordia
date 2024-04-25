using Microsoft.AspNetCore.Mvc;
using Misericordia.Data;

namespace Misericordia.Controllers{
    public class RecepcionController : Controller{
        readonly MisericordiaContext _context;

        public RecepcionController(MisericordiaContext context){
            _context = context;
        }
        internal class claseTest{
            public string solicitud {get; set;}
        }

        public IActionResult GestionEspera(){
            var otro = from user in _context.Users join atention in _context.Attentions on user.Id equals atention.UserId select new {solicitud = atention.NumAttention,
            preferencias = atention.AttentionPreference, nombreCompleto = user.Firstname + " " + user.Lastname, tipoDocumento = user.DocumentType,
            numeroDocumento = user.DocumentNumber, entrada = atention.DateAttentionEnter};

        
            return View(otro);
        }

        public async Task <IActionResult> Index(){
            return View();
        }


    }
}