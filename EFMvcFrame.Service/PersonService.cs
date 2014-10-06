using EFMvcFrame.Data;
using EFMvcFrame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFMvcFrame.Model.Entites;
using EFMvcFrame.Data.Infrastructure;
using EFMvcFrame.FrameWork.Caching;
using System.Linq.Expressions;
using EFMvcFrame.FrameWork;


namespace EFMvcFrame.Service
{
    public class PersonService:IPerson
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IPersonRepostory personRepostory;
        protected readonly ICacheProvider cacheProvider; 

        #region 缓存键
        protected static readonly string Person_Key = "BC95C8D0-42C5-27A3-4C61-E2CD2759D6F6_";
        #endregion

        public PersonService(IPersonRepostory personRespostory,IUnitOfWork unitOfWork,ICacheProvider cacheProvider)
        {
            this.personRepostory = personRespostory;
            this.unitOfWork = unitOfWork;
            this.cacheProvider = cacheProvider;
        }

        public int AddPerson(Person model)
        {
            this.personRepostory.Add(model);
            this.unitOfWork.Commit();
            return model.Id;
        }

        public IEnumerable<Person> GetPersons()
        {
            return this.personRepostory.GetAll();
        }

        public Person GetById(int id)
        {
            return this.cacheProvider.Get(String.Concat(Person_Key, id), () => this.personRepostory.GetById(id));
        }

        public IList<Person> GetPersonPager(Pagination pageInfo,string name,int age)
        {
            Expression<Func<Person,bool>> cond = t => true;
            if (!string.IsNullOrEmpty(name))
            {
                cond = cond.And(t=>t.Name.Contains(name));
            }
            if (age > 0)
            {
                cond = cond.And(t=>t.Age.Equals(age));
            }
            return this.personRepostory.GetPage(pageInfo, cond, p => p.Id);
        }

    }
}
