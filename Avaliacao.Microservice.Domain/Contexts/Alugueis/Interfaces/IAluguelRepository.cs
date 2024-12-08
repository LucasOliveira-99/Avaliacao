using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;

namespace Avaliacao.Microservice.Domain.Contexts.Alugueis.Interfaces
{
    public interface IAluguelRepository : IBaseRepository<Aluguel>
    {
        Task<Aluguel> ObterAluguel(int aluguelID);
    }
}