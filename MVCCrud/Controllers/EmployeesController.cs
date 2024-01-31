using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.DAL;
namespace MVCCrud.Controllers
{
    public class EmployeesController : Controller
    {
        DAL.Employees objdal = new DAL.Employees();
        // GET: Employees
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.Employees employee,string b1)
        {
            if (b1 == "Save")
            {
                int i1 = objdal.AddEmployee(employee);
                if (i1 == 1)
                {
                    ViewBag.Message = "employee is added";

                }
                else
                {
                    ViewBag.Message = "Failed to add";
                }
            }
            else if(b1=="Delete")
            {
                int i2=objdal.DeleteEmployee(employee);
                if(i2==1)
                {
                    ViewBag.Message = "employee is deleted";
                }
                else
                {
                    ViewBag.Message = "Failed to delete";
                }
            }
            else if (b1 == "Update")
            {
                int i3 = objdal.UpdateEmployee(employee);
                if (i3 == 1)
                {
                    ViewBag.Message = "employee is updated";
                }
                else
                {
                    ViewBag.Message = "Failed to update";
                }
            }
            return View();
        }

    }
}