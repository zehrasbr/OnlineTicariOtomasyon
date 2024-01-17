using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;
using PagedList;
using PagedList.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Categories.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ctg = c.Categories.Find(id);
            c.Categories.Remove(ctg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ctg = c.Categories.Find(id);
            return View("KategoriGetir", ctg);
        }
        public ActionResult KategoriGuncelle(Category category)
        {
            var ctg = c.Categories.Find(category.CategoryID);
            ctg.CategoryName = category.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}