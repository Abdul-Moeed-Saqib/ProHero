using ProHeroWeb.Models;

namespace ProHeroWeb.Services
{
    public interface ICharityRepo
    {
        Task<IEnumerable<Charity>> GetCharitiesByCountry(string country);
        Task<Charity> GetCharityById(string id);
        void AddCharity(Charity charity);
    }
}
