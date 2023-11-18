using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    [Authorize]
    public class AdminYorumlarController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: AdminYorumlar
        BlogYorum by = new BlogYorum();
       
        public ActionResult Index()
        {
            var degerler = db.TBLYORUMLAR.OrderByDescending(x => x.ID).ToList();
            return View(degerler);
        }

        public ActionResult GosterGizle(int id)
        {
            var yorum = db. TBLYORUMLAR.Find(id);
            if (yorum.DURUM == false)
            {
                yorum.DURUM = true;
            }
            else
            {
                yorum.DURUM = false;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var silinecekyorum = db.TBLYORUMLAR.Find(id);

            db.TBLYORUMLAR.Remove(silinecekyorum);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("Index");
        }
        public ActionResult YorumGuncelle(TBLYORUMLAR y)
        {
            var bul = db.TBLYORUMLAR.Find(y.ID);
            bul.KullaniciAdi = y.KullaniciAdi;
            bul.Yorum = y.Yorum;
            bul.Mail = y.Mail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumDetay(int id)
        {
            var bul = db.TBLYORUMLAR.Find(id);
            return View("YorumDetay", bul);
        }





        //------------------------------------------------------------------------//
        public ActionResult OtelYorum()
        {
            var degerler = db.TBLOTELYORUM.OrderByDescending(x => x.ID).ToList();
            return View(degerler);
        }

        public ActionResult GosterGizleOtel(int id)
        {
            var yorum = db.TBLOTELYORUM.Find(id);
            if (yorum.DURUM == false)
            {
                yorum.DURUM = true;
            }
            else
            {
                yorum.DURUM = false;
            }
            db.SaveChanges();
            return RedirectToAction("OtelYorum");
        }

        public ActionResult SilOtel(int id)
        {
            var silinecekyorum = db.TBLOTELYORUM.Find(id);

            db.TBLOTELYORUM.Remove(silinecekyorum);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("OtelYorum");
        }
        public ActionResult YorumGuncelleOtel(TBLOTELYORUM y)
        {
            var bul = db.TBLOTELYORUM.Find(y.ID);
            bul.KullaniciAdi = y.KullaniciAdi;
            bul.Yorum = y.Yorum;
            bul.Mail = y.Mail;
            db.SaveChanges();
            return RedirectToAction("OtelYorum");
        }
        public ActionResult YorumDetayOtel(int id)
        {
            var bul = db.TBLOTELYORUM.Find(id);
            return View("YorumDetayOtel", bul);
        }







        //-----------------------------------------------------------------------------------//
        public ActionResult RestaurantYorum()
        {
            var degerler = db.TBLRESTAURANTYORUM.OrderByDescending(x => x.ID).ToList();
            return View(degerler);
        }

        public ActionResult GosterGizleRestaurant(int id)
        {
            var yorum = db.TBLRESTAURANTYORUM.Find(id);
            if (yorum.DURUM == false)
            {
                yorum.DURUM = true;
            }
            else
            {
                yorum.DURUM = false;
            }
            db.SaveChanges();
            return RedirectToAction("RestaurantYorum");
        }

        public ActionResult SilRestaurant(int id)
        {
            var silinecekyorum = db.TBLRESTAURANTYORUM.Find(id);

            db.TBLRESTAURANTYORUM.Remove(silinecekyorum);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("RestaurantYorum");
        }
        public ActionResult YorumGuncelleRestaurant(TBLRESTAURANTYORUM y)
        {
            var bul = db.TBLRESTAURANTYORUM.Find(y.ID);
            bul.KullaniciAdi = y.KullaniciAdi;
            bul.Yorum = y.Yorum;
            bul.Mail = y.Mail;
            db.SaveChanges();
            return RedirectToAction("OtelYorum");
        }
        public ActionResult YorumDetayRestaurant(int id)
        {
            var bul = db.TBLRESTAURANTYORUM.Find(id);
            return View("YorumDetayRestaurant", bul);
        }








        //-----------------------------------------------------------------------------------
        public ActionResult MuzelerYorum()
        {
            var degerler = db.TBLMUZEYORUM.OrderByDescending(x => x.ID).ToList();
            return View(degerler);
        }

        public ActionResult GosterGizleMuzeler(int id)
        {
            var yorum = db.TBLMUZEYORUM.Find(id);
            if (yorum.DURUM == false)
            {
                yorum.DURUM = true;
            }
            else
            {
                yorum.DURUM = false;
            }
            db.SaveChanges();
            return RedirectToAction("MuzelerYorum");
        }

        public ActionResult SilMuzeler(int id)
        {
            var silinecekyorum = db.TBLMUZEYORUM.Find(id);

            db.TBLMUZEYORUM.Remove(silinecekyorum);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("MuzelerYorum");
        }
        public ActionResult YorumGuncelleMuzeler(TBLMUZEYORUM y)
        {
            var bul = db.TBLMUZEYORUM.Find(y.ID);
            bul.KullaniciAdi = y.KullaniciAdi;
            bul.Yorum = y.Yorum;
            bul.Mail = y.Mail;
            db.SaveChanges();
            return RedirectToAction("MuzelerYorum");
        }
        public ActionResult YorumDetayMuzeler(int id)
        {
            var bul = db.TBLMUZEYORUM.Find(id);
            return View("YorumDetayMuzeler", bul);
        }
    }
}