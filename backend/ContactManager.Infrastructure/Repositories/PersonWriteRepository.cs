using ContactManager.Domain.Abstractions;
using ContactManager.Domain.Entities;
using ContactManager.Infrastructure.Persistence.Read.Models;
using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.Repositories
{
    public class PersonWriteRepository : IWriteRepository<Person, long>
    {
        private readonly PersonDbContext _dbContext;

        private readonly IValidator<Person> _personValidator;

        public PersonWriteRepository(
            PersonDbContext dbContext,
            IValidator<Person> personValidator)
        {
            _personValidator = personValidator;
            _dbContext = dbContext;
        }

        public async Task<Result> AddAsync(Person entity)
        {
            var validationResult = _personValidator.Validate(entity);
            if(!validationResult.IsValid)
            {
                return Result.Failure(string.Join(";",
                    validationResult.Errors.Select(e => e.ErrorMessage)
                ));
            }
            
            try
            {
                await _dbContext.People.AddAsync(entity);

                return Result.Success();
            }
            catch(Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result<bool>> RemoveAsync(long id)
        {
            try
            {
                var person = await _dbContext.People
                    .FirstOrDefaultAsync(person => person.Id == id);
            
                if(person != null)
                {                   
                    var deleteResult = _dbContext.Remove(person);
                    return Result.Success(true);
                }

               return Result.Success(false);
            }
            catch(Exception ex)
            {
                return Result.Failure<bool>(ex.Message);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Result> UpdateAsync(Person entity, long id)
        {
            var validationResult = _personValidator.Validate(entity);
            if(!validationResult.IsValid)
            {
                return Result.Failure(string.Join(";",
                    validationResult.Errors.Select(e => e.ErrorMessage)
                ));
            }

            try
            {
                var person = await _dbContext.People
                    .FirstOrDefaultAsync(person => person.Id == id);

                if(person == null)
                {
                    Result.Failure("Person wasn`t found");
                }
                else
                {
                    person.SetBirthday(entity.Birthday);
                    person.SetSalary(entity.Salary);
                    person.SetName(entity.Name);
                    person.SetPhone(entity.Phone);
                }
            
                return Result.Success();
            }
            catch(Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}