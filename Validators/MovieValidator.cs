using Aula01.Models;
using FluentValidation;

namespace Aula01.Validators;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(movie => movie.Titulo).NotEmpty().NotNull().WithMessage("Título inválido").Length(2, 200).WithMessage("O tamanho do Título deve ser de 2 a 200 caracteres");
        RuleFor(movie => movie.DataDeLancamento).NotEmpty().NotNull().GreaterThan(DateTime.Now);
        RuleFor(movie => movie.Genero).NotEmpty().NotNull().WithMessage("Genêro inválido").Length(2, 10).WithMessage("O tamanho do Título deve ser de 2 a 10 caracteres");
    }
}