using Avaliacao.Application.Veiculo.Commands.FinalizarAluguel.Validators;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;

namespace Avaliacao.Application.Veiculo.Commands.FinalizarAluguel
{
    public class FinalizarAluguelCommand : Command
    {
        public int AluguelId { get; set; }

        public DateTime DataDevolucao { get; set; }

        public override bool IsValid()
        {
            AdicionarErros(new FinalizarAluguelValidator().Validate(this));
            return ValidationResult.IsValid;
        }
    }
}