using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;
namespace OnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Currents.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Employees.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Products.Sum(x=>x.ProductStock).ToString();
            ViewBag.d5 = deger5;
            var deger6 = c.Currents.Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Currents.Count().ToString();
            ViewBag.d7 = deger7;
            var deger8 = c.Currents.Count().ToString();
            ViewBag.d8 = deger8;
            var deger9 = c.Currents.Count().ToString();
            ViewBag.d9 = deger9;
            var deger10 = c.Currents.Count().ToString();
            ViewBag.d10 = deger10;
            return View();
        }
    }
}