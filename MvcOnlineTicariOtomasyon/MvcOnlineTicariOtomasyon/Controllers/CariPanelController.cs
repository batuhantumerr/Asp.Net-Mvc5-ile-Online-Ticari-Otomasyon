using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var sessionCari=c.Caris.Where(x=>x.CariMail == mail).ToList();
            ViewBag.Mail = mail;
            return View(sessionCari);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var cariId=c.Caris.Where(x=>x.CariMail==mail.ToString()).Select(y=>y.CariId).FirstOrDefault();
            var siparisler=c.SatisHarekets.Where(x=>x.CariId==cariId).ToList();
            return View(siparisler);
        }

        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
                k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        }

        public ActionResult KargoDetaylar(string id)
        {
            var hareketler=c.KargoTakips.Where(x=>x.TakipKodu==id).ToList();
            return View(hareketler);
        }
        public ActionResult GelenMesajlar()
        {
            var kullaniciMail = (string)Session["CariMail"];
            var mesajlar=c.Mesajs.Where(x=>x.Alici== kullaniciMail).OrderByDescending(x => x.MesajId).ToList();

            var gelenMesajSayisi=c.Mesajs.Where(y=>y.Alici== kullaniciMail).Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;

            var gonderilenMesajSayisi = c.Mesajs.Where(x => x.Gonderici == kullaniciMail).Count();
            ViewBag.GonderilenMesajSayisi = gonderilenMesajSayisi;
        
            return View(mesajlar);
        }

        public ActionResult GonderilenMesajlar()
        {
            var kullaniciMail= (string)Session["CariMail"];
            var mesajlar=c.Mesajs.Where(x=>x.Gonderici== kullaniciMail).OrderByDescending(x=>x.MesajId).ToList();

            var gelenMesajSayisi = c.Mesajs.Where(y => y.Alici == kullaniciMail).Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;

            var gonderilenMesajSayisi = c.Mesajs.Where(x => x.Gonderici == kullaniciMail).Count();
            ViewBag.GonderilenMesajSayisi= gonderilenMesajSayisi;

            return View(mesajlar);
        }


        public ActionResult MesajDetay(int id)
        {
            var mesaj=c.Mesajs.Where(x=>x.MesajId==id).ToList();
            var kullaniciMail = (string)Session["CariMail"];

            var gelenMesajSayisi = c.Mesajs.Where(y => y.Alici == kullaniciMail).Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;

            var gonderilenMesajSayisi = c.Mesajs.Where(x => x.Gonderici == kullaniciMail).Count();
            ViewBag.GonderilenMesajSayisi = gonderilenMesajSayisi;
            return View(mesaj);
        }

        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj mesaj)
        {

            var kullaniciMail = (string)Session["CariMail"];

            mesaj.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderici = kullaniciMail;
            c.Mesajs.Add(mesaj);
            c.SaveChanges();

            var gelenMesajSayisi = c.Mesajs.Where(y => y.Alici == kullaniciMail).Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;

            var gonderilenMesajSayisi = c.Mesajs.Where(x => x.Gonderici == kullaniciMail).Count();
            ViewBag.GonderilenMesajSayisi = gonderilenMesajSayisi;

            return RedirectToAction("GonderilenMesajlar");
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login"); 
        }

    }
}