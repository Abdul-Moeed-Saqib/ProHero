using Microsoft.AspNetCore.Mvc;
using ProHeroWeb.Data;
using ProHeroWeb.Helpers;
using ProHeroWeb.Models;
using System.Diagnostics;

namespace ProHeroWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "status", CountryHungerStatus.ResultStatus());
            ViewBag.Status = SessionHelper.GetObjectFromJson<List<CountryStatus>>(HttpContext.Session, "status");
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
}