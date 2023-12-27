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
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Bills.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Bill f)
        {
            var fatura = c.Bills.Find(f.BillID);
            fatura.BillSerialNo = f.BillSerialNo;
            fatura.BillSequenceNo = f.BillSequenceNo;
            fatura.TaxAdministration = f.TaxAdministration;
            fatura.Clock = f.Clock;
            fatura.Date = f.Date;
            fatura.Deliverer = f.Deliverer;
            fatura.DeliveryArea   = f.DeliveryArea;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Billid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}