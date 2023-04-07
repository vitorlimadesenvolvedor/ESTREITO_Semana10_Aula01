using Aula01.Controllers;
using FluentValidation;

namespace Aula01.Validators;

public class FilmeCriacaoDtoValidator : AbstractValidator<FilmeCriacaoDto>
{
    public FilmeCriacaoDtoValidator()
    {
        RuleFor(dto => dto.Titulo).Must(ValidarTitulo).WithMessage("Nome proibido").NotEmpty().WithMessage("Título não pode ser vazio").NotNull().WithMessage("Título não pode ser nulo").Length(2, 200).WithMessage("O tamanho do Título deve ser de 2 a 200 caracteres");
        RuleFor(dto => dto.DataDeLancamento).NotEmpty().NotNull().GreaterThan(DateTime.Now);
        RuleFor(dto => dto.Genero).NotEmpty().NotNull().WithMessage("Genêro inválido").Length(2, 10).WithMessage("O tamanho do Título deve ser de 2 a 10 caracteres");
    }

    public bool ValidarTitulo(string titulo)
    {
        if (titulo == "maça" || titulo == "banana")
            return false;
        else
            return true;
    }
}