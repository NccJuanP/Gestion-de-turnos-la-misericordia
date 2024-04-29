using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Misericordia.Models;
using Misericordia.Data;
using System.Security.Cryptography;
using System.ComponentModel;
using Newtonsoft.Json;

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
    [HttpPost]
        public async Task<IActionResult> PriorityUser(string priority)
{
   if (!string.IsNullOrEmpty(priority))
{
    HttpContext.Session.SetString("priority", priority);

    int priorityOfUser = Convert.ToInt32(priority);

    var attention = new Attention
    {
        AttentionPreference = priorityOfUser
        
    };

    _context.Attentions.Add(attention);
    await _context.SaveChangesAsync();

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
            Console.WriteLine("aqui el usuario existe");
            Console.WriteLine();
            var userJson = JsonConvert.SerializeObject(user);
        HttpContext.Session.SetString("user", userJson);
            return RedirectToAction("TypeRequestUser");
        }
        else
        {
            Console.WriteLine("aqui el usuario no existe");
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
public async Task<IActionResult> Ficho(int? id)
{
    string typeOfRequest = TempData["typeRequest"] as string;
    if (typeOfRequest == "1")
    {
        ViewBag.typeOfRequest = "GC";
    }
    else if (typeOfRequest == "2")
    {
        ViewBag.typeOfRequest = "IF";
    }
    else if (typeOfRequest == "3")
    {
        ViewBag.typeOfRequest = "PF";
    }
    else if (typeOfRequest == "4")
    {
        ViewBag.typeOfRequest = "AM";
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

    contadorUser++;
    var newTurn = contadorUser.ToString() + "-" + ViewBag.typeOfDocument;

    var attention = new Attention
    {
        NumAttention = newTurn,
        UserId = user.Id,
        DateAttentionEnter = DateTime.Now
    };

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


