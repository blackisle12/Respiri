using AutoMapper;
using Respiri.BusinessModels.Dto;
using Respiri.Repository.Entity;

namespace Respiri.Service.MappingProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, GetPersonByIdDto>();
            CreateMap<Person, GetPersonDto>();
        }
    }
}
