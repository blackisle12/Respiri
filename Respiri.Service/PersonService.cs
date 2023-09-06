using AutoMapper;
using Respiri.BusinessModels.Dto;
using Respiri.Repository.Interface;
using Respiri.Service.Interface;

namespace Respiri.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository repository;
        private readonly IMapper mapper;

        public PersonService(
            IPersonRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<GetPersonByIdDto?> Get(int id)
        {
            var person = await repository.Get(id);

            return mapper.Map<GetPersonByIdDto?>(person);
        }

        public async Task<List<GetPersonDto>?> Get()
        {
            var people = await repository.Get();

            return mapper.Map<List<GetPersonDto>?>(people);
        }
    }
}
