using Microsoft.AspNetCore.Mvc;
using ProHeroWeb.Helpers;
using ProHeroWeb.Models;
using ProHeroWeb.Services;

namespace ProHeroWeb.Controllers
{
    public class CharityController : Controller
    {
        private readonly ICharityRepo charityRepo;

        public CharityController(ICharityRepo charityRepo)
        {
            this.charityRepo = charityRepo;
        }

        public async Task<IActionResult> CharityList(string country)
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "country", country);
            return View("CharityList", await charityRepo.GetCharitiesByCountry(country));
        }

        [HttpPost]
        public async Task<IActionResult> Details(string charityId)
        {
            var charity = await charityRepo.GetCharityById(charityId); 
            return View("Details", charity);  
        }

        public IActionResult CountriesPartial()
        {
            string country = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "country");

            //if (!System.IO.File.Exists($@"Views\Charity\Countries\_{country}.cshtml"))
            //{
            //    country = "None";
            //}

            return PartialView($"Countries/_{country}");
        }
    }
}
