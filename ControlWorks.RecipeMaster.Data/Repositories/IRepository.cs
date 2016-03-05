using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorks.RecipeMaster.Data
{
    public interface IRepository<T> where T : EntityBase
    {
        T FindById(int id);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);

    }

    public abstract class EntityBase
    {
        public int Id { get;  protected set;}
    }
}
