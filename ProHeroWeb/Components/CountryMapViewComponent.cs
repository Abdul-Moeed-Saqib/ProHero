using Microsoft.AspNetCore.Mvc;

namespace ProHeroWeb.Components
{
    public class CountryMapViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string country)
        {
            return await Task.Run( () => View("Default", country));
        }
    }
}
