using ProHeroWeb.Models;

namespace ProHeroWeb.Services
{
    public interface IUserRepo
    {
        Task<User> GetUserById(string id);
        void AddUser(User user);
    }
}
