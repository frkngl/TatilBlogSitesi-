using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLACIKLAMA.ToList();
            return View(degerler);
        }
    }
}