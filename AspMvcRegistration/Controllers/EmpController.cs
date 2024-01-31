using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspMvcRegistration.DAL;
using AspMvcRegistration.Models;

namespace AspMvcRegistration.Controllers
{
    public class EmpController : Controller
    {
        DAL.Emp dalobj = new DAL.Emp();
        Models.Emp modelobj = new Models.Emp();
        // GET: Emp
        
        public ActionResult Index()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Select Dept", Value = "0" });
            foreach(var item in modelobj.Depts.ToList())
            {
                list.Add(new SelectListItem() { Text = item });

            }
            TempData["iedept"] = list;
            TempData.Keep();
            TempData["lihb"] = modelobj.Hobbies;
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection f1,string gender,Models.Emp modelobj)
        {
            modelobj.Dept=f1["dept"];
            modelobj.Gender = gender;
            string val = "";
            foreach(var item in modelobj.Hobbies)
            {
                if (f1[item].ToString().Contains("true"))
                    {
                    val = val + "," + item;
                }

            }
            modelobj.Hobby = val;
            dalobj.AddEmp(modelobj);
            return View();
        }

    }
}