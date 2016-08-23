using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    }

    public class CompanyRep
    {
        public static List<Company> list = null;
        static CompanyRep()
        {
            list = new List<Company>();
            list.Add(new Company { Id = 1, location = "kolkata", name = "TCS" });
            list.Add(new Company { Id = 2, location = "Delhi", name = "Wipro" });
            list.Add(new Company { Id = 3, location = "Bangalore", name = "IBM" });
        }
    } 
}