using EFMvcFrame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EFMvcFrame.Controllers.MVC
{
    public class PersonController:Controller
    {

        IPerson personSvc;
        public PersonController(IPerson personsvc)
        {
            this.personSvc = personsvc;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestPerson(int id)
        {

           // return Content("2333");
            ViewBag.test = "Mvc Controller Test";

            return View();
        }

        public JsonResult Getall()
        {
            var persons = this.personSvc.GetPersons();
            return Json(persons,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            return Json(this.personSvc.GetById(id),JsonRequestBehavior.AllowGet);
        }
    }
}
