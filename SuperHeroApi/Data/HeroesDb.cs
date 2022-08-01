using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;

namespace SuperHeroApi.Data
{
    public class HeroesDb : DbContext
    {
        
        public string ConnectionString { get; set; }
        public HeroesDb(string connection) => ConnectionString = connection;
        /*public HeroesDb(DbContextOptions<HeroesDb> options) : base(options)
        {

        }
        public DbSet<SuperHero> Hero => Set<SuperHero>();*/
    }
}
