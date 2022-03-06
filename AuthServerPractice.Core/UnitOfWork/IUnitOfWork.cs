using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerPractice.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        //Task Asenkron'da void'e karşılık gelir.
        Task CommitAsync();
        void Commit();
    }
}
