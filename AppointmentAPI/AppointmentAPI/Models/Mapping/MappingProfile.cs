using AutoMapper;
using AutoMapperLibrary;
using MyLibrary;

namespace AppointmentAPI.Models.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            this.CreateMap<Animal, MapperAnimal>();
            this.CreateMap<MapperAnimal, Animal>();
        }
    }
}
