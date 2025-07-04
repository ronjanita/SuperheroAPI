using SuperheroAPI.Data;
using SuperheroAPI.Models;

namespace SuperheroAPI.Interfaces_und_Repository
{
    public class SuperheroRepository(DataContext context) : ISuperheroRepository
    {
        private readonly DataContext _context = context;
        async Task<Superhero> ISuperheroRepository.CreateSuperhero(Superhero newSuperhero)
        {
            await _context.Superheroes.AddAsync(newSuperhero);
            await _context.SaveChangesAsync();
            return newSuperhero;
            throw new NotImplementedException();
        }

        async Task<bool> ISuperheroRepository.DeleteSuperheroById(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task<ICollection<Superhero>> ISuperheroRepository.GetAllSuperheroes()
        {
            throw new NotImplementedException();
        }

        async Task<string> ISuperheroRepository.GetSuperheroById(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task<bool> ISuperheroRepository.SaveChangesAsync(Superhero newSuperhero)
        {
            throw new NotImplementedException();
        }

        async Task<bool> ISuperheroRepository.UpdateSuperhero(Superhero updatedSuperhero)
        {
            throw new NotImplementedException();
        }
    }
}
