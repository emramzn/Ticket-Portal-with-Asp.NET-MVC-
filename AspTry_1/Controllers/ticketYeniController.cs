using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;

namespace AspTry_1.Controllers
{
    public class ticketYeniController : Controller
    {
        // GET: ticketYeni


        DatabaseDBEntities4 datas = new DatabaseDBEntities4();
        public ActionResult yeniAtanan()
        {
            string kuladi = Session["kuladi"].ToString();
            List<Gorevler> zBul = (from y in datas.Gorevler where y.Durum == "olmadi" where y.gorevAalan!="yok" select y).ToList();
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

        [HttpGet]
        public ActionResult ticketBiten()
        {
            string kuladi = Session["kuladi"].ToString();
            List<Gorevler> zBul = (from y in datas.Gorevler where y.Durum == "bitti" where y.gorevAalan != "yok" select y).ToList();
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



    }
}