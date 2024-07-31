using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c=new Context();
        public ActionResult Index()
        {
            var urunler=c.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunler);
        }
        
        public ActionResult UrunEkle()
        {
            List<SelectListItem> KategoriList = (from x in c.Kategoris.ToList() select new SelectListItem { Text=x.KategoriAd, Value=x.KategoriId.ToString() }).ToList(); 
            ViewBag.KategoriList=KategoriList;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            c.Uruns.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun=c.Uruns.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> KategoriList = (from x in c.Kategoris.ToList() select new SelectListItem { Text = x.KategoriAd, Value = x.KategoriId.ToString() }).ToList();
            ViewBag.KategoriList = KategoriList;
            var urun = c.Uruns.Find(id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun u)
        {
            var urun = c.Uruns.Find(u.UrunId);
            urun.UrunAd = u.UrunAd;
            urun.Marka = u.Marka;
            urun.Stok = u.Stok;
            urun.AlisFiyat = u.AlisFiyat;
            urun.SatisFiyat= u.SatisFiyat;
            urun.KategoriId = u.KategoriId;
            urun.UrunGorsel=u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var urunler=c.Uruns.ToList();
            return View(urunler);
        }

        public ActionResult SatisYap(int id)
        {
            ViewBag.UrunId = id;

            List<SelectListItem> personeller = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.PersonelId.ToString() }).ToList();
            ViewBag.Personeller = personeller;

            var urunFiyat = c.Uruns.Where(x => x.UrunId == id).FirstOrDefault().SatisFiyat;
            ViewBag.UrunFiyat=urunFiyat;
            
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket satis)
        {
            satis.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}