using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c= new Context();
        public ActionResult Index()
        {
            var faturalar=c.Faturas.ToList();
            return View(faturalar);
        }
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            c.Faturas.Add(fatura);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGuncelle(int id)
        {
            var fatura=c.Faturas.Find(id);
            return View(fatura);
        }

        [HttpPost]
        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var f = c.Faturas.Find(fatura.FaturaId);
            f.FaturaSeriNo = fatura.FaturaSeriNo;
            f.FaturaSiraNo = fatura.FaturaSiraNo;
            f.VergiDairesi= fatura.VergiDairesi;
            f.Tarih= fatura.Tarih;
            f.Saat= fatura.Saat;
            f.TeslimEden= fatura.TeslimEden;
            f.TeslimAlan= fatura.TeslimAlan;
            f.Toplam= fatura.Toplam;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var faturaKalemler=c.FaturaKalems.Where(x=>x.FaturaId==id).ToList();
            ViewBag.FaturaId = id;
            return View(faturaKalemler);
        }

        public ActionResult FaturaKalemEkle(int id)
        {
            ViewBag.FaturaId = id;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem faturaKalem)
        {
            c.FaturaKalems.Add(faturaKalem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}