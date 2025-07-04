using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;
using SuperheroAPI.DTO;
using SuperheroAPI.Interfaces_und_Repository;
using SuperheroAPI.Models;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController(ISuperheroRepository superheroRepository, IMapper mapper) : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ISuperheroRepository _superheroRepository = superheroRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Route("getAllHeroes")]
        public async Task<ActionResult<List<SuperheroDTO>>> GetSuperheroes()
        {
            ICollection<Superhero> heroes = await _superheroRepository.GetAllSuperheroes();
            List<SuperheroDTO> heroesDto = _mapper.Map<List<SuperheroDTO>>(heroes);
            return Ok(heroesDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddHero([FromBody] CreateSuperheroDTO hero)
        {
            Superhero mappedHero = _mapper.Map<Superhero>(hero);
            _context.Superheroes.Add(mappedHero);
            await _context.SaveChangesAsync();
            return Ok(hero);
        }

            [HttpGet("{id}")]
        public async Task<ActionResult<SuperheroDTO>> GetHero(Guid id)
        {
            var hero = await _superheroRepository.GetSuperheroById(id);
            if (hero is null) return NotFound("Hero not found");
            var heroDTO = _mapper.Map<SuperheroDTO>(hero);
            return Ok(heroDTO);

        }

        [HttpPut]
        public async Task<ActionResult> UpdateHero(Guid id, [FromBody] UpdateSuperheroDTO heroDto)  //afgrunde von update wird auch vererbt superhero mit namen etc deswegen nciht mehr schreiebn selebr
        {
            var existingHero = await _superheroRepository.GetSuperheroById(id);
            if (existingHero == null)
                return NotFound("Hero not found");

            _mapper.Map(heroDto, existingHero); // 

            await _superheroRepository.UpdateSuperhero(existingHero);
            var updatedHeroDTO = _mapper.Map<SuperheroDTO>(existingHero);
            return Ok(updatedHeroDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteHero(Guid id)
        {
            var hero = await _superheroRepository.GetSuperheroById(id);
            if (hero == null)
                return NotFound("Hero not found");

            await _superheroRepository.DeleteSuperheroById(id);

            return NoContent();
        }
    }
}
