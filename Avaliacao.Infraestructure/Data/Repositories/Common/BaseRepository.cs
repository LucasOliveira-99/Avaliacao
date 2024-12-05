using Avaliacao.Infraestructure.CrossCutting.Common.Entities;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;

namespace Avaliacao.Infraestructure.Data.Repositories.Common
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void CreateAsync(T aggregate)
        {
            _context.Add(aggregate);
        }

        public void RemoveAsync(T aggregate)
        {
            _context.Remove(aggregate);
        }

        public void UpdateAsync(T aggregate)
        {
            _context.Update(aggregate);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}