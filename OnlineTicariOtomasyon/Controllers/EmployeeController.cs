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
            var degerler = c.Employees.Where(x => x.Status == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Employee p)
        {
            c.Employees.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Employees.Find(id);
            return View("PersonelGetir",prs);
        }
        public ActionResult PersonelGuncelle(Employee p)
        {
            var per = c.Employees.Find(p.EmployeeID);
            per.EmployeeName = p.EmployeeName;
            per.EmployeeSurname = p.EmployeeSurname;
            per.EmployeeImage = p.EmployeeImage;
            per.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var deger = c.Employees.Find(id);
            deger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}