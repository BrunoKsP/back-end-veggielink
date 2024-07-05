using aplication.Dtos.Error;
using aplication.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace aplication.Services;

public class BaseService
{
    public BaseService()
    {

    }
    protected static void Validate<TV, TM>(TV validacao, TM viewModel) where TV : AbstractValidator<TM>
    {
        var validador = validacao.Validate(viewModel);

        if (validador.IsValid) return;

        var errors = ProcessErrors(validador);

        throw CustomException.ErroValidacao(errors);
    }

    protected static async Task ValidateAsync<TV, TM>(TV validacao, TM viewModel) where TV : AbstractValidator<TM>
    {
        var validador = await validacao.ValidateAsync(viewModel);

        if (validador.IsValid) return;

        var errors = ProcessErrors(validador);

        throw CustomException.ErroValidacao(errors);
    }

    private static IEnumerable<ErrorDto> ProcessErrors(ValidationResult result)
    {
        return result.Errors.Select(e => new ErrorDto
        {
            Error = e.ErrorMessage,
            ErrorCode = e.ErrorCode,
            Property = e.PropertyName
        });
    }
}