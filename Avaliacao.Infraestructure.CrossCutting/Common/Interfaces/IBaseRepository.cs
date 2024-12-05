using Avaliacao.Infraestructure.CrossCutting.Common.Entities;

namespace Avaliacao.Infraestructure.CrossCutting.Common.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void CreateAsync(T aggregate);

        void UpdateAsync(T aggregate);

        void RemoveAsync(T aggregate);
    }
}