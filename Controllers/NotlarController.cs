using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models.EntityFramework;
using OgrenciBilgiSistemi.Models;
namespace OgrenciBilgiSistemi.Controllers



{
    public class NotlarController : Controller
    {
        // GET: Notlar
        ObsSistemDBEntities db = new ObsSistemDBEntities();
        public ActionResult Index()
        {
            var SinavNotlar = db.TBLNOTLAR.ToList();
            return View(SinavNotlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR tbn)
        {
            db.TBLNOTLAR.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var GetirilecekNot = db.TBLNOTLAR.Find(id);
            return View("NotGetir", GetirilecekNot);
        }
        [HttpPost]
        public ActionResult NotGetir(TBLNOTLAR p8,int Sınav1,int Sınav2,int Sınav3, int Proje,Class1 model )
        {
            if(model.islem=="Hesapla")
            {
                int Ortalama = (Sınav1 + Sınav2 + Sınav3 + Proje) / 4;
                ViewBag.ort = Ortalama;

            }
            if (model.islem == "NotGuncelle")
            {

            }
            return View();
        }
        
    }
}