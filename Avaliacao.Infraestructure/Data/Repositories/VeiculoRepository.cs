using Avaliacao.Infraestructure.Data.Repositories.Common;
using Avaliacao.Microservice.Domain.Contexts.Veiculo;
using Avaliacao.Microservice.Domain.Contexts.Veiculo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avaliacao.Infraestructure.Data.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<Veiculo> ObterVeiculo(int veiculoID)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == veiculoID);
        }

    }
}
