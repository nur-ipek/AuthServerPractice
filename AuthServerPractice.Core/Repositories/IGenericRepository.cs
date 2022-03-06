using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsyns(int id);
        Task<TEntity> AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predi);

    }
}
