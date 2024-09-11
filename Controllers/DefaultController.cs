using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models.EntityFramework;
namespace OgrenciBilgiSistemi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        ObsSistemDBEntities db = new ObsSistemDBEntities();

        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var GetirilecekDers = db.TBLDERSLER.Find(id);
            return View("DersGetir", GetirilecekDers);
        }
        public ActionResult Guncelle(TBLDERSLER p9)
        {
            var drs = db.TBLDERSLER.Find(p9.DersID);
            drs.DersAd = p9.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}