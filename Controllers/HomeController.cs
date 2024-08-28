using AreEyeP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AreEyeP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
