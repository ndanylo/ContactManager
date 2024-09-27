using ContactManager.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactManager.Infrastructure.Persistence.Write.ValueConverters
{
    public class BirthdayConverter : ValueConverter<Birthday, DateTime>
    {
        public BirthdayConverter() 
            : base(
                birthday => birthday.Value, 
                date => Birthday.Create(date).Value
            ) { }
    }
}
