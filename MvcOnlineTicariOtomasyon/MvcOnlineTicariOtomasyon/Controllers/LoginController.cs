using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c=new Context();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult KayitOl()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult KayitOl(Cari cari)
        {
            c.Caris.Add(cari);
            c.SaveChanges();
            return PartialView();
        }

        public ActionResult CariGiris() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult CariGiris(Cari cari) 
        { 
            var cariBilgileri=c.Caris.FirstOrDefault(x=>x.CariMail==cari.CariMail && x.CariSifre==cari.CariSifre);
            if (cariBilgileri != null)
            {
                FormsAuthentication.SetAuthCookie(cariBilgileri.CariMail, false);
                Session["CariMail"]=cariBilgileri.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            return View();
        }

        public ActionResult AdminGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGiris(Admin admin)
        {
            var objAdmin = c.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (objAdmin != null)
            {
                FormsAuthentication.SetAuthCookie(objAdmin.KullaniciAd, false);
                Session["KullaniciAd"]=objAdmin.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

    }
}