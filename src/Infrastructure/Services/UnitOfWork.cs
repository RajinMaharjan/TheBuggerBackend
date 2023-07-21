using Excallibur.Application.Common.Interfaces;
using Excallibur.Infrastructure.Common;
using Excallibur.Infrastructure.Persistence;
using Infrastructure.Common;

namespace Excallibur.Infrastructure.Services
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly QaLintDbContext _context;

        QaLintDbContext IUnitOfWork.DbContext => _context;

        private Dictionary<Type, object> repositories;

        public UnitOfWork(QaLintDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            repositories ??= new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context);
            }
            return (IRepository<TEntity>)repositories[type];
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public override void Dispose(bool disposing)
        {
            _context.Dispose();

        }


    }
}
