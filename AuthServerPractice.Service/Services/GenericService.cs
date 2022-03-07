using AuthServerPractice.Core.Repositories;
using AuthServerPractice.Core.Services;
using AuthServerPractice.Core.UnitOfWork;
using AuthServerPractice.Data.Repositories;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Service.Services
{  
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        //API'nin startup class'ında DI nesnesi olarak ekleyeceğizz ???
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;
    
        public GenericService(IGenericRepository<TEntity> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            //BU METODUN ADIMLARI
            //1.ObjectMApper static bir metot olduğundan dolayı instance almıyoruz.
            //2.Elimizdeki entity'yi Generic Repository'ye göndermeden önce mapliyoruz.
            //3.Çünkü API'den Dto aldık, ekleme silme güncelleme işlemleri yapan Data katmanında bulunan Repository'ye Entity tipinde gönderiyoruz.

            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

            await _genericRepository.AddAsync(newEntity);

            //Bu aralıkta fazlaca ekleme işleme yapabiliriz.
            //Farklı Business kurallarımız olabilir.

            await _unitOfWork.CommitAsync();

            //Map<TDto>.(newEntity) --> dönüşecek nesne newEntity, dönüştürülecek tip TDto

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

            return Response<TDto>.Success(newDto, 200);

        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var listEntity = await _genericRepository.GetAllAsync();

            var listDto = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(listEntity);

            return Response<IEnumerable<TDto>>.Success(listDto, 200);
        }

        public async Task<Response<TDto>> GetByIdAsyns(int id)
        {
            var entity = await _genericRepository.GetByIdAsyns(id);

            var dto = ObjectMapper.Mapper.Map<TDto>(entity);

            return Response<TDto>.Success(dto, 200);
        }

        public async Task<Response<NoDataDto>> Remove(TDto entity)
        {
            var deleteEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

             _genericRepository.Remove(deleteEntity);

            return Response<NoDataDto>.Success(200);
        }

        public Task<Response<NoDataDto>> Update(TDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predi)
        {
            throw new NotImplementedException();
        }
    }
}
