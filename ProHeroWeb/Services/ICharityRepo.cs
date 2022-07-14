using ProHeroWeb.Models;

namespace ProHeroWeb.Services
{
    public interface ICharityRepo
    {
        IEnumerable<Charity> GetCharitiesByCountry(string country);
        Task<Charity> GetCharityById(string id);
    }
}
