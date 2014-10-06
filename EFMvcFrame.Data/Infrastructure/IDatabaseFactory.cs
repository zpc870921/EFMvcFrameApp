using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        PersonDbContext Get();
    }
}
