using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;



namespace AspTry_1.Controllers
{
    
    public class loginController : Controller
    {  
         // GET: login
        DatabaseDBEntities4 datas = new DatabaseDBEntities4();

        public ActionResult loginPage()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult loginPage(string kuladi, string sifre)
        {

            kullanicilar zBul = (from y in datas.kullanicilar where y.kulAdi == kuladi where y.sifre==sifre select y).FirstOrDefault();
            if (zBul != null)
            {
                


                Session["kuladi"] = kuladi;
                Session["adSoyad"] = zBul.AdSoyad;
                Session["birim"] = zBul.birim.ToString().Trim();
                Session["yetki"] = zBul.yetki;
                Session["sifre"] = zBul.sifre;
                Session["foto"] = zBul.foto;

                return RedirectToAction("Index","Home");
               
               
            }
            else
            {
                ViewBag.name = "Giriş Yanlış";
                return View() ;
            }

           
        }
        public ActionResult logout()
        {
            
            Session.Clear();
            Session.Remove("kuladi");
           
            return RedirectToAction("loginPage","login");
        }
    }
}