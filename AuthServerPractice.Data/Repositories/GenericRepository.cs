using AuthServerPractice.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        //EF tarafında tablolara karşılık gelecek -> DbSet
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
           //Burada SaveChange veya Commit metodunu çağırmıyorum. Onu yapacağımız yer Service Katmanı.
           //Bu işlemle memory'ye bir veri ekledim fakat db'ye yansımadı.
           //Burada yapacağım her işlem memory'de hazır olarak bekleyecek, ne zamanki Service katmanında bu repo DI olarak geçtikten sonra unitOfWork ile Commit metodunu çağırdımızda bd'ye kayıt edilecek.
        }

        //Burada IEnumerable dönmemizin sebebi bu sonuç döndükten sonra herhangi bir sorgulama işlemi yapmayacağız.
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsyns(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if(entity != null)
            {
                //Takip edilmesin.
                _dbContext.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
            //Bu satır EntityState'ini Deleted olarak işaretliyor.
            // _dbSet.Remove ==  _dbContext.Entry(entity).State = EntityState.Detached;

            //Memory'den sildi.
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            //Bu satır entity'miz üzerinde bir alan değişikliği ytapmış olsak dahi tüm satırlar update olacak şekilde çalışır.
            //Performans dezavantajı
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predi)
        {
            return _dbSet.Where(predi);
        }
    }
}
