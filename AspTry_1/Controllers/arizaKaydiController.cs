using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;

namespace AspTry_1.Controllers
{
    public class arizaKaydiController : Controller
    {
        // GET: arizaKaydi
        DatabaseDBEntities4 datas = new DatabaseDBEntities4();
        public ActionResult arizaKayitIslem()
        {

            return View();
          
        }

        [HttpPost]
        public ActionResult arizaKayitIslem(FormCollection form)
        {

            Gorevler gorev = new Gorevler();
            gorev.isbaslik = form["baslik"].Trim();
            gorev.Aciklama = form["aciklama"].Trim();
            gorev.gorevAalan = "yok";
            gorev.Durum = "olmadi";
            gorev.Birim = form["birim"].Trim();
            gorev.PersonelAdSoyad = form["personelAdSoyad"].Trim();
            gorev.Tarih = DateTime.Today;
            datas.Gorevler.Add(gorev);
            datas.SaveChanges();

            return RedirectToAction("Index","Home");
            
        }
     


        public ActionResult listele()
        {

            List<SelectListItem> birimDB = new List<SelectListItem>();
            foreach (var item in datas.birimler.ToList())
            {
                birimDB.Add(new SelectListItem { Text = item.birimAdi, Value = item.birimID_.ToString() });
            }

            ViewBag.birimler = birimDB;
            return View();
        }

    }
}