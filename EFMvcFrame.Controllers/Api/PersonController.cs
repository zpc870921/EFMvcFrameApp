using EFMvcFrame.Controllers.WebReq;
using EFMvcFrame.Interface;
using EFMvcFrame.Model.Entites;
using EFMvcFrame.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EFMvcFrame.Controllers.Api
{
    public class PersonController:ApiController
    {
        public IPerson personSvc;

        public PersonController()
        { }

        public PersonController(IPerson personService)
        {
            this.personSvc = personService;
        }

        [AcceptVerbs("GET","POST")]
        public IHttpActionResult GetPersons()
        {
            return Ok(new string[] { "cc", "dd" });
        }

        public int AddPerson(Person model)
        {
            return this.personSvc.AddPerson(model);
        }

        [AcceptVerbs("post","get")]
        public IHttpActionResult GetAll()
        {
            return Ok(this.personSvc.GetPersons());
        }

        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetPager()
        {
            var data = this.personSvc.GetPersonPager(new Pagination { PageIndex = 1 }, "", 0);
            return Ok(data);
        }

        [AcceptVerbs("get")]
        public Person GetById(int id)
        {


            RequestHelper.WebApiTest();
            RequestHelper.WebRequestTest();
            RequestHelper.wcftest();

            return this.personSvc.GetById(id);
        }
    }
}
