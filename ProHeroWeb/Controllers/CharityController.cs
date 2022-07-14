using Microsoft.AspNetCore.Mvc;
using ProHeroWeb.Models;
using ProHeroWeb.Services;

namespace ProHeroWeb.Controllers
{
    public class CharityController : Controller
    {
        //private List<Test> charities;
        private ICharityRepo charityRepo;

        public CharityController(ICharityRepo charityRepo)
        {
            this.charityRepo = charityRepo;
        }

        public IActionResult CharityList(string country)
        {
            return View("CharityList", charityRepo.GetCharitiesByCountry(country));
        }

        public IActionResult Details(string charityId)
        {
            var charity = charityRepo.GetCharityById(charityId).Result; 
            return View("Details", charity);  
        }
    }
}
