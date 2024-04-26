using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Misericordia.Models;
using Misericordia.Data;

namespace misericordia.Controllers
{
    public class DocumentController : Controller
    {

        public readonly MisericordiaContext _context;
        public DocumentController(MisericordiaContext context)
        {
            _context = context;
        }
        string typeOfUser;
        string typeOfDocument;
        string EnterId;
        string typeOfRequest;
        string typeOfRequestNew;

        public IActionResult UserNew(string btnType)
        {
            if (!string.IsNullOrEmpty(btnType))
            {
                HttpContext.Session.SetString("userSend", btnType);
                typeOfUser = HttpContext.Session.GetString("userSend");

            }
            return View();
        }


        public IActionResult TypeDocument(string typeDocument)
{
    if (!string.IsNullOrEmpty(typeDocument))
    {
        HttpContext.Session.SetString("userSend", typeDocument);
        this.typeOfDocument = HttpContext.Session.GetString("userSend");
    }
    return View();
}

public async Task<IActionResult> EnterDocument(string enterDocument)
{
    if (!string.IsNullOrEmpty(enterDocument))
    {
        HttpContext.Session.SetString("userSend", enterDocument);
        this.EnterId = HttpContext.Session.GetString("userSend");

        int documentType = int.Parse(this.typeOfDocument);
        int documentNumber = int.Parse(this.EnterId);

        if(typeOfUser=="2") {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.DocumentType == documentType && u.DocumentNumber == documentNumber);
            if(user != null){
                return RedirectToAction("EnterDocument", "TypeRequestUser"); 
            }else {
                return RedirectToAction("ErrorDocument"); 
            }
        }else{
            return RedirectToAction("EnterDocument", "TypeRequestNewUser"); 
        }
    }
    return View();
}
        public IActionResult TypeRequestUser(string typeRequest)
        {
            if (!string.IsNullOrEmpty(typeRequest))
            {
                HttpContext.Session.SetString("userSend", typeRequest);
                typeOfRequest = HttpContext.Session.GetString("userSend");

            }
            return View();
        }
        public IActionResult TypeRequestNewUser(string typeRequestNew)
        {
            if (!string.IsNullOrEmpty(typeRequestNew))
            {
                HttpContext.Session.SetString("userSend", typeRequestNew);
                typeOfRequestNew = HttpContext.Session.GetString("userSend");

            }
            return View();
        }
public IActionResult ErrorDocument()
{
    return View();
}


    }
}