using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrudAdoScaffolding.DAL;

namespace MVCCrudAdoScaffolding.Controllers
{
    public class EmployeesController : Controller
    {
        DAL.Employees dalobj = new DAL.Employees();
        // GET: Employees
        public ActionResult Index()
        {
            List<Models.Employees> ie= new List<Models.Employees>();
            return View(ie);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Employees e1)
        {
          int i1= dalobj.AddEmployee(e1);
             if(i1==1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}