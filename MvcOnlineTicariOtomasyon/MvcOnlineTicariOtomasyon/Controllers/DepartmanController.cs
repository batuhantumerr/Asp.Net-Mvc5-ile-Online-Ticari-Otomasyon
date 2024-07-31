using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles ="A")]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c=new Context();
        public ActionResult Index()
        {
            var departmanlar=c.Departmans.Where(d=>d.Durum==true).ToList();
            return View(departmanlar);
        }

        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            c.Departmans.Add(departman);
            departman.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dpt = c.Departmans.Find(id);
            dpt.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGuncelle(int id) 
        {
            var dpt=c.Departmans.Find(id);
            return View(dpt);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman departman) 
        {
            var dpt=c.Departmans.Find(departman.DepartmanId);
            dpt.DepartmanAd=departman.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var personeller=c.Personels.Where(p=>p.DepartmanId==id).ToList();
            var departmanAd=c.Departmans.Where(x=>x.DepartmanId==id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.DepartmanAd = departmanAd;
            return View(personeller);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var satislar=c.SatisHarekets.Where(x=>x.PersonelId==id).ToList();
            var PersonelAd=c.Personels.Where(x=>x.PersonelId==id).Select(y=>y.PersonelAd+" "+y.PersonelSoyad).FirstOrDefault();
            ViewBag.PersonelAd = PersonelAd;
            return View(satislar);
        }

    }
}