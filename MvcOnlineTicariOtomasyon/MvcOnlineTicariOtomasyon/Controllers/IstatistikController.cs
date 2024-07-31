using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c= new Context();
        public ActionResult Index()
        {
            var toplamCari=c.Caris.Count().ToString();
            ViewBag.ToplamCari = toplamCari;

            var urunSayisi=c.Uruns.Count().ToString();
            ViewBag.UrunSayisi=urunSayisi;

            var personelSayisi=c.Personels.Count().ToString();
            ViewBag.PersonelSayisi=personelSayisi;

            var kategoriSayisi=c.Kategoris.Count().ToString();
            ViewBag.KategoriSayisi=kategoriSayisi;

            var toplamStok=c.Uruns.Sum(x=>x.Stok).ToString();
            ViewBag.ToplamStok = toplamStok;

            var markaSayisi=(from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.MarkaSayisi = markaSayisi;

            var kritikSeviye=c.Uruns.Count(x=>x.Stok<=20).ToString();
            ViewBag.KritikSeviye = kritikSeviye;

            var maxFiyatliUrun = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.MaxFiyatliUrun = maxFiyatliUrun;

            var minFiyatliUrun= (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.MinFiyatliUrun = minFiyatliUrun;

            var maxMarka=c.Uruns.GroupBy(x=>x.Marka).OrderByDescending(y=>y.Count()).Select(z=>z.Key).FirstOrDefault();
            ViewBag.MaxMarka = maxMarka;

            var buzdolabiSayisi=c.Uruns.Count(x=>x.UrunAd=="Buzdolabı").ToString();
            ViewBag.BuzdolabiSayisi = buzdolabiSayisi;

            var laptopSayisi = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.LaptopSayisi = laptopSayisi;

            var enCokSatan = c.Uruns.Where(u => u.UrunId == (c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.EnCokSatan = enCokSatan;

            var kasadakiTutar=c.SatisHarekets.Sum(x=>x.ToplamTutar).ToString();
            ViewBag.KasadakiTutar = kasadakiTutar;

            var bugunkuSatislar=c.SatisHarekets.Where(x=>x.Tarih==DateTime.Today).Count();
            ViewBag.BugunkuSatislar = bugunkuSatislar;

            var bugunkuKasa = c.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.BugunkuKasa = bugunkuKasa;

            return View();
        }

        public ActionResult BasitTablolar()
        {
            var sorgu = from x in c.Caris
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu3 = c.Caris.Where(x=>x.Durum==true).ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial3()
        {
            var sorgu4 = c.Uruns.Where(x=>x.Durum==true).ToList();
            return PartialView(sorgu4);
        }

        public PartialViewResult Partial4()
        {
            var sorgu5 = from x in c.Uruns
                        group x by x.Marka into g
                        select new SinifGrup3
                        {
                            Marka  = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu5.ToList());
   
        }

    }
}