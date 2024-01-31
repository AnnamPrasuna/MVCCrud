using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrudUsingStoredProcedures.DAL;
using MvcCrudUsingStoredProcedures.Models;

namespace MvcCrudUsingStoredProcedures.Controllers
{

    public class EmployeesController : Controller
    {
        DAL.Employees DalObj = new DAL.Employees();
        // GET: Employees
        [HttpGet]
        public ActionResult Index()
        {
            TempData["ie"] = DalObj.GetEmployee();
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.Employees emp,string b1)
        {
            if (b1 == "Save")
            {
                int i1 = DalObj.AddEmployee(emp);
                if (i1 == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            else if(b1=="Update")
            {
                int i1 = DalObj.UpdateEmployee(emp);
                if (i1 == 1)
                {
                    return RedirectToAction("Index");
                }                                                                                                                                                                   
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Models.Employees emp = new Models.Employees();
            emp.Id = Id;
            int i1 = DalObj.DeleteEmployee(emp);
            if (i1 == 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            TempData.Keep();
            Models.Employees emp = new Models.Employees();
            emp.Id = Id;
            emp = DalObj.SearchEmployees(emp);
            return View("Index", emp);
            
        }

    }
}