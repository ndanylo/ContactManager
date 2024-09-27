using CSharpFunctionalExtensions;

namespace ContactManager.Domain.ValueObjects
{
    public class Salary: ValueObject
    {
        public decimal Value { get; private set; }

        private Salary(decimal salary)
        {
            Value = salary;
        }

        public static Result<Salary> Create(decimal salary)
        {
            var validator = new SalaryValidator();
            var result = validator.Validate(salary);

            if(result.IsValid)
            {
                return Result.Success(new Salary(salary));
            }

             return Result.Failure<Salary>(string.Join(";",
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