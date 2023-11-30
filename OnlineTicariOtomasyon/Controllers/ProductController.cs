using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Products.Where(x=>x.Status==true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList() select new SelectListItem
            {
                Text = x.CategoryName,
                Value=x.CategoryID.ToString()
            }).ToList();
             ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Products.Find(id);
            deger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Products.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Product p)
        {
            var urun = c.Products.Find(p.ProductID);
            urun.Status = p.Status;
            urun.ProductName = p.ProductName;
            urun.PurchasePrice = p.PurchasePrice;
            urun.ProductBrand = p.ProductBrand;
            urun.ProductStock = p.ProductStock;
            urun.ProductImage = p.ProductImage;
            urun.SalePrice = p.SalePrice;
            urun.Kategoriid = p.Kategoriid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunLisetsi()
        {
            var degerler = c.Products.ToList();
            return View(degerler);
        }
    }
}