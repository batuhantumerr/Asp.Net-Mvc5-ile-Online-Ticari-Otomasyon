using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c=new Context();
        public ActionResult Index()
        {
            var kategoriler = c.Kategoris.ToList();
            return View(kategoriler);
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            c.Kategoris.Add(kategori);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg=c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGuncelle(int id)
        {
            var ktg= c.Kategoris.Find(id);
            return View(ktg);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori) 
        {
            var ktg=c.Kategoris.Find(kategori.KategoriId);
            ktg.KategoriAd=kategori.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}