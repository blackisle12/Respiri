using Microsoft.EntityFrameworkCore;
using Respiri.Repository.Entity;
using Respiri.Repository.Interface;

namespace Respiri.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppContext context;

        public PersonRepository(AppContext context)
        {
            this.context = context;
        }

        public async Task<Person?> Get(int id)
        {
            var person = await context.Person.FindAsync(id);

            return person;
        }

        public async Task<List<Person>?> Get()
        {
            var people = await context.Person
                .AsNoTracking()
                .ToListAsync();

            return people;
        }
    }
}
