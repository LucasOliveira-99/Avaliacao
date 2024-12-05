namespace Avaliacao.Infraestructure.CrossCutting.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}