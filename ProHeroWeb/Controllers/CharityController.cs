using Microsoft.AspNetCore.Mvc;
using ProHeroWeb.Models;

namespace ProHeroWeb.Controllers
{
    public class CharityController : Controller
    {
        public IActionResult CharityList(string country)
        {
            var charities = new List<Test>();
            var charity = new Test();
            charity.Name = "Afghanistan Care";
            charity.Country = "Afghanistan";
            charity.Location = "Ottawa, Canada";
            charity.Description = "...";
            var charity1 = new Test();
            charity1.Name = "Islamic Foundation";
            charity1.Country = "Afghanistan";
            charity1.Location = "Toronto, Canada";
            charity1.Description = "...";
            var charity2 = new Test();
            charity2.Name = "Yemen Light";
            charity2.Country = "Yemen";
            charity2.Location = "California, USA";
            charity2.Description = "...";
            var charity3 = new Test();
            charity3.Name = "Random";
            charity3.Country = "Afghanistan";
            charity3.Location = "California, USA";
            charity3.Description = "...";
            var charity4 = new Test();
            charity4.Name = "hello";
            charity4.Country = "Afghanistan";
            charity4.Location = "California, USA";
            charity4.Description = "...";
            var charity5 = new Test();
            charity5.Name = "There";
            charity5.Country = "Afghanistan";
            charity5.Location = "California, USA";
            charity5.Description = "...";
            var charity6 = new Test();
            charity6.Name = "My friend";
            charity6.Country = "Afghanistan";
            charity6.Location = "California, USA";
            charity6.Description = "...";
            var charity7 = new Test();
            charity7.Name = "Nice ONe";
            charity7.Country = "Afghanistan";
            charity7.Location = "California, USA";
            charity7.Description = "...";

            charities.Add(charity);
            charities.Add(charity1);
            charities.Add(charity2);
            charities.Add(charity3);
            charities.Add(charity4);
            charities.Add(charity5);
            charities.Add(charity6);
            charities.Add(charity7);

            var countryCharities = charities.Where(x => x.Country.Equals(country));

            return View("CharityList", countryCharities);
        }
    }
}
