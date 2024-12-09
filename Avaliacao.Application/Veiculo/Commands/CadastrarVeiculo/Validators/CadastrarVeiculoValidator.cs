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
                .WithMessage("A placa informada é inválida.")
                .WithName("Placa");

            RuleFor(c => c.Cor)
                .NotEmpty()
                .NotNull()
                .WithMessage("A cor não deve ser nulo.");

            RuleFor(c => c.Modelo)
                .NotEmpty()
                .NotNull()
                .WithMessage("O modelo não deve ser nulo.");

            RuleFor(c => c.Marca)
                .NotEmpty()
                .NotNull()
                .WithMessage("A marca não deve ser nula.");
        }
    }
}