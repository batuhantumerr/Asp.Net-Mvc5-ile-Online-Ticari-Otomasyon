using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }

        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D","E","F","G","H"};
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1= rnd.Next(100,1000);
            s2= rnd.Next(10,99);
            s3= rnd.Next(10,99);
            string takipKodu = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            ViewBag.TakipKodu=takipKodu;
            return View();
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay kargo)
        {
            c.KargoDetays.Add(kargo);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var hareketler=c.KargoTakips.Where(x=>x.TakipKodu==id).ToList();
            return View(hareketler);
        }
    }
}