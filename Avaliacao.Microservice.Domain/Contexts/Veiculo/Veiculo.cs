using Avaliacao.Infraestructure.CrossCutting.Common.Entities;
using Avaliacao.Infraestructure.CrossCutting.Common.Enums;
using Avaliacao.Microservice.Domain.Contexts.Alugueis;
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
            FlagStatusVeiculo = StatusVeiculo.DISPONIVEL;
        }

        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public string Cor { get; private set; }
        public StatusVeiculo FlagStatusVeiculo { get; private set; }
        public List<Aluguel> Alugueis { get; private set; }

        public bool EstaDisponivel()
        {
            return FlagStatusVeiculo == StatusVeiculo.DISPONIVEL;
        }

        public void MarcarComoIndisponivel()
        {
            FlagStatusVeiculo = StatusVeiculo.INDISPONIVEL;
        }

        public void MarcarComoDisponivel()
        {
            FlagStatusVeiculo = StatusVeiculo.INDISPONIVEL;
        }
    }
}