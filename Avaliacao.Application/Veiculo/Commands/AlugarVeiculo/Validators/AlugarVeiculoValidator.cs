using FluentValidation;

namespace Avaliacao.Application.Veiculo.Commands.AlugarVeiculo.Validators
{
    public class AlugarVeiculoValidator : AbstractValidator<AlugarVeiculoCommand>
    {
        public AlugarVeiculoValidator()
        {
            RuleFor(c => c.VeiculoId)
                .NotEmpty()
                .NotNull()
                .WithMessage("O veículo não pode ser nulo.")
                .WithName("VeiculoId");
            RuleFor(c => c.DataInicio)
                .NotEmpty()
                .NotNull()
                .WithMessage("A data de início não pode ser nula.")
                .WithName("DataInicio");
            RuleFor(c => c.DataFim)
                .NotEmpty()
                .NotNull()
                .WithMessage("A data de fim não pode ser nula.")
                .WithName("DataFim");
            RuleFor(c => c.Valor)
                .NotEmpty()
                .NotNull()
                .WithMessage("O valor não pode ser nulo.")
                .WithName("Valor");
        }
    }
}