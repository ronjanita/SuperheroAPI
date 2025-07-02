using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;
using SuperheroAPI.Models;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperheroController(DataContext context)
        {
         }

        [HttpGet]
        [Route("getAllHeroes")]
        public ICollection<Superhero> GetSuperHero()
        {
            return [.. _context.Superheroes];
        }

        [HttpPost]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero)
        {
            _context.Superheroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await  _context.Superheroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetHero(int id)
        {
            var hero = await _context.Superheroes.FindAsync(id);
            if (hero is null)
            {
                return NotFound("Hero not found");
            }
            else
            {
                return Ok(hero);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Superhero>> UpdateHero(Superhero updatedHero)
        {
            var dbHero = await _context.Superheroes.FindAsync(updatedHero.Id);
            if (dbHero is null)
            {
                return NotFound("Hero not found");
            }
            else
            {
                dbHero.Name = updatedHero.Name;
                dbHero.FirstName = updatedHero.FirstName;
                dbHero.LastName = updatedHero.LastName;
                dbHero.Place = updatedHero.Place;

                await _context.SaveChangesAsync();
            }
            return Ok(await _context.Superheroes.ToListAsync());  
        }

        [HttpDelete]
        public async Task<ActionResult<List<Superhero>>> DeleteHero(int Id)
        {
            var hero = await _context.Superheroes.FindAsync(Id);
            if (hero is null)
            {
                return NotFound("Hero not found");
            }
            else
            {
                _context.Superheroes.Remove(hero);
                await _context.SaveChangesAsync();
            }
            return Ok(await _context.Superheroes.ToListAsync());
        }
    }
}
