using System.Runtime.Serialization;
using Avaliacao.Infraestructure.CrossCutting.Common.Enums;
using Avaliacao.Infraestructure.CrossCutting.Common.Views;

namespace Avaliacao.Application.Veiculo.Commands.ObterVeiculo.Views
{
    public class ObterVeiculoView : View
    {
        public ObterVeiculoView(Microservice.Domain.Contexts.Veiculos.Veiculo response)
        {
            Marca = response.Marca;
            Placa = response.Placa;
            Modelo = response.Modelo;
            Cor = response.Cor;
            FlagStatusVeiculo = response.FlagStatusVeiculo;
        }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Placa { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public string Cor { get; set; }

        [DataMember]
        public StatusVeiculo FlagStatusVeiculo { get; private set; }
    }
}