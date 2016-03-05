using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.RecipeMaster.Data
{
    public class UnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        private bool _disposed = false;
        private DbContext _dbContext = new TContext();
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> Repository<T>() where T : EntityBase
        {
            Type t = typeof(T);

            if (!_repositories.ContainsKey(t))
            {
                _repositories.Add(t, new Repository<T>(_dbContext));

            }

            return _repositories[t] as IRepository<T>;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
