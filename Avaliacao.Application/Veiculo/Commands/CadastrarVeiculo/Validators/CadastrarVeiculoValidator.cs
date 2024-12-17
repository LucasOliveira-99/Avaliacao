using System.Text.RegularExpressions;
using FluentValidation;

namespace Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Validators
{
    public class CadastrarVeiculoValidator : AbstractValidator<CadastrarVeiculoCommand>
    {
        public CadastrarVeiculoValidator()
        {
            RuleFor(c => c.Placa)
                .NotEmpty()
                .NotNull()
                .Matches(new Regex(@"^[A-Z]{3}-\d{4}$|^[A-Z]{3}\d{1}[A-Z]{1}\d{2}$"))
                .WithMessage("A placa informada é inválida.")
                .WithName("Placa");

            RuleFor(c => c.Cor)
                .NotEmpty()
                .NotNull()
                .WithMessage("A cor não pode ser nula.");

            RuleFor(c => c.Modelo)
                .NotEmpty()
                .NotNull()
                .WithMessage("O modelo não pode ser nulo.");

            RuleFor(c => c.Marca)
                .NotEmpty()
                .NotNull()
                .WithMessage("A marca não pode ser nula.");
        }
    }
}