using Kitaplik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Kitaplik.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KitaplikDbEntities db = new KitaplikDbEntities();
        public ActionResult Index()
        {
            var model = db.Kitap.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Ekle(Kitap kitap)
        {
            db.Kitap.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Ekle()
        {
            List<SelectListItem> selectLists = (from i in db.Kategori
                                                select new SelectListItem()
                                                {
                                                    Text = i.KategoriAd,
                                                    Value = i.Id.ToString()
                                                }).ToList();
            ViewBag.list= selectLists;

            return View();
        }

        public ActionResult Sil(int id)
        {
            var model = db.Kitap.FirstOrDefault(x => x.Id == id);
            db.Kitap.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            List<SelectListItem> selectLists = (from i in db.Kategori
                                                select new SelectListItem()
                                                {
                                                    Text = i.KategoriAd,
                                                    Value = i.Id.ToString()
                                                }).ToList();
            ViewBag.list = selectLists;

            var model = db.Kitap.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(Kitap kitap)
        {
            var model = db.Kitap.Find(kitap.Id);
            model.KitapAd = kitap.KitapAd;
            model.Yazari = kitap.Yazari;
            model.SayfaSayisi = kitap.SayfaSayisi;
            model.KategoriId = kitap.KategoriId;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}