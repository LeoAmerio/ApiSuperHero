using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;

namespace SuperHeroApi.Data
{
    public class HeroesDb : DbContext
    {
        
        public string ConnectionString { get; set; }
        public HeroesDb(string connection) => ConnectionString = connection;
        
    }
}
