using aplication.Dtos.Products;
using FluentValidation;

namespace VeggieLink.Aplication.Validators.ProductValidator;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("O campo nome e obrigatorio");

        RuleFor(p => p.Description).MaximumLength(200).WithMessage("Tamanho máximo de 200 caracteres");

        RuleFor(p => p.PlantingDate).NotEmpty().WithMessage("Data de plantio é obrigatorio");
    }
}