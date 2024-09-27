using FluentValidation;

namespace ContactManager.Domain.ValueObjects
{
    public class SalaryValidator : AbstractValidator<decimal>
    {
        public SalaryValidator()
        {
            RuleFor(salary => salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0");
        }
    }
}