using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Misericordia.Models;

namespace Misericordia.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string valor)
    {

        /* HttpContext.Session.SetString("userSend",valor);
       string variable =  HttpContext.Session.GetString("userSend"); */

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
