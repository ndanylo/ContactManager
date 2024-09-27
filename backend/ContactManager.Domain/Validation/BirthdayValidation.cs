using FluentValidation;

namespace ContactManager.Domain.ValueObjects
{
    public class BirthdayValidator : AbstractValidator<DateTime>
    {
        public BirthdayValidator()
        {
            RuleFor(date => date)
                .NotEmpty().WithMessage("Birthday can not be empty.")
                .LessThan(DateTime.Today).WithMessage("Birthday can not be in future.");
        }
    }
}