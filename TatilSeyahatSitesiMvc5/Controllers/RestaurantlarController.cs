using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSitesiMvc5.Models;

namespace TatilSeyahatSitesiMvc5.Controllers
{
    public class RestaurantlarController : Controller
    {
        Mvc5TatilSeyehatEntities db =new Mvc5TatilSeyehatEntities();
        // GET: Restaurantlar
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.restaurant = db.TBLRESTAURANT.ToList();
            by.restaurant2 = db.TBLRESTAURANT.OrderByDescending(x => x.ID).Take(5).ToList();
            by.restaurantyorum = db.TBLRESTAURANTYORUM.Where(x=>x.DURUM==true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
        public ActionResult RestaurantDetay(int id)
        {
            by.restaurant = db.TBLRESTAURANT.Where(x => x.ID == id).ToList();
            by.restaurantyorum = db.TBLRESTAURANTYORUM.Where(x => x.RestaurantID == id && x.DURUM==true).ToList();
            by.restaurant2 = db.TBLRESTAURANT.OrderByDescending(x => x.ID).Take(5).ToList();
            by.restaurantyorum2 = db.TBLRESTAURANTYORUM.Where(x=>x.DURUM==true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
        
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(TBLRESTAURANTYORUM y)
        {
            TBLRESTAURANTYORUM yeni = new TBLRESTAURANTYORUM();
            yeni.KullaniciAdi = y.KullaniciAdi;
            yeni.Yorum = y.Yorum;
            yeni.Mail = y.Mail;
            yeni.RestaurantID = y.RestaurantID;
            yeni.DURUM = false;
            yeni.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.TBLRESTAURANTYORUM.Add(yeni);
            db.SaveChanges();
            Response.Redirect("/Restaurantlar/RestaurantDetay/" + y.RestaurantID);
            return PartialView();
        }
    }
}