using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMvcRegistration.Models
{
    public class Emp
    {
        public int Eno { get; set; }
        public string Ename { get; set; }
        public List<string> Hobbies
        {
            get
            {
                List<string> hobby = new List<string>();
                hobby.Add("Cricket");
                hobby.Add("Shuttle");
                hobby.Add("Football");
                hobby.Add("Hockey");
                return hobby;
            }
        }
        public List<string> Depts {
            get
            {
                List<string> Dnames = new List<string>();
                Dnames.Add("Admin");
                Dnames.Add("Accounts");
                Dnames.Add("Quality");
                return Dnames;
            }
        }
        public string Gender{ get; set; }
        public double Salary { get; set; }
        public string Dept { get; set; }
        public string Hobby { get; set; }

    }
}