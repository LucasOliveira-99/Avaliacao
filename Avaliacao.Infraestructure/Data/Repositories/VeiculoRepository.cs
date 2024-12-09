using Avaliacao.Infraestructure.Data.Repositories.Common;
using Avaliacao.Microservice.Domain.Contexts.Veiculos;
using Avaliacao.Microservice.Domain.Contexts.Veiculos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avaliacao.Infraestructure.Data.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Veiculo> ObterVeiculoPorId(int veiculoID)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == veiculoID);
        }

        public async Task<List<Veiculo>> ObterVeiculos(int? veiculoId = null)
        {
            if (veiculoId.HasValue && veiculoId.Value > 0)
            {
                var veiculo = await _context.Veiculos
                    .Where(x => x.Id == veiculoId.Value)
                    .ToListAsync();

                return veiculo;
            }

            return await _context.Veiculos.ToListAsync();
        }
    }
}

