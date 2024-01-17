using OnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var degerler = c.Currents.FirstOrDefault(x=>x.CurrentMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentID).FirstOrDefault();
            var degerler = c.SalesStatuses.Where(x => x.Currentid == id).ToList();
            return View(degerler);
        }
    }
}