using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models.EntityFramework;
namespace OgrenciBilgiSistemi.Controllers


{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        ObsSistemDBEntities db = new ObsSistemDBEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAd,
                                                 Value = i.KulupID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KulupID == p3.TBLKULUPLER.KulupID).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var GetirilecekOgrenci = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir", GetirilecekOgrenci);
        }
        public ActionResult Guncelle(TBLOGRENCILER p7)
        {
            var ogr = db.TBLOGRENCILER.Find(p7.OgrenciID);
            ogr.OgrenciAd = p7.OgrenciAd;
            ogr.OgrenciSoyad = p7.OgrenciSoyad;
            ogr.OgrenciFotograf = p7.OgrenciFotograf;
            ogr.OgrenciCinsiyet = p7.OgrenciCinsiyet;
            ogr.OgrenciKulup = p7.OgrenciKulup;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }


    }
}