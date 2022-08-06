using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Charity>> GetCharitiesByCountry(string country)
        {
            return await proHeroDb.Charities.Where(c => c.Country == country).ToListAsync();
        }

        public async Task<Charity> GetCharityById(string id)
        {
            return await proHeroDb.Charities.FirstOrDefaultAsync(c => c.CharityId == long.Parse(id));
        }
    }
}
