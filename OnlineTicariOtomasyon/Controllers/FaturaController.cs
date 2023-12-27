using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;
namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Bills.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Bill bill)
        {
            c.Bills.Add(bill);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}