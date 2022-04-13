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
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> Update(TDto entity,int id);
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predi);
    }
}
