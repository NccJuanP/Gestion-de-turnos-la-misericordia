using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Misericordia.Models;
using Misericordia.Data;
using System.Security.Cryptography;
using System.ComponentModel;

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
    return View();
}

public IActionResult Ficho()
{
    string typeOfRequest = HttpContext.Session.GetString("typeRequest");
      if (typeOfRequest == "1"){
            typeOfRequest="GC";
        }else if (typeOfRequest == "2"){
             typeOfRequest="IF";
        }else if (typeOfRequest == "3"){
             typeOfRequest="PF";
        }else if (typeOfRequest == "4"){
             typeOfRequest="AM";
        }
        ViewBag.typeOfRequest = typeOfRequest;

    return View();
}

    }
}
