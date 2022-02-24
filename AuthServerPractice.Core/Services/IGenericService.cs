using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Core.Services
{
    public interface IGenericService<TEntity,TDto> where TEntity: class where TDto : class
    {
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<TDto>> GetByIdAsyns(int id);
        Task<Response<TEntity>> AddAsync(TEntity entity);
        Task<Response<NoDataDto>> Remove(TEntity entity);
        Task<Response<NoDataDto>> Update(TEntity entity);
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predi);
    }
}
