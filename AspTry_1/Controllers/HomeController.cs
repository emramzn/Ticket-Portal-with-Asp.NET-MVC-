using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;


namespace AspTry_1.Controllers
{
    public class HomeController : Controller
    {  
        DatabaseDBEntities4 dataVeri = new DatabaseDBEntities4();

     
        // GET: Home
        public ActionResult Index()
        {
            var model = dataVeri.Gorevler.ToList();
            string birimTipi = Session["birim"].ToString();

            List<Gorevler> gorevList = (from y in dataVeri.Gorevler where y.Birim == birimTipi where y.Durum=="olmadi" where y.gorevAalan=="yok" orderby y.Tarih descending select y).Take(100).ToList();

            return View(gorevList);

        }

        [HttpPost]
        public ActionResult Index(int idget, string aciklama)
        {


            Gorevler zBul = (from y in dataVeri.Gorevler where y.Id == idget select y).FirstOrDefault();
            if (zBul != null)
            {

                zBul.Durum = "islemde";
                zBul.Aciklama = zBul.Aciklama+"\n"+ " [ İşleme Alınma Açıklaması ] " + "--> "+aciklama;
                zBul.gorevAalan = Session["kuladi"].ToString();
                dataVeri.SaveChanges();


                return  RedirectToAction("devamIslem", "islemdekiler");
            }

          
            return View();
        }

      


        [HttpPost]
        public ActionResult login(string userName, string password)
        {
            tableOfUsers data = new tableOfUsers();

            return View();

        }
        [HttpPost]
        public ActionResult yonlendir(int gorevId, string kulAdi)
        {

        
            Gorevler zBul = (from y in dataVeri.Gorevler where y.Id == gorevId select y).FirstOrDefault();
            if (zBul != null)
            {
                zBul.gorevAalan = kulAdi;
                dataVeri.SaveChanges();
               
                return RedirectToAction("Index", "Home");

            }
            
            return View();


        }
        [HttpGet]
        public ActionResult yonlendir()
        {

            return View();


        }

    }
}