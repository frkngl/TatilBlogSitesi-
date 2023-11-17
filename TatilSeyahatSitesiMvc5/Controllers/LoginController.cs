using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class LoginController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN ad)
        {
            var varmi = db.TBLADMIN.Where(x => x.KullanıcıAdı == ad.KullanıcıAdı & x.Sifre == ad.Sifre).FirstOrDefault();

            if (varmi != null)     //kayıt buldunsa
            {
                FormsAuthentication.SetAuthCookie(varmi.KullanıcıAdı, false);
                Session["username"] = varmi.KullanıcıAdı;
                Session["adsoyad"] = varmi.KullanıcıAdı;
                return RedirectToAction("Index", "AdminAnasayfa");
            }
            else
            {
                TempData["hata"] = 1;
                return View();
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Anasayfa");
        }
        public ActionResult LogOutt()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}