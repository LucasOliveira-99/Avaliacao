using Avaliacao.Infraestructure.CrossCutting.Common.Enums;

namespace Avaliacao.Microservice.WebAPI.DTOs.AlugarVeiculo
{
    public class AlugarVeiculoRequest
    {
        public int VeiculoId { get; set; }
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public decimal Valor { get; set; }

        public StatusAluguel Status { get; set; }
    }
}