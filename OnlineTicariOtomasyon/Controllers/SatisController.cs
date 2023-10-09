using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SalesStatuses.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SalesStatus s)
        {
            c.SalesStatuses.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}