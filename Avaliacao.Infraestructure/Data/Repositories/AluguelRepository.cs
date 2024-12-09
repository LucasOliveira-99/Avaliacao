using Avaliacao.Infraestructure.Data.Repositories.Common;
using Avaliacao.Microservice.Domain.Contexts.Alugueis;
using Avaliacao.Microservice.Domain.Contexts.Alugueis.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avaliacao.Infraestructure.Data.Repositories
{
    public class AluguelRepository : BaseRepository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Aluguel> ObterAluguel(int aluguelID)
        {
            return await _context.Alugueis.FirstOrDefaultAsync(x => x.Id == aluguelID);
        }
    }
}