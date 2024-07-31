using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var urunler = c.Uruns.ToList();
            urunler.ForEach(x => xvalue.Add(x.UrunAd));
            urunler.ForEach(y => yvalue.Add(y.Stok));

            var grafik = new Chart(width: 500, height: 500)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);

            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<GrafikUrun> UrunListesi()
        {
            List<GrafikUrun> urunler = new List<GrafikUrun>();
            using (var context = new Context())
            {
                urunler = context.Uruns.Select(x => new GrafikUrun
                {
                    UrunAdi = x.UrunAd,
                    UrunStok = x.Stok
                }).ToList();
            }
            return urunler;
        }
        public ActionResult PieChart()
        {
            return View();
        }

         public ActionResult LineChart()
        {
            return View();
        }

         public ActionResult ColumnChart()
        {
            return View();
        }

    }
}