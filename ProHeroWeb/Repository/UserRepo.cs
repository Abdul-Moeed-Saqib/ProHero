using ProHeroWeb.Data;
using ProHeroWeb.Models;
using ProHeroWeb.Services;

namespace ProHeroWeb.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ProHeroDbContext proHeroDb;

        public UserRepo(ProHeroDbContext proHeroDb)
        {
            this.proHeroDb = proHeroDb;
        }

        public void AddUser(User user)
        {
            proHeroDb.Users.Add(user);
            proHeroDb.SaveChanges();
        }

        public Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
