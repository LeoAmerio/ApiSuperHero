using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Data;
using SuperHeroApi.Models;
using SuperHeroApi.Repositories;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ISuperHeroRepo _repo;
        public SuperHeroController(IConfiguration config, ISuperHeroRepo repo)
        {
            _config = config;
            _repo = repo;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Get()
        {        
            return Ok(await _repo.GetAllHeroes());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetHeroDetail(int id)
        {
            return Ok(await _repo.GetHeroById(id));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateHero(SuperHero hero)
        {
            if (hero == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _repo.InsertHero(hero);

            return Created("created", created);
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Update([FromBody]SuperHero hero)
        {
            if (hero == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.UpdateHero(hero);

            return NoContent();

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            await _repo.DeleteHero( new SuperHero { Id = id } );

            return NoContent();
        }
    }
}
