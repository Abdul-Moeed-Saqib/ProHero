using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Country = country;
            return View("CharityList", await charityRepo.GetCharitiesByCountry(country));
        }

        [HttpPost]
        public async Task<IActionResult> Details(string charityId)
        {
            var charity = await charityRepo.GetCharityById(charityId); 
            return View("Details", charity);  
        }
    }
}
