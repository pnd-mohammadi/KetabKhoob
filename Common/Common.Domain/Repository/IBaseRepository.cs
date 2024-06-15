using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
       public Task<T?> GetAsync(long id);

       public Task<T?> GetTracking(long id);

        public Task AddAsync(T entity);
        public void Add(T entity);

        public Task AddRange(ICollection<T> entities);

        public void Update(T entity);

        public Task<int> Save();

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        public bool Exists(Expression<Func<T, bool>> expression);

        public T? Get(long id);
    }
}
