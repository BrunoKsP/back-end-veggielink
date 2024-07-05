using FluentValidation;
using VeggieLink.Aplication.Dtos.User;

namespace VeggieLink.Aplication.Validators.User;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("O campo nome e obrigatorio");

        RuleFor(p => p.Description).MaximumLength(200).WithMessage("Tamanho máximo de 200 caracteres");

        RuleFor(p => p.Email).EmailAddress().WithMessage("Email Invalido").NotEmpty().WithMessage("Email é orbigatorio");

        RuleFor(p => p.Password).MaximumLength(10).MinimumLength(8).WithMessage("Tamanho minimo de 8 e máximo de 10 caracteres");
    }
}