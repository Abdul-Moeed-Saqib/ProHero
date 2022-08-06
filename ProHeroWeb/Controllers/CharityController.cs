using Microsoft.AspNetCore.Mvc;
using ProHeroWeb.Data;
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

        public IActionResult CharityList(string country)
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "country", country);
            return View("CharityList");
        }

        public async Task<IActionResult> CharityPartial()
        {
            string country = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "country");
            return PartialView("_Charity", await charityRepo.GetCharitiesByCountry(country));
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

        [HttpPost]
        public List<object> GetHungerStatus()
        {
            string country = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "country");
            List<CountryStatus> countryStatus = SessionHelper.GetObjectFromJson<List<CountryStatus>>(HttpContext.Session, "status");
            List<object> status = new List<object>();

            status.Add(CountryHungerStatus.yearLabels);

            var countryStatusPerc = countryStatus.Find(c => c.CountryName.Equals(country));

            float[] hungerPerc = new float[]
            {
                countryStatusPerc.TwintyNineteen, 
                countryStatusPerc.TwintyEighteen, 
                countryStatusPerc.TwintySevenTeen,
                countryStatusPerc.TwintySixteen,
                countryStatusPerc.TwintyFifteen
            };

            status.Add(hungerPerc);

            return status;
        }
    }
}
