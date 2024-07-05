using FluentValidation;
using VeggieLink.Aplication.Dtos.Products;

namespace VeggieLink.Aplication.Validators.ProductValidator;

public class ChangeProductValidator : AbstractValidator<ChangeProductDto>
{
    public ChangeProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("O campo nome e obrigatorio");

        RuleFor(p => p.Description).MaximumLength(200).WithMessage("Tamanho máximo de 200 caracteres");

        RuleFor(p => p.PlantingDate).NotEmpty().WithMessage("Data de plantio é obrigatorio");

        RuleFor(p => p.Status).NotEmpty().WithMessage("Status nao pode ser vazio")
        ;
    }
}