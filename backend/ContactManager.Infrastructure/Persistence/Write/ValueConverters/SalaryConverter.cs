using ContactManager.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactManager.Infrastructure.Persistence.Write.ValueConverters
{
    public class SalaryConverter : ValueConverter<Salary, decimal>
    {
        public SalaryConverter() 
            : base(
                salary => salary.Value, 
                value => Salary.Create(value).Value
            ) { }
    }
}
