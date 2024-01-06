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
            var deger6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Products.Count(x=>x.ProductStock <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Products.Count(x=> x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Products.Count(x=>x.ProductName == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Products.GroupBy(x=>x.ProductBrand).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.Products.Where(u=>u.ProductID == (c.SalesStatuses.GroupBy(x=>x.Productid).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SalesStatuses.Sum(x=>x.TotalPrice).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SalesStatuses.Count(x=>x.Date == bugun).ToString();
            ViewBag.d15 = deger15;
            //var deger16 = c.SalesStatuses.Where(x=>x.Date==bugun).Sum(y=>y.TotalPrice).ToString(); 
            //ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Currents
                        group x by x.CurrentCity into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
    }
}