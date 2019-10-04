using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;

namespace AspTry_1.Controllers
{
    public class islemdekilerController : Controller
    {
        // GET: islemdekiler
        DatabaseDBEntities4 datas = new DatabaseDBEntities4();
        public ActionResult devamIslem()
        {
            string kuladi = Session["kuladi"].ToString();
            List<Gorevler> zBul = (from y in datas.Gorevler where y.gorevAalan == kuladi where y.Durum == "islemde" select y).ToList();
            if (zBul != null)
            {

                return View(zBul);

            }
            else
            {
                ViewBag.name = "Kayıt Bulunmamaktadır.";
                return View();

            }

            return View();


        }
        [HttpPost]

        public ActionResult devamIslem(int id, string aciklama)
        {
            string kuladi = Session["kuladi"].ToString();
            Gorevler zBul = (from y in datas.Gorevler where y.Id == id select y).FirstOrDefault();
            if (zBul != null)
            {

                zBul.Aciklama = zBul.Aciklama + " [ İŞLEM BİTİŞ AÇIKLAMASI ] " +" --> "+ aciklama.ToString();
                zBul.Durum = "bitti";
                datas.SaveChanges();

                return RedirectToAction("gorevler", "Gorevler");

            }

            return View();


        }

        [HttpPost]
        public ActionResult kayitSil(int id)
        {
            Gorevler zBulSil = (from y in datas.Gorevler where y.Id ==id  select y).FirstOrDefault();
            if (zBulSil != null)
            {
                datas.Gorevler.Remove(zBulSil);
                datas.SaveChanges();
                return RedirectToAction("gorevler", "Gorevler");
            }
            return View() ;
        }
    }
}