using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var yapilacaklar=c.Yapilacaks.ToList();
            var cariSayisi = c.Caris.Count().ToString();
            ViewBag.CariSayisi=cariSayisi;
            var sehirSayisi = (from x in c.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.SehirSayisi=sehirSayisi;
            var urunSayisi=c.Uruns.Count().ToString();
            ViewBag.UrunSayisi=urunSayisi;
            var kategoriSayisi=c.Kategoris.Count().ToString();
            ViewBag.KategoriSayisi=kategoriSayisi;
           
            return View(yapilacaklar);
        }
    }
}