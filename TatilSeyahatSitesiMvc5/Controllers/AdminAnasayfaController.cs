using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    [Authorize]
    public class AdminAnasayfaController : Controller
    {
        Mvc5TatilSeyehatEntities db = new Mvc5TatilSeyehatEntities();
        // GET: AdminAnasayfa
        public ActionResult Index()
        {
            return View();
        }






        //-------------------------------BLOGLAR KISMI---------------------------------------------------------------------------------------------------------//
        public ActionResult Bloglar(string p)
        {
            //var degerler = db.TBLBLOG.OrderByDescending(x => x.ID).ToList();
            //return View(degerler);
            var degerler =from d in db.TBLBLOG select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Baslik.Contains(p));
            }
            return View(degerler.ToList());

        }
        //--------------------------------BLOG EKLEME YERİ---------------------------------------------//
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//SummerNote için
        public ActionResult YeniBlog(TBLBLOG ekleme, HttpPostedFileBase BlogImage)
        {
            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);

                    TBLBLOG blog = new TBLBLOG();
                    blog.Baslik = ekleme.Baslik;
                    blog.Aciklama = ekleme.Aciklama;
                    blog.BlogImage = fileName;
                    blog.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.TBLBLOG.Add(blog);
                    db.SaveChanges();
                    TempData["ekle"] = "başarılı";
                    return RedirectToAction("Bloglar");
                }
                else
                {
                    TempData["hata"] = "a";
                    return View();
                }
            }

            return View();
        }
        //-----------------------------------BLOG GÜNCELLEME YERİ----------------------------------------//
        public ActionResult BlogGuncelle(int id)
        {
            var bul = db.TBLBLOG.Find(id);
            return View("BlogGuncelle", bul);
        }
        [HttpPost]
        [ValidateInput(false)]  //summernote için
        public ActionResult Kaydet(TBLBLOG b, HttpPostedFileBase BlogImage)
        {
            var guncellenecekkayit = db.TBLBLOG.Find(b.ID);

            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var yol = Request.MapPath("~/IMG/" + guncellenecekkayit.BlogImage);
                    if (System.IO.File.Exists(yol))
                    {
                        System.IO.File.Delete(yol);
                    }


                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);
                    guncellenecekkayit.BlogImage = fileName;
                }
                else
                {
                    TempData["hata"] = "Lütfem resim formatında bir dosya seçiniz!!!";
                    return View();
                }
            }
            guncellenecekkayit.Baslik = b.Baslik;
            guncellenecekkayit.Aciklama = b.Aciklama;
            db.SaveChanges();
            TempData["guncelle"] = "başarılı";
            return RedirectToAction("Bloglar");
        }
        //--------------------------BLOG SİLME YERİ-----------------------------------------------------------//
        public ActionResult Sil(int id)
        {
            var silinecekblog = db.TBLBLOG.Find(id);
            var yol = Request.MapPath("~/IMG/" + silinecekblog.BlogImage);
            if (System.IO.File.Exists(yol))
            {
                System.IO.File.Delete(yol);
            }
            db.TBLBLOG.Remove(silinecekblog);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("Bloglar");
        }
        //--------------------------BLOG DETAY YERİ--------------------------------------------------------//
        public ActionResult BlogDetay(int id)
        {
            var bul = db.TBLBLOG.Find(id);
            return View("BlogDetay", bul);
        }
        //----------------------------BLOG KISIM END-----------------------------------------------------------------------------------------------------//









        //----------------------------OTELLER KISIM----------------------------------------------------------------------------------------------------------//
        public ActionResult Oteller(string p)
        {
            //var degerler = db.TBLOTELLER.OrderByDescending(x => x.ID).ToList();
            //return View(degerler);
            var degerler = from d in db.TBLOTELLER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Baslik.Contains(p));
            }
            return View(degerler.ToList());
        }
        //--------------------------------OTEL EKLEME YERİ---------------------------------------------//
        [HttpGet]
        public ActionResult YeniOtel()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//SummerNote için
        public ActionResult YeniOtel(TBLOTELLER ekleme, HttpPostedFileBase BlogImage)
        {
            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);

                    TBLOTELLER blog = new TBLOTELLER();
                    blog.Baslik = ekleme.Baslik;
                    blog.Aciklama = ekleme.Aciklama;
                    blog.OtellerImage = fileName;
                    blog.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.TBLOTELLER.Add(blog);
                    db.SaveChanges();
                    TempData["ekle"] = "başarılı";
                    return RedirectToAction("Oteller");
                }
                else
                {
                    TempData["hata"] = "a";
                    return View();
                }
            }

            return View();
        }
        //-----------------------------------OTEL GÜNCELLEME YERİ----------------------------------------//
        public ActionResult OtelGuncelleme(int id)
        {
            var bul = db.TBLOTELLER.Find(id);
            return View("OtelGuncelleme", bul);
        }
        [HttpPost]
        [ValidateInput(false)]  //summernote için
        public ActionResult OtelKaydet(TBLOTELLER b, HttpPostedFileBase BlogImage)
        {
            var guncellenecekkayit = db.TBLOTELLER.Find(b.ID);

            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var yol = Request.MapPath("~/IMG/" + guncellenecekkayit.OtellerImage);
                    if (System.IO.File.Exists(yol))
                    {
                        System.IO.File.Delete(yol);
                    }


                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);
                    guncellenecekkayit.OtellerImage = fileName;
                }
                else
                {
                    TempData["hata"] = "Lütfem resim formatında bir dosya seçiniz!!!";
                    return View();
                }
            }
            guncellenecekkayit.Baslik = b.Baslik;
            guncellenecekkayit.Aciklama = b.Aciklama;
            db.SaveChanges();
            TempData["guncelle"] = "başarılı";
            return RedirectToAction("Oteller");
        }
        //--------------------------OTEL SİLME YERİ-----------------------------------------------------------//
        public ActionResult SilOtel(int id)
        {
            var silinecekblog = db.TBLOTELLER.Find(id);
            var yol = Request.MapPath("~/IMG/" + silinecekblog.OtellerImage);
            if (System.IO.File.Exists(yol))
            {
                System.IO.File.Delete(yol);
            }
            db.TBLOTELLER.Remove(silinecekblog);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("Oteller");
        }
        //--------------------------OTEL DETAY YERİ--------------------------------------------------------//
        public ActionResult OtelDetay(int id)
        {
            var bul = db.TBLOTELLER.Find(id);
            return View("OtelDetay", bul);
        }
        //----------------------------OTEL KISIM END-----------------------------------------------------------------------------------------------------//











        //----------------------------RESTAURANT KISIM----------------------------------------------------------------------------------------------------------//
        public ActionResult Restaurantlar(string p)
        {
            //var degerler = db.TBLRESTAURANT.OrderByDescending(x => x.ID).ToList();
            //return View(degerler);
            var degerler = from d in db.TBLRESTAURANT select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Baslik.Contains(p));
            }
            return View(degerler.ToList());
        }
        //--------------------------------RESTAURANT EKLEME YERİ---------------------------------------------//
        [HttpGet]
        public ActionResult YeniRestaurant()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//SummerNote için
        public ActionResult YeniRestaurant(TBLRESTAURANT ekleme, HttpPostedFileBase BlogImage)
        {
            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);

                    TBLRESTAURANT blog = new TBLRESTAURANT();
                    blog.Baslik = ekleme.Baslik;
                    blog.Aciklama = ekleme.Aciklama;
                    blog.RestaurantImage = fileName;
                    blog.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.TBLRESTAURANT.Add(blog);
                    db.SaveChanges();
                    TempData["ekle"] = "başarılı";
                    return RedirectToAction("Restaurantlar");
                }
                else
                {
                    TempData["hata"] = "a";
                    return View();
                }
            }

            return View();
        }
        //-----------------------------------RESTAURANT GÜNCELLEME YERİ----------------------------------------//
        public ActionResult RestaurantGuncelleme(int id)
        {
            var bul = db.TBLRESTAURANT.Find(id);
            return View("RestaurantGuncelleme", bul);
        }
        [HttpPost]
        [ValidateInput(false)]  //summernote için
        public ActionResult RestaurantKaydet(TBLRESTAURANT b, HttpPostedFileBase BlogImage)
        {
            var guncellenecekkayit = db.TBLRESTAURANT.Find(b.ID);

            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var yol = Request.MapPath("~/IMG/" + guncellenecekkayit.RestaurantImage);
                    if (System.IO.File.Exists(yol))
                    {
                        System.IO.File.Delete(yol);
                    }


                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);
                    guncellenecekkayit.RestaurantImage = fileName;
                }
                else
                {
                    TempData["hata"] = "Lütfem resim formatında bir dosya seçiniz!!!";
                    return View();
                }
            }
            guncellenecekkayit.Baslik = b.Baslik;
            guncellenecekkayit.Aciklama = b.Aciklama;
            db.SaveChanges();
            TempData["guncelle"] = "başarılı";
            return RedirectToAction("Restaurantlar");
        }
        //--------------------------RESTAURANT SİLME YERİ-----------------------------------------------------------//
        public ActionResult SilRestaurant(int id)
        {
            var silinecekblog = db.TBLRESTAURANT.Find(id);
            var yol = Request.MapPath("~/IMG/" + silinecekblog.RestaurantImage);
            if (System.IO.File.Exists(yol))
            {
                System.IO.File.Delete(yol);
            }
            db.TBLRESTAURANT.Remove(silinecekblog);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("Restaurantlar");
        }
        //--------------------------RESTAURANT DETAY YERİ--------------------------------------------------------//
        public ActionResult RestaurantDetay(int id)
        {
            var bul = db.TBLRESTAURANT.Find(id);
            return View("RestaurantDetay", bul);
        }
        //----------------------------RESTAURANT KISIM END-----------------------------------------------------------------------------------------------------//















        //----------------------------GEZİ KISIM----------------------------------------------------------------------------------------------------------//
        public ActionResult Geziler(string p)
        {
            //var degerler = db.TBLMUZELER.OrderByDescending(x => x.ID).ToList();
            //return View(degerler);
            var degerler = from d in db.TBLMUZELER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Baslik.Contains(p));
            }
            return View(degerler.ToList());
        }
        //--------------------------------GEZİ EKLEME YERİ---------------------------------------------//
        [HttpGet]
        public ActionResult YeniGeziler()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]//SummerNote için
        public ActionResult YeniGeziler(TBLMUZELER ekleme, HttpPostedFileBase BlogImage)
        {
            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);

                    TBLMUZELER blog = new TBLMUZELER();
                    blog.Baslik = ekleme.Baslik;
                    blog.Aciklama = ekleme.Aciklama;
                    blog.MuzelerImage = fileName;
                    blog.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.TBLMUZELER.Add(blog);
                    db.SaveChanges();
                    TempData["ekle"] = "başarılı";
                    return RedirectToAction("Geziler");
                }
                else
                {
                    TempData["hata"] = "a";
                    return View();
                }
            }

            return View();
        }
        //-----------------------------------GEZİ GÜNCELLEME YERİ----------------------------------------//
        public ActionResult GezilerGuncelleme(int id)
        {
            var bul = db.TBLMUZELER.Find(id);
            return View("GezilerGuncelleme", bul);
        }
        [HttpPost]
        [ValidateInput(false)]  //summernote için
        public ActionResult GezilerKaydet(TBLMUZELER b, HttpPostedFileBase BlogImage)
        {
            var guncellenecekkayit = db.TBLMUZELER.Find(b.ID);

            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentType == "image/jpeg" || BlogImage.ContentType == "image/png" || BlogImage.ContentType == "image/jpg" || BlogImage.ContentType == "image/jfif")
                {
                    var yol = Request.MapPath("~/IMG/" + guncellenecekkayit.MuzelerImage);
                    if (System.IO.File.Exists(yol))
                    {
                        System.IO.File.Delete(yol);
                    }


                    var fi = new FileInfo(BlogImage.FileName);
                    var fileName = Path.GetFileName(BlogImage.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);


                    WebImage rr = new WebImage(BlogImage.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);
                    rr.Save(path);
                    guncellenecekkayit.MuzelerImage = fileName;
                }
                else
                {
                    TempData["hata"] = "Lütfem resim formatında bir dosya seçiniz!!!";
                    return View();
                }
            }
            guncellenecekkayit.Baslik = b.Baslik;
            guncellenecekkayit.Aciklama = b.Aciklama;
            db.SaveChanges();
            TempData["guncelle"] = "başarılı";
            return RedirectToAction("Geziler");
        }
        //--------------------------GEZİ SİLME YERİ-----------------------------------------------------------//
        public ActionResult SilGeziler(int id)
        {
            var silinecekblog = db.TBLMUZELER.Find(id);
            var yol = Request.MapPath("~/IMG/" + silinecekblog.MuzelerImage);
            if (System.IO.File.Exists(yol))
            {
                System.IO.File.Delete(yol);
            }
            db.TBLMUZELER.Remove(silinecekblog);
            db.SaveChanges();
            TempData["sil"] = "asdf";

            return RedirectToAction("Geziler");
        }
        //--------------------------GEZİ DETAY YERİ--------------------------------------------------------//
        public ActionResult GezilerDetay(int id)
        {
            var bul = db.TBLMUZELER.Find(id);
            return View("GezilerDetay", bul);
        }
        //----------------------------GEZİ KISIM END-----------------------------------------------------------------------------------------------------//










        //----------------------------HAKKIMZDA KISIM-----------------------------------------------------------------------------------------------------//
        public ActionResult Hakkımızda()
        {
            var bl = db.TBLACIKLAMA.FirstOrDefault();
            return View("Hakkımızda", bl);
        }
        [HttpPost]
        [ValidateInput(false)]//SummerNote için
        public ActionResult Hakkımızda(TBLACIKLAMA hak, HttpPostedFileBase GELENRESIM)
        {
            var guncellenecekhak = db.TBLACIKLAMA.Find(hak.ID);
            if (GELENRESIM != null && GELENRESIM.ContentLength > 0)
            {

                if (GELENRESIM.ContentType == "image/jpeg" || GELENRESIM.ContentType == "image/png" || GELENRESIM.ContentType == "image/jpg" || GELENRESIM.ContentType == "image/jfif")
                {
                    var yol = Request.MapPath("~/IMG/" + guncellenecekhak.FotoUrl);
                    if (System.IO.File.Exists(yol))
                    {
                        System.IO.File.Delete(yol);
                    }

                    var fi = new FileInfo(GELENRESIM.FileName);
                    var fileName = Path.GetFileName(GELENRESIM.FileName);
                    fileName = Guid.NewGuid().ToString() + fi.Extension;
                    var path = Path.Combine(Server.MapPath("~/IMG/"), fileName);

                    WebImage rr = new WebImage(GELENRESIM.InputStream);

                    if (rr.Width > 1000)

                        rr.Resize(800, 800);

                    rr.Save(path);
                    guncellenecekhak.FotoUrl = fileName;
                }
                else
                {
                    TempData["hata"] = "Lütfem resim formatında bir dosya seçiniz!!!";
                    return View();
                }
            }
            guncellenecekhak.Aciklama = hak.Aciklama;
            db.SaveChanges();
            TempData["guncelle"] = "başarılı";
            return RedirectToAction("Hakkımızda");
        }
        //----------------------------HAKKIMZDA KISIM END--------------------------------------------------------------------------------------------------//










        //----------------------------İLETİŞİM KISIM-----------------------------------------------------------------------------------------------------//
        public ActionResult Iletisim()
        {
            var bl = db.TBLADRES.FirstOrDefault();
            return View("Iletisim", bl);
        }
        [HttpPost]
        [ValidateInput(false)]//SummerNote için
        public ActionResult Iletisim(TBLADRES hak)
        {
            var guncellenecekhak = db.TBLADRES.Find(hak.ID);
            guncellenecekhak.Adres = hak.Adres;
            guncellenecekhak.Telefon = hak.Telefon;
            guncellenecekhak.Mail = hak.Mail;
            guncellenecekhak.Konum = hak.Konum;
            db.SaveChanges();
            TempData["guncelle"] = "başarılı";
            return RedirectToAction("Iletisim");
        }
    }
}
