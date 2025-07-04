using SuperheroAPI.Models;

namespace SuperheroAPI.Interfaces_und_Repository
{
    public class SuperheroRepository : ISuperheroRepository
    {
        Task<string> ISuperheroRepository.CreateSuperhero(Superhero newSuperhero)
        {
            throw new NotImplementedException();
        }

        Task<bool> ISuperheroRepository.DeleteSuperheroById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<Superhero>> ISuperheroRepository.GetAllSuperheroes()
        {
            throw new NotImplementedException();
        }

        Task<string> ISuperheroRepository.GetSuperheroById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ISuperheroRepository.SaveChangesAsync(Superhero newSuperhero)
        {
            throw new NotImplementedException();
        }

        Task<bool> ISuperheroRepository.UpdateSuperhero(Superhero updatedSuperhero)
        {
            throw new NotImplementedException();
        }
    }
}
