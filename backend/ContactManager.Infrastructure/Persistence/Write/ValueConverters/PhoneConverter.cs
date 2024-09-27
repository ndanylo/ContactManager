using ContactManager.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactManager.Infrastructure.Persistence.Write.ValueConverters
{
    public class PhoneConverter : ValueConverter<Phone, string>
    {
        public PhoneConverter() 
            : base(
                phone => phone.Value, 
                value => Phone.Create(value).Value
            ) { }
    }
}
