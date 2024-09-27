using CSharpFunctionalExtensions;

namespace ContactManager.Domain.ValueObjects
{
    public class Birthday : ValueObject
    {
        public DateTime Value { get; private set; }

        private Birthday(DateTime birthday)
        {
            Value = birthday;
        }

        public static Result<Birthday> Create(DateTime birthday)
        {
            var validator = new BirthdayValidator();
            var result = validator.Validate(birthday);

            if(result.IsValid)
            {
                return Result.Success(new Birthday(birthday));
            }
            
            return Result.Failure<Birthday>(string.Join(";",
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