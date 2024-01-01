using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;
namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Products.Where(x=>x.ProductID == 1).ToList();
            return View(degerler);
        }
    }
}