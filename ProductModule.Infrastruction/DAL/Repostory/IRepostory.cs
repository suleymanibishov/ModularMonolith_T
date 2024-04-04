using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductModule.Infrastruction.DAL.Repostory
{
    public interface IRepostory<T> where T : class
    {
        Task AddAsync(T entity);
        IQueryable<T> GetAsync(Expression<Func<T, bool>> exception = null);
        Task<T> EditAsync(T entity);
        Task<int> SaveAsync();
        void Remove(T entity);
    }
}
