using FluentValidation;

namespace ContactManager.Domain.ValueObjects
{
    public class PhoneValidator : AbstractValidator<string>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{1,14}$").WithMessage("Phone number must be in a valid format.");
        }
    }
}