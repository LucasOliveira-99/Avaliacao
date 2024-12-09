using System.Runtime.Serialization;
using Avaliacao.Infraestructure.CrossCutting.Common.Views;

namespace Avaliacao.Application.Veiculo.Commands.FinalizarAluguel.Views
{
    public class FinalizarAluguelView : View
    {
        public FinalizarAluguelView(int id, DateTime dataEntrega)
        {
            VeiculoId = id;
            DataEntrega = dataEntrega;
        }

        [DataMember]
        public int VeiculoId { get; set; }

        [DataMember]
        public DateTime DataEntrega { get; set; }
    }
}