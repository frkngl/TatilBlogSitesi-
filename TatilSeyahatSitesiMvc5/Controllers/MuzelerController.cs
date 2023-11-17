using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class MuzelerController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: Muzeler
        BlogYorum by=new BlogYorum();
        public ActionResult Index()
        {
            by.muzeler = db.TBLMUZELER.ToList();
            by.muzeler2 = db.TBLMUZELER.OrderByDescending(x=>x.ID).Take(5).ToList();
            by.muzeyorum = db.TBLMUZEYORUM.Where(x=>x.DURUM==true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
        public ActionResult MuzelerDetay(int id)
        {
            by.muzeler = db.TBLMUZELER.Where(x => x.ID == id).ToList();
            by.muzeyorum=db.TBLMUZEYORUM.Where(x=>x.MuzeID==id && x.DURUM==true).ToList();
            by.muzeler2 = db.TBLMUZELER.OrderByDescending(x => x.ID).Take(5).ToList();
            by.muzeyorum2 = db.TBLMUZEYORUM.Where(x => x.DURUM == true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
        
        public PartialViewResult MuzeYorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult MuzeYorumYap(TBLMUZEYORUM y)
        {
            TBLMUZEYORUM yeni = new TBLMUZEYORUM();
            yeni.KullaniciAdi = y.KullaniciAdi;
            yeni.Yorum = y.Yorum;
            yeni.Mail = y.Mail;
            yeni.MuzeID = y.MuzeID;
            yeni.DURUM = false;
            yeni.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.TBLMUZEYORUM.Add(yeni);
            db.SaveChanges();
            Response.Redirect("/Muzeler/MuzelerDetay/" + y.MuzeID);
            return PartialView();
        }
    }
}