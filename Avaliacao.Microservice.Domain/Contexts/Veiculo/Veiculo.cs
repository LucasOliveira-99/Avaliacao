using Avaliacao.Infraestructure.CrossCutting.Common.Entities;
using Avaliacao.Microservice.Domain.Contexts.Veiculo.Dto;

namespace Avaliacao.Microservice.Domain.Contexts.Veiculo
{
    public class Veiculo : AggregateRoot
    {
        protected Veiculo()
        { }

        public Veiculo(VeiculoDTO veiculoDTO)
        {
            Modelo = veiculoDTO.Modelo;
            Marca = veiculoDTO.Marca;
            Cor = veiculoDTO.Cor;
            Placa = veiculoDTO.Placa;
        }

        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public string Cor { get; private set; }
    }
}