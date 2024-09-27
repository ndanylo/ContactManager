using CSharpFunctionalExtensions;

namespace ContactManager.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string Value { get; private set; } = string.Empty;

        private Name(string value)
        {
            Value = value;
        }

        public static Result<Name> Create(string name)
        {
            var validator = new NameValidator();
            var result = validator.Validate(name);

            if(result.IsValid)
            {
                return Result.Success(new Name(name));
            }
            
            return Result.Failure<Name>(string.Join(";",
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