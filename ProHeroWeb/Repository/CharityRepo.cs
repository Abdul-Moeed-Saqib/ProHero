using ProHeroWeb.Data;
using ProHeroWeb.Models;
using ProHeroWeb.Services;

namespace ProHeroWeb.Repository
{
    public class CharityRepo : ICharityRepo
    {
        private readonly ProHeroDbContext proHeroDb;

        public CharityRepo(ProHeroDbContext proHeroDb)
        {
            this.proHeroDb = proHeroDb;
        }

        public IEnumerable<Charity> GetCharitiesByCountry(string country)
        {
            return proHeroDb.Charities.Where(x => x.Country == country);
        }

        public async Task<Charity> GetCharityById(string id)
        {
            return await proHeroDb.Charities.FindAsync(long.Parse(id));
        }
    }
}
