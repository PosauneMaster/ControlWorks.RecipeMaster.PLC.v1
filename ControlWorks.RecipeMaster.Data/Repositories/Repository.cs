using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.RecipeMaster.Data
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _dbContext;

        public DbContext DbContext { get; protected set; }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T FindById(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            DbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public virtual IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).ToList();
        }
    }
}
