using Excallibur.Application.Common.Interfaces;
using Excallibur.Infrastructure.Persistence;

namespace Infrastructure.Common
{
    public interface IUnitOfWork : IDisposable
    {
        QaLintDbContext DbContext { get; }

        Task<int> SaveChangesAsync();
        int SaveChanges();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }


}
