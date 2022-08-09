using Domain.Dto;
using FluentValidation;

namespace Core.Validation;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(e => e.Email)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithMessage("Email address is required")
            .EmailAddress()
            .WithMessage("A valid email is required")
            .Length(6,40);
        RuleFor(e => e.Password)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithMessage("Password is required, between 8 and 16 character")
            .Length(8,16);
    }
}