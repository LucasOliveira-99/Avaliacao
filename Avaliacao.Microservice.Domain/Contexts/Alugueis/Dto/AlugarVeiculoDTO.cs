namespace Avaliacao.Microservice.Domain.Contexts.Alugueis.Dto
{
    public class AlugarVeiculoDTO
    {
        public int VeiculoId { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
    }
}