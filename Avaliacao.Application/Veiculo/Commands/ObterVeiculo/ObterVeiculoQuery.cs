using Avaliacao.Infraestructure.CrossCutting.Common.CQS;

namespace Avaliacao.Application.Veiculo.Commands.ObterVeiculo
{
    public class ObterVeiculoQuery : Query
    {
        public int VeiculoId { get; set; }
    }
}