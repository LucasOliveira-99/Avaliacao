using Avaliacao.Infraestructure.CrossCutting.Common.CQS;

namespace Avaliacao.Application.Veiculo.Commands.FinalizarAluguel
{
    public class FinalizarAluguelCommand : Command
    {
        public int AluguelId { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}