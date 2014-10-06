using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        void Commit(params object[] obj);
        void Refresh(object obj);

        DbContextTransaction BeginTransaction();
    }
}
