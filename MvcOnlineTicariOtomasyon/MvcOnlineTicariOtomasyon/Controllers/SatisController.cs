using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c=new Context();
        public ActionResult Index()
        {
            var satislar=c.SatisHarekets.ToList();
            return View(satislar);
        }

        public ActionResult SatisEkle()
        {
            List<SelectListItem> urunler = (from x in c.Uruns.ToList() select new SelectListItem { Text = x.UrunAd, Value = x.UrunId.ToString() }).ToList();
            ViewBag.Urunler=urunler;

             List<SelectListItem> cariler = (from x in c.Caris.ToList() select new SelectListItem { Text = x.CariAd+" "+x.CariSoyad, Value = x.CariId.ToString() }).ToList();
            ViewBag.Cariler=cariler;

             List<SelectListItem> personeller = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd+" "+x.PersonelSoyad, Value = x.PersonelId.ToString() }).ToList();
            ViewBag.Personeller=personeller;

            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(SatisHareket s)
        {
            s.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGuncelle(int id)
        {   
            var satis = c.SatisHarekets.Find(id);

            List<SelectListItem> urunler = (from x in c.Uruns.ToList() select new SelectListItem { Text = x.UrunAd, Value = x.UrunId.ToString() }).ToList();
            ViewBag.Urunler = urunler;

            List<SelectListItem> cariler = (from x in c.Caris.ToList() select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.CariId.ToString() }).ToList();
            ViewBag.Cariler = cariler;

            List<SelectListItem> personeller = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.PersonelId.ToString() }).ToList();
            ViewBag.Personeller = personeller;


            return View(satis);
        }
        [HttpPost]
        public ActionResult SatisGuncelle(SatisHareket satis) 
        { 
            var s=c.SatisHarekets.Find(satis.SatisId);
            s.UrunId=satis.UrunId;
            s.CariId=satis.CariId;
            s.PersonelId=satis.PersonelId;
            s.Adet=satis.Adet;
            s.Fiyat=satis.Fiyat;
            s.ToplamTutar=satis.ToplamTutar;
            s.Tarih=satis.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}