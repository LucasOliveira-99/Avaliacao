using Avaliacao.Infraestructure.Data.Repositories.Common;
using Avaliacao.Microservice.Domain.Contexts.Veiculo;
using Avaliacao.Microservice.Domain.Contexts.Veiculo.Interfaces;

namespace Avaliacao.Infraestructure.Data.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
