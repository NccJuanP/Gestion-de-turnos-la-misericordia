using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Misericordia.Models;
using Misericordia.Data;
using System.Security.Cryptography;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Misericordia.Controllers
{
    public class DocumentController : Controller
    {
        internal class login{
        public string username { get; set; }
        public string password { get; set; }
    }
        public readonly MisericordiaContext _context;
        public DocumentController(MisericordiaContext context)
        {
            _context = context;
        }

        int contadorUser = 0;

public class UserAttentionViewModel
{
    public User User { get; set; }
    public Attention Attention { get; set; }
}
        public async Task<IActionResult> PriorityUser(string priority)
{
   if (!string.IsNullOrEmpty(priority))
{

    int priorityOfUser = Convert.ToInt32(priority);
    HttpContext.Session.SetInt32("priority", priorityOfUser);

    return RedirectToAction("UserNew");
}
return View();
}

        public IActionResult UserNew(string userType)
{
    if (!string.IsNullOrEmpty(userType))
    {
        HttpContext.Session.SetString("userType", userType);
        return RedirectToAction("TypeDocument");
    }
    return View();
}

public IActionResult TypeDocument(string TypeDocument)
{
    if (!string.IsNullOrEmpty(TypeDocument))
    {
        HttpContext.Session.SetString("typeDocument", TypeDocument);
        return RedirectToAction("EnterDocument");
    }
    return View();
}


public async Task<IActionResult> EnterDocument(string enterDocument)
{
       if (!string.IsNullOrEmpty(enterDocument)){
    enterDocument = enterDocument.Replace(" ", "");
    HttpContext.Session.SetString("enterDocument", enterDocument);
    string typeOfUser = HttpContext.Session.GetString("userType");
    string typeOfDocument = HttpContext.Session.GetString("typeDocument");
    string EnterId = HttpContext.Session.GetString("enterDocument");
    
    int documentType = Convert.ToInt32(typeOfDocument);
    int documentNumber = Convert.ToInt32(EnterId);
    

    if (typeOfUser == "2")
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.DocumentType == documentType && u.DocumentNumber == documentNumber);
            
        if (user != null)
        {
            var userJson = JsonConvert.SerializeObject(user);
        HttpContext.Session.SetString("user", userJson);
            return RedirectToAction("TypeRequestUser");
        }
        else
        {
            return RedirectToAction("ErrorDocument");
        }
    }
    else
    {
            Console.WriteLine("aqui el usuario no lo tenemos registrado");
        return RedirectToAction("TypeRequestNewUser");
    } 
    }  
    return View();
}

public IActionResult TypeRequestUser(string typeRequest)
{
    if (!string.IsNullOrEmpty(typeRequest))
    
    {
        HttpContext.Session.SetString("typeRequest", typeRequest);
            TempData["typeRequest"] = typeRequest;
            
            return RedirectToAction("Ficho");
    }
    return View();
}

public IActionResult TypeRequestNewUser(string typeRequestNew)
{
    if (!string.IsNullOrEmpty(typeRequestNew))
    {
        HttpContext.Session.SetString("typeRequestNew", typeRequestNew);
    }
     string typeOfUser = HttpContext.Session.GetString("userType");
    string typeOfDocument = HttpContext.Session.GetString("typeDocument");
    string EnterId = HttpContext.Session.GetString("enterDocument");

    return View();
}

public IActionResult ErrorDocument()
{
    return View();
}

public IActionResult Gestion()
{
    var turns = from atention in _context.Attentions join
    employee in _context.Employees on atention.EmployeeId equals employee.Id select new {modulo = employee.Modulo, turno = atention.NumAttention, estado = atention.Status};
    return View(turns);
}

[HttpPost]
public async Task<IActionResult> Ficho(string? typeRequest)
{
    if (!string.IsNullOrEmpty(typeRequest))
    {
        ViewBag.typeOfRequest = typeRequest;
    }
    var fichos = from consulta in _context.Attentions select consulta;
    string newTurn = "";
    int turno = 1;
    if (typeRequest == "1")
    {
        ViewBag.typeOfRequest = "GC";
        foreach(var item in fichos){
        if("GC" == Regex.Match(item.NumAttention, @"\w+").Value){

                int number = int.Parse(Regex.Match(item.NumAttention, @"\d+").Value);
                turno = number + 1;
            }
    }

    }
    else if (typeRequest == "2")
    {
        ViewBag.typeOfRequest = "IF";
        foreach(var item in fichos){
        if("IF" == Regex.Match(item.NumAttention, @"\w+").Value){

                int number = int.Parse(Regex.Match(item.NumAttention, @"\d+").Value);
                turno = number + 1;
            }
    }
    }
    else if (typeRequest == "3")
    {
        ViewBag.typeOfRequest = "PF";
        foreach(var item in fichos){
        if("PF" == Regex.Match(item.NumAttention, @"\w+").Value){

                int number = int.Parse(Regex.Match(item.NumAttention, @"\d+").Value);
                turno = number + 1;
            }
    }

    }
    else if (typeRequest == "4")
    {
        ViewBag.typeRequest = "AM";
        foreach(var item in fichos){

        if("AM" == Regex.Match(item.NumAttention, @"\w+").Value){

                int number = int.Parse(Regex.Match(item.NumAttention, @"\d+").Value);
                turno = number + 1;
            }
    }
    }

    string typeOfDocument = HttpContext.Session.GetString("typeDocument");

    if (typeOfDocument == "1")
    {
        ViewBag.typeOfDocument = "CC";
    }
    else if (typeOfDocument == "2")
    {
        ViewBag.typeOfDocument = "TI";
    }
    else if (typeOfDocument == "3")
    {
        ViewBag.typeOfDocument = "CE";
    }
    else if (typeOfDocument == "4")
    {
        ViewBag.typeOfDocument = "DA";
    }

    var userJson = HttpContext.Session.GetString("user");
    var user = JsonConvert.DeserializeObject<User>(userJson);

    

    newTurn = ViewBag.typeOfRequest + "-" + turno;
    ViewBag.newTurn = newTurn;
    ViewBag.idemployee = HttpContext.Session.GetInt32("EmployeeId");
    
    var attention = new Attention
    {
        NumAttention = newTurn,
        UserId = user.Id,
        DateAttentionEnter = DateTime.Now,
        AttentionPreference = HttpContext.Session.GetInt32("priority"),
        Status = "ESPERA"
    };


    //datos para el agregar a recepcion
    ViewBag.preferencia = HttpContext.Session.GetInt32("priority");

    _context.Attentions.Update(attention);
    await _context.SaveChangesAsync();

     var viewModel = new UserAttentionViewModel
    {
        User = user,
        Attention = attention
    };

    return View(viewModel);
}
}
  } 


