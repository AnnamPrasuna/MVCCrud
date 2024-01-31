using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCrudUsingStoredProcedures.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary {get; set; }
    }
}