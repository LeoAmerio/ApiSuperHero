using SuperHeroApi.Models;

namespace SuperHeroApi.Repositories
{
    public interface ISuperHeroRepo
    {
        Task<IEnumerable<SuperHero>> GetAllHeroes();
        Task<SuperHero> GetHeroById(int id);
        Task<bool> InsertHero(SuperHero superHero);
        Task<bool> UpdateHero(SuperHero superHero);
        Task<bool> DeleteHero(SuperHero superHero);
    }
}
