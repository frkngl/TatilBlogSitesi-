using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;
using System.Web.UI;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class AnasayfaController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: Anasayfa
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.bloglar=db.TBLBLOG.ToList();
            by.muzeler=db.TBLMUZELER.ToList();
            by.muzeler2 = db.TBLMUZELER.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
        public PartialViewResult Partial1()
        {
            by.aciklama=db.TBLACIKLAMA.ToList();
            return PartialView(by);
        }
        public PartialViewResult Partial2()
        {
            var degerler = db.TBLBLOG.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial4()
        {
            var degerler = db.TBLRESTAURANT.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial5()
        {
            var degerler = db.TBLOTELLER.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }
    }
}