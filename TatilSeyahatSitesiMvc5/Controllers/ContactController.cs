using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class ContactController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: Contact
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            var degerler=db.TBLADRES.ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(iletisim model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad & Soyad: " + model.AdiSoyadi);
                body.AppendLine("E-Mail Adresi: " + model.Email);
                body.AppendLine("Konu: " + model.Subject);
                body.AppendLine("Mesaj: " + model.Message);
                MailClasım.MailSender(body.ToString());
                ViewBag.Success = true;
            }
            return View();
        }
        public PartialViewResult Partial()
        {
            var degerler = db.TBLADRES.ToList();
            return PartialView(degerler);
        }
    }
}