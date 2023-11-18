using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class BlogController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: Blog
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            // var degerler = db.TBLBLOG.ToList();
            by.bloglar = db.TBLBLOG.OrderByDescending(x=>x.ID).ToList();
            by.bloglar2=db.TBLBLOG.OrderByDescending(x=>x.ID).Take(5).ToList();
            by.yorumlar2 = db.TBLYORUMLAR.Where(x=>x.DURUM==true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
        public ActionResult BlogDetayy(int id)
        {
            //var degerler=db.TBLBLOG.Where(x=>x.ID==id).ToList();
            by.bloglar = db.TBLBLOG.Where(x => x.ID == id).ToList();
            by.yorumlar = db.TBLYORUMLAR.Where(x => x.BLOGID == id && x.DURUM == true).ToList();
            by.bloglar2 = db.TBLBLOG.OrderByDescending(x => x.ID).Take(5).ToList();
            by.yorumlar2 = db.TBLYORUMLAR.Where(x => x.DURUM == true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
       
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(TBLYORUMLAR y)
        {
            TBLYORUMLAR yeni = new TBLYORUMLAR();
            yeni.KullaniciAdi = y.KullaniciAdi;
            yeni.Yorum = y.Yorum;
            yeni.Mail = y.Mail;
            yeni.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            yeni.BLOGID = y.BLOGID;
            yeni.DURUM = false;
            db.TBLYORUMLAR.Add(yeni);
            db.SaveChanges();
            Response.Redirect("/Blog/BlogDetayy/" + y.BLOGID);
            return PartialView();
        }
        
    }
}