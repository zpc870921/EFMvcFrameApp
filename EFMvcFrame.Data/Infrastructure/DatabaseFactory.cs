using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Data.Infrastructure
{
   public class DatabaseFactory : Disposable, IDatabaseFactory
    {
       private PersonDbContext dbContext;

       public PersonDbContext Get()
        {
            return dbContext ?? (dbContext = new PersonDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext = null;
            }
            //base.DisposeCore();
        }
    }
}
