using Microsoft.EntityFrameworkCore;
using ProHeroWeb.Models;

namespace ProHeroWeb.Data
{
    public class ProHeroDbContext : DbContext
    {
        public ProHeroDbContext(DbContextOptions<ProHeroDbContext> options) : base(options) { }

        public virtual DbSet<Charity> Charities { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
