using Avaliacao.Application.Veiculo.Commands.AlugarVeiculo.Validators;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Infraestructure.CrossCutting.Common.Enums;

namespace Avaliacao.Application.Veiculo.Commands.AlugarVeiculo
{
    public class AlugarVeiculoCommand : Command
    {
        public int VeiculoId { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public decimal Valor { get; set; }

        public StatusAluguel Status { get; set; }

        public override bool IsValid()
        {
            AdicionarErros(new AlugarVeiculoValidator().Validate(this));

            return ValidationResult.IsValid;
        }
    }
}