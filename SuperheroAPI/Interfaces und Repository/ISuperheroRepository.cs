using SuperheroAPI.Models;

namespace SuperheroAPI.Interfaces_und_Repository
{
    public interface ISuperheroRepository
    {
        Task<bool> DeleteSuperheroById(Guid id);
        Task<ICollection<Superhero>> GetAllSuperheroes();
        Task<string> GetSuperheroById(Guid id);
        Task<Superhero> CreateSuperhero(Superhero newSuperhero);
        Task<bool> UpdateSuperhero(Superhero updatedSuperhero);
        Task<bool> SaveChangesAsync(Superhero newSuperhero);
    }
}
