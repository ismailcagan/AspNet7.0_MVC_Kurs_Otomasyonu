using Microsoft.AspNetCore.Mvc;

namespace KursOtomasyonuApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
