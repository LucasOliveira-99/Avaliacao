using FluentValidation;

namespace Avaliacao.Application.Veiculo.Commands.FinalizarAluguel.Validators
{
    public class FinalizarAluguelValidator : AbstractValidator<FinalizarAluguelCommand>
    {
        public FinalizarAluguelValidator()
        {
            RuleFor(c => c.AluguelId)
                .NotEmpty()
                .NotNull()
                .WithMessage("O aluguel não pode ser nulo.")
                .WithName("AluguelId");
            RuleFor(c => c.DataDevolucao)
                .NotEmpty()
                .NotNull()
                .WithMessage("A data de devolução não pode ser nula.")
                .WithName("DataDevolucao");
        }
    }
}
