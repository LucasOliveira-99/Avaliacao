namespace Avaliacao.Microservice.WebAPI.DTOs.FinalizarAluguel
{
    public class FinalizarAluguelRequest
    {
        public int AluguelId { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
