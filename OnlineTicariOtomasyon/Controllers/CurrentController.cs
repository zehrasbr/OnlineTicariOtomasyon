﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Class;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Currents.Where(x=>x.Status==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Current p)
        {
            //eklerken ilk olarak durumunu true olarak ekler
            p.Status = true;
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Currents.Find(id);
            cr.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Currents.Find(id);
            return View("CariGetir",cari);
        }
        public ActionResult CariGuncelle(Current p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Currents.Find(p.CurrentID);
            cari.CurrentName = p.CurrentName;
            cari.CurrentSurname = p.CurrentSurname;
            cari.CurrentCity = p.CurrentCity;
            cari.CurrentMail = p.CurrentMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SalesStatuses.Where(x=>x.Currentid == id).ToList();
            var cr = c.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}