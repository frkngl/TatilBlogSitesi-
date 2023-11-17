using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class OtellerController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: Oteller
        BlogYorum by=new BlogYorum();
        public ActionResult Index() {
            by.oteller = db.TBLOTELLER.ToList();
            by.oteller2 = db.TBLOTELLER.OrderByDescending(x => x.ID).Take(5).ToList();
            by.otelyorumlar = db.TBLOTELYORUM.Where(x=>x.DURUM==true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
        public ActionResult OtelDetay(int id)
        {
            by.oteller = db.TBLOTELLER.Where(x => x.ID == id).ToList();
            by.otelyorumlar = db.TBLOTELYORUM.Where(x => x.OTELID == id && x.DURUM==true).ToList();
            by.oteller2 = db.TBLOTELLER.OrderByDescending(x => x.ID).Take(5).ToList();
            by.otelyorumlar2 = db.TBLOTELYORUM.Where(x=>x.DURUM==true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }


        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(TBLOTELYORUM y)
        {
            TBLOTELYORUM yeni = new TBLOTELYORUM();
            yeni.KullaniciAdi = y.KullaniciAdi;
            yeni.Yorum = y.Yorum;
            yeni.Mail = y.Mail;
            yeni.OTELID = y.OTELID;
            yeni.DURUM = false;
            yeni.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.TBLOTELYORUM.Add(yeni);
            db.SaveChanges();
            Response.Redirect("/Oteller/OtelDetay/" + y.OTELID);
            return PartialView();
        }
    }
}