using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Misericordia.Data;
using Misericordia.Models;

namespace Misericordia.Controllers{
    public class RecepcionController : Controller{
        readonly MisericordiaContext _context;

        public RecepcionController(MisericordiaContext context){
            _context = context;
        }


        public IActionResult GestionEspera(){
            
            var otro = from user in _context.Users
            join atention in _context.Attentions on user.Id equals atention.UserId
            join documents in _context.DocumentTypes on user.DocumentType equals documents.Id select new {solicitud = atention.NumAttention,
            preferencias = atention.AttentionPreference, nombreCompleto = user.Firstname + " " + user.Lastname, tipoDocumento = documents.type,
            numeroDocumento = user.DocumentNumber, entrada = atention.DateAttentionEnter, status = atention.Status, atentionId = atention.Id};

        
            return View(otro);
        }

        public async Task <IActionResult> GestionEsperaPasar(int userId){

            var atention = await _context.Attentions.FindAsync(userId);
            atention.Status = "ATENDIENDO";
            atention.EmployeeId = (int)HttpContext.Session.GetInt32("EmployeeId");
            _context.Attentions.Update(atention);
            _context.SaveChangesAsync();
            return RedirectToAction("GestionUsuario");

        }

        public async Task <IActionResult> GestionEsperaRechazar(int userId){
            var atention = await _context.Attentions.FindAsync(userId);
            atention.Status = "FINALIZADO";
            atention.EmployeeId = (int)HttpContext.Session.GetInt32("EmployeeId");
            atention.DateAttentionExit = DateTime.Now;
            atention.EndingAttention = 1;
            _context.Attentions.Update(atention);
            _context.SaveChangesAsync();
            return RedirectToAction("GestionUsuario");
        }

        public async Task<IActionResult> GestionFinalizar(int userId){
            var atention = await _context.Attentions.FindAsync(userId);
            atention.Status = "FINALIZADO";
            atention.EmployeeId = (int)HttpContext.Session.GetInt32("EmployeeId");
            atention.DateAttentionExit = DateTime.Now;
            atention.EndingAttention = 2;
            _context.Attentions.Update(atention);
            _context.SaveChangesAsync();
            

            return RedirectToAction("GestionUsuario", "Recepcion");

        }

        public async Task <IActionResult> Index(){

            return View();
        }

        public async Task<IActionResult> GestionUsuario(){
            var otro = from user in _context.Users
            join atention in _context.Attentions on user.Id equals atention.UserId
            join employee in _context.Employees on atention.EmployeeId equals employee.Id
            join documents in _context.DocumentTypes on user.DocumentType equals documents.Id
            select new {solicitud = atention.NumAttention, modulo = employee.Modulo,
            nombreCompleto = user.Firstname + " " + user.Lastname, documento = documents.type + " " + user.DocumentNumber,
            atentionId = atention.Id, status = atention.Status};
            

        
            return View(otro);
        }

    }
}