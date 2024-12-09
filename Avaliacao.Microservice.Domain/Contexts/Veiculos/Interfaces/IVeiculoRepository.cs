using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;

namespace Avaliacao.Microservice.Domain.Contexts.Veiculos.Interfaces
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Task<Veiculo> ObterVeiculoPorId(int veiculoID);

        Task<List<Veiculo>> ObterVeiculos(int? veiculoId = null);
    }
}