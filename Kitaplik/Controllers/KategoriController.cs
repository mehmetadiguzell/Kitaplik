using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kitaplik.Models;

namespace Kitaplik.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        KitaplikDbEntities db = new KitaplikDbEntities();
        public ActionResult Index()
        {
            var model = db.Kategori.ToList();
            return View(model);
        }

        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kategori kategori)
        {
            db.Kategori.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model=db.Kategori.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(Kategori kategori)
        {
            var model = db.Kategori.FirstOrDefault(X=>X.Id==kategori.Id);
            model.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}