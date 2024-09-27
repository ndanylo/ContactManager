using FluentValidation;

namespace ContactManager.Domain.ValueObjects
{
    public class NameValidator : AbstractValidator<string>
    {
        public NameValidator()
        {
            RuleFor(name => name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name`s length must be >= 2 symbols");
        }
    }
}