using ContactManager.Domain.Abstractions;
using ContactManager.Infrastructure.Persistence.Read.Models;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.Repositories
{
    public class PersonReadRepository : IReadRepository<PersonReadModel, long>
    {
        private readonly PersonReadModelDbContext _dbContext;

        public PersonReadRepository(PersonReadModelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<IEnumerable<PersonReadModel>>> GetAllAsync()
        {
            try
            {
               var peopleList = await _dbContext.People.ToListAsync();
               return Result.Success(peopleList.AsEnumerable());
            }
            catch(Exception ex)
            {
                return Result.Failure<IEnumerable<PersonReadModel>>(ex.Message);
            }
        }

        public async Task<Result<PersonReadModel?>> GetAsync(long id)
        {
            try
            {
               var person = await _dbContext.People
                .FirstOrDefaultAsync(person => person.Id == id);

               return Result.Success(person);
            }
            catch(Exception ex)
            {
                return Result.Failure<PersonReadModel?>(ex.Message);
            }
        }
    }
}