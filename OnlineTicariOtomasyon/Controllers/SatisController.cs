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
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SalesStatus s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesStatuses.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SalesStatuses.Find(id);
            return View("SatisGetir", deger);
        }
    }
}