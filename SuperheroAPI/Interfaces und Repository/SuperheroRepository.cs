using Microsoft.EntityFrameworkCore;
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
            var superheroremove = await _context.Superheroes.FindAsync(id);
            if (superheroremove == null) throw new NotImplementedException();
            _context.Superheroes.Remove(superheroremove);
            await _context.SaveChangesAsync();
            return true;  //es wurd ein superhero mit ideser id gefunden und erfolgreich gelöscht
        }

        async Task<ICollection<Superhero>> ISuperheroRepository.GetAllSuperheroes()
        {
            var superheroeslist = await _context.Superheroes.ToListAsync();
            return superheroeslist;
            throw new NotImplementedException();
        }

        async Task<Superhero> ISuperheroRepository.GetSuperheroById(Guid id)
        {
            var superhero = await _context.Superheroes.FindAsync(id);
            return superhero;
            throw new NotImplementedException();
        }

        async Task<bool> ISuperheroRepository.SaveChangesAsync(Superhero newSuperhero)
        {
            throw new NotImplementedException();
        }

        async Task<Superhero> ISuperheroRepository.UpdateSuperhero(Superhero updatedSuperhero)
        {
            var existing = await _context.Superheroes.FindAsync(updatedSuperhero.Id);

            if (existing == null) throw new NotImplementedException();
            existing.Name = updatedSuperhero.Name;
            existing.FirstName = updatedSuperhero.FirstName;
            existing.LastName = updatedSuperhero.LastName;
            existing.Place = updatedSuperhero.Place;
            await _context.SaveChangesAsync();
            return updatedSuperhero;  //gibt updatete version zurück
        }
    }
}
