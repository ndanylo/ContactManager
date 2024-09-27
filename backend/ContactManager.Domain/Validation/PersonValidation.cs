using FluentValidation;
using ContactManager.Domain.ValueObjects;

namespace ContactManager.Domain.Entities
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Name.Value)
                .SetValidator(new NameValidator());

            RuleFor(person => person.Birthday.Value)
                .SetValidator(new BirthdayValidator());

            RuleFor(person => person.MarriageStatus)
                .NotNull().WithMessage("Marriage status must be defined.");

            RuleFor(person => person.Phone.Value)
                .SetValidator(new PhoneValidator());

            RuleFor(person => person.Salary.Value)
                .SetValidator(new SalaryValidator());
        }
    }
}
