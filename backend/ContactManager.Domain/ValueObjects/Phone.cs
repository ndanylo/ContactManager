using CSharpFunctionalExtensions;

namespace ContactManager.Domain.ValueObjects
{
    public class Phone: ValueObject
    {
        public string Value { get; private set; } = string.Empty;

        private Phone(string phone)
        {
            Value = phone;
        }

        public static Result<Phone> Create(string phone)
        {
            var validator = new PhoneValidator();
            var result = validator.Validate(phone);
            
            if(result.IsValid)
            {
                return Result.Success(new Phone(phone));
            }

            return Result.Failure<Phone>(string.Join(";",
                result.Errors
                .Select(e => e.ErrorMessage))
            );
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}