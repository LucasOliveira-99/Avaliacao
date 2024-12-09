using System.Runtime.Serialization;
using Avaliacao.Infraestructure.CrossCutting.Common.Views;

namespace Avaliacao.Application.Veiculo.Commands.AlugarVeiculo.Views
{
    public class AlugarVeiculoView : View
    {
        public AlugarVeiculoView(Microservice.Domain.Contexts.Alugueis.Aluguel response)
        {
            VeiculoId = response.VeiculoId;
            DataInicio = response.DataInicio;
            DataFim = response.DataFim;
            Valor = response.Valor;
        }

        [DataMember]
        public int VeiculoId { get; set; }

        [DataMember]
        public DateTime DataInicio { get; set; }

        [DataMember]
        public DateTime DataFim { get; set; }

        [DataMember]
        public decimal Valor { get; set; }
    }
}