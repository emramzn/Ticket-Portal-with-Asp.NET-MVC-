using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;

namespace AspTry_1.Controllers
{
    public class GorevlerController : Controller
    {
        DatabaseDBEntities4 datas = new DatabaseDBEntities4();
        // GET: Gorevler
        public ActionResult gorevler()
        {

            string kuladi = Session["kuladi"].ToString();
            List<Gorevler> zBul = (from y in datas.Gorevler where y.gorevAalan == kuladi where y.Durum == "bitti" select y).ToList();
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