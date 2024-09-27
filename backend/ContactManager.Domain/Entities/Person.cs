using ContactManager.Domain.ValueObjects;
using CSharpFunctionalExtensions;

namespace ContactManager.Domain.Entities
{
    public class Person: Entity
    {
        public Name Name { get; private set; }

        public Birthday Birthday { get; private set; }

        public MarriageStatus MarriageStatus {get; private set;}

        public Phone Phone { get; private set; }

        public Salary Salary { get; private set; }

        private Person(
            Name name,
            Birthday birthday,
            MarriageStatus marriageStatus,
            Phone phone, 
            Salary salary
        )
        {
            Name = name;
            Birthday = birthday;
            MarriageStatus = marriageStatus;
            Phone = phone;
            Salary = salary;
        }

        public static Result<Person> Create(
            string name,
            DateTime birthday,
            bool isMarried,
            string phone,
            decimal salary
        )
        {
            return Birthday.Create(birthday)
                .Bind(validBirthday => Name.Create(name)
                    .Bind(validName => Phone.Create(phone)
                        .Bind(validPhone => Salary.Create(salary)
                            .Map(validSalary => new Person(
                                validName, 
                                validBirthday, 
                                isMarried ? MarriageStatus.Married : MarriageStatus.Single,
                                validPhone, 
                                validSalary)
                            )
                        )
                    ));
        }

        public Result SetName(Name name)
        {
            var validator = new NameValidator();
            var validationResult = validator.Validate(name.Value);
            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            }
            Name = name;
            return Result.Success();
        }

        public Result SetBirthday(Birthday birthday)
        {
            var validator = new BirthdayValidator();
            var validationResult = validator.Validate(birthday.Value);
            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            }
            Birthday = birthday;
            return Result.Success();
        }

        public Result SetPhone(Phone phone)
        {
            var validator = new PhoneValidator();
            var validationResult = validator.Validate(phone.Value);
            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            }
            Phone = phone;
            return Result.Success();
        }

        public Result SetSalary(Salary salary)
        {
            var validator = new SalaryValidator();
            var validationResult = validator.Validate(salary.Value);
            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors.First().ErrorMessage);
            }
            Salary = salary;
            return Result.Success();
        }
    }
}