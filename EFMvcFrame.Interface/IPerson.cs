using EFMvcFrame.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Interface
{
    public interface IPerson
    {
        int AddPerson(Person model);
        IEnumerable<Person> GetPersons();

        Person GetById(int id);

        IList<Person> GetPersonPager(Pagination pageInfo, string name, int age);
    }
}
