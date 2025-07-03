using AutoMapper;
using SuperheroAPI.DTO;
using SuperheroAPI.Models;

namespace SuperheroAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Superhero, SuperheroDTO>();
            CreateMap<Superhero, SuperheroDTO>().ReverseMap();
        }
    }
}
