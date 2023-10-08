using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Employees.ToList();
            return View(degerler);
        }
    }
}