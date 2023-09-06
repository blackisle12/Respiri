using Respiri.Repository.Entity;

namespace Respiri.Repository.Interface
{
    public interface IPersonRepository
    {
        Task<Person?> Get(int id);
        Task<List<Person>?> Get();
    }
}
