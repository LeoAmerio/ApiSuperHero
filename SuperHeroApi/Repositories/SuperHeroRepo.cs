using SuperHeroApi.Models;
using System.Data;
using Npgsql;
using Dapper;

namespace SuperHeroApi.Repositories
{
    public class SuperHeroRepo : ISuperHeroRepo
    {
        private IDbConnection _db;
        public SuperHeroRepo(IDbConnection connection1)
        {
            _db = connection1;
    
        }

        public async Task<bool> DeleteHero(SuperHero superHero)
        {
            var db = _db;
            var sql = @"
                        DELETE
                        FROM public.""Heroes""
                        WHERE id = @Id
                ";

            var result = await db.ExecuteAsync(sql, new { Id = superHero.Id });
            return result > 0;
        }

        public async Task<IEnumerable<SuperHero>> GetAllHeroes()
        {
            var db = _db;
            var sql = @"
                        SELECT id, name, firstName, lastName, place
                        FROM public.""Heroes""
                        ";

            return await db.QueryAsync<SuperHero>(sql, new { });
        }

        public async Task<SuperHero> GetHeroById(int id)
        {
            var db = _db;
            var sql = @"
                        SELECT id, name, firstName, lastName, place
                        FROM public.""Heroes""
                        WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<SuperHero>(sql, new { Id = id });
        }

        public async Task<bool> InsertHero(SuperHero superHero)
        {
            var db = _db;
            var sql = @"
                        INSERT INTO public.""Heroes""(id, name, firstName, lastName, place)
                        VALUES(@Id, @Name, @FirstName, @LastName, @Place);";

            var result = await db.ExecuteAsync(sql, new { superHero.Id, superHero.Name, superHero.FirsName, superHero.LastName, superHero.Place });
            return result > 0;
        }

        public async Task<bool> UpdateHero(SuperHero superHero)
        {
            var db = _db;
            var sql = @"
                        UPDATE public.""Heroes""
                        SET id = @Id,
                            name = @Name,
                            firstName = @FirstName,
                            lastName = @LastName,
                            place = @Place
                        WHERE id = @Id";

            var result = await _db.ExecuteAsync(sql, new { superHero.Id, superHero.Name, superHero.FirsName, superHero.LastName, superHero.Place });
            return result > 0;
        }
    }
}
