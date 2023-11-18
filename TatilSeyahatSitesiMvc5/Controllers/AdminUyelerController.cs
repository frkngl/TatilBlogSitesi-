using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class AdminUyelerController : Controller
    {
        // GET: AdminUyeler
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBLADMIN ekleme)
        {
            var degerler = db.TBLADMIN.Where(x => x.KullanıcıAdı == ekleme.KullanıcıAdı && x.Sifre == ekleme.Sifre).FirstOrDefault();
            if (degerler==null) 
            { 
             TBLADMIN blog = new TBLADMIN();
             blog.KullanıcıAdı = ekleme.KullanıcıAdı;
             blog.Sifre = ekleme.Sifre;
             db.TBLADMIN.Add(blog);
             db.SaveChanges();
             return RedirectToAction("Index");
            }
            else
            {
                ViewBag.uyarı = "Bu kullanıcı zaten var";
            }
            return View();
        }



        public ActionResult Uyeler()
        {
            var degerler = db.TBLADMIN.ToList();
            return View(degerler);
        }
        public ActionResult GosterGizle(int id)
        {
            var yorum = db.TBLADMIN.Find(id);
            if (yorum.Yetki != null)
            {
                yorum.Yetki = null;
            }
            else
            {
                yorum.Yetki = true;
            }
            db.SaveChanges();
            return RedirectToAction("Uyeler");
        }

        public ActionResult Sil(int id)
        {
            var silinecekyorum = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(silinecekyorum);
            db.SaveChanges();
            TempData["sil"] = "asdf";
            return RedirectToAction("Uyeler");
        }
    }
}