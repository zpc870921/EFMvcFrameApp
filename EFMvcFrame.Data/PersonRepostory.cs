using EFMvcFrame.Data.Infrastructure;
using EFMvcFrame.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Data
{
    public partial class PersonRepostory : RepositoryBase<Person>, IPersonRepostory
    {
        public PersonRepostory(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
    }
    public partial interface IPersonRepostory : IRepository<Person> { }
}
