using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c=new Context();
        public ActionResult Index()
        {
            var personeller=c.Personels.ToList();
            return View(personeller);
        }

        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanlar=(from x in c.Departmans.ToList() select new SelectListItem { Text=x.DepartmanAd,Value=x.DepartmanId.ToString()}).ToList();
            ViewBag.Departmanlar=departmanlar;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel) 
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi=Path.GetFileName(Request.Files[0].FileName);
                string dosyaUzanti=Path.GetExtension(Request.Files[0].FileName);
                string dosyaYolu = "~/Images/" + dosyaAdi + dosyaUzanti;
                Request.Files[0].SaveAs(Server.MapPath(dosyaYolu));
                personel.PersonelGorsel = "/Images/" + dosyaAdi + dosyaUzanti;
            }
            c.Personels.Add(personel);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGuncelle(int id)
        {
            var personel = c.Personels.Find(id);
            List<SelectListItem> departmanlar = (from x in c.Departmans.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanId.ToString() }).ToList();
            ViewBag.Departmanlar = departmanlar;
            return View(personel);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string dosyaUzanti = Path.GetExtension(Request.Files[0].FileName);
                string dosyaYolu = "~/Images/" + dosyaAdi + dosyaUzanti;
                Request.Files[0].SaveAs(Server.MapPath(dosyaYolu));
                personel.PersonelGorsel = "/Images/" + dosyaAdi + dosyaUzanti;
            }
            var p=c.Personels.Find(personel.PersonelId);
            p.PersonelAd=personel.PersonelAd;
            p.PersonelSoyad=personel.PersonelSoyad;
            p.PersonelGorsel=personel.PersonelGorsel;
            p.DepartmanId=personel.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var personeller=c.Personels.ToList();
            return View(personeller);
        }
    }
}