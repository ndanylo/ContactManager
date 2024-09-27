using ContactManager.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactManager.Infrastructure.Persistence.Write.ValueConverters
{
   public class NameConverter : ValueConverter<Name, string>
    {
        public NameConverter() 
            : base(
                name => name.Value, 
                value => Name.Create(value).Value
            ) { }
    }
}
