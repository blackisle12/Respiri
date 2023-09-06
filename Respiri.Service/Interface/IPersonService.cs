using Respiri.BusinessModels.Dto;

namespace Respiri.Service.Interface
{
    public interface IPersonService
    {
        Task<GetPersonByIdDto?> Get(int id);
        Task<List<GetPersonDto>?> Get();
    }
}
