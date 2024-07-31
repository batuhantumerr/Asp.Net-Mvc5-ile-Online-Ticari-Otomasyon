using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c=new Context();
        public ActionResult Index()
        {
            var cariler=c.Caris.Where(x=>x.Durum==true).ToList();
            return View(cariler);
        }

        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            if (ModelState.IsValid)
            {
            c.Caris.Add(cari);
            cari.Durum = true;
            c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("CariEkle");
            }
            
        }

        public ActionResult CariSil(int id)
        {
            var cari=c.Caris.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGuncelle(int id)
        {
            var cari = c.Caris.Find(id);
            return View(cari);
        }
        [HttpPost]
        public ActionResult CariGuncelle(Cari cari)
        {
            var gncCari = c.Caris.Find(cari.CariId);
            gncCari.CariAd = cari.CariAd;
            gncCari.CariSoyad = cari.CariSoyad;
            gncCari.CariSehir = cari.CariSehir;
            gncCari.CariMail = cari.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatisGecmis(int id)
        {
            var satislar=c.SatisHarekets.Where(x=>x.CariId==id).ToList();
            var cariAd = c.Caris.Where(x=>x.CariId==id).Select(y=>y.CariAd+" "+y.CariSoyad).FirstOrDefault();
            ViewBag.CariAd = cariAd;
            return View(satislar);

        }
    }
}