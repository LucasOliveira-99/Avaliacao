using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;

namespace Avaliacao.Microservice.Domain.Contexts.Veiculo.Interfaces
{
    public interface  IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task<Veiculo> ObterVeiculo(int veiculoID);
    }
}
