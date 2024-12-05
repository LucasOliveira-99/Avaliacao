using System.Runtime.Serialization;
using Avaliacao.Infraestructure.CrossCutting.Common.Views;

namespace Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Views
{
    public class CadastrarVeiculoView : View
    {
        public CadastrarVeiculoView(Microservice.Domain.Contexts.Veiculo.Veiculo response)
        {
            Marca = response.Marca;
            Placa = response.Placa;
            Modelo = response.Modelo;
            Cor = response.Cor;
        }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Placa { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public string Cor { get; set; }
    }
}