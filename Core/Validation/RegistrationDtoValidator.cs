using Domain.Dto;
using FluentValidation;

namespace Core.Validation;

public class RegistrationDtoValidator : AbstractValidator<RegistrationDto>
{
    public RegistrationDtoValidator()
    {
        RuleFor(e => e.Email).NotEmpty();
        RuleFor(e => e.Password).NotEmpty();
        RuleFor(e => e.FirstName).NotEmpty();
        RuleFor(e => e.LastName).NotEmpty();
    }
}