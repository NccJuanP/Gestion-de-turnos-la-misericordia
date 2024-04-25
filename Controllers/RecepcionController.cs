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
        // En el controlador
        public ActionResult ActualizarSegundaVista()
        {
            // Lógica para actualizar la segunda vista
            return PartialView("SegundaVistaPartial", 2);
        }


        public IActionResult GestionEspera(){
            var otro = from user in _context.Users
            join atention in _context.Attentions on user.Id equals atention.UserId
            join documents in _context.DocumentTypes on user.DocumentType equals documents.Id select new {solicitud = atention.NumAttention,
            preferencias = atention.AttentionPreference, nombreCompleto = user.Firstname + " " + user.Lastname, tipoDocumento = documents.type,
            numeroDocumento = user.DocumentNumber, entrada = atention.DateAttentionEnter};

        
            return View(otro);
        }

        public async Task <IActionResult> Index(){
            return View();
        }


    }
}