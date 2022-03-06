using AuthServerPractice.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        //SaveChange çağırabilmem için DbCpontext'e ihyicımız var.
        //temel context
        private readonly DbContext _dbContext;

        //Burada AppDbCopntext'i DI nesnesi olarak geçiyoruz.
        public UnitOfWork(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
