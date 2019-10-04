using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;

namespace AspTry_1.Controllers
{
    public class yenikayitController : Controller
    {

        DatabaseDBEntities4 datas = new DatabaseDBEntities4();
        // GET: yenikayit
        [HttpPost]
        public ActionResult Yenikayit(FormCollection form)
        {

                kullanicilar kayit = new kullanicilar();
                kayit.AdSoyad = form["personelAdSoyad"].Trim();
                kayit.kulAdi = form["kulAdi"].Trim();
                kayit.sifre = form["sifre"].Trim();
                kayit.birim = form["birim"].Trim();
                kayit.yetki = "3";
                kayit.foto = "~/erkek-profil-resmi.jpg";

                datas.kullanicilar.Add(kayit);
                datas.SaveChanges();
                return RedirectToAction("loginPage", "login");
        

        }
        [HttpGet]
        public ActionResult Yenikayit()
        {
            return View();

        }
    }
}