using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models.EntityFramework;
namespace OgrenciBilgiSistemi.Controllers

{
    public class KuluplerController : Controller
    {
       // GET:Kulupler
        ObsSistemDBEntities db = new ObsSistemDBEntities();

        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p2)
        {
            db.TBLKULUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var GetirilecekKulup = db.TBLKULUPLER.Find(id);
            return View("KulupGetir", GetirilecekKulup);
        }
        public ActionResult Guncelle(TBLKULUPLER p10)
        {
            var kulup1 = db.TBLKULUPLER.Find(p10.KulupID);
            kulup1.KulupAd = p10.KulupAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}