using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspTry_1.Models;
using System.IO;

namespace AspTry_1.Controllers
{
    public class hesapController : Controller
    {

        DatabaseDBEntities4 datas = new DatabaseDBEntities4();
        // GET: hesap
        public ActionResult hesabiDuzenle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult hesabiDuzenle(FormCollection form)
        {
            string kulAdi = Session["kulAdi"].ToString().Trim();
            kullanicilar zBul = (from y in datas.kullanicilar where y.kulAdi == kulAdi select y).FirstOrDefault();
            if (zBul != null)
            {

                zBul.AdSoyad = form["personelAdSoyad"].Trim();
                zBul.kulAdi = form["kulAdi"].Trim();
                zBul.sifre = form["sifre"].Trim();

                datas.SaveChanges();
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("loginPage", "login");


            }



            return View();
        }
        [HttpPost]
            
        public ActionResult Add(HttpPostedFileBase file)
        {

            //return Path.GetFileName(file.FileName);
            if (ModelState.IsValid)
            {
                try
                {


                    if (file != null)
                    {
                      
                        string path = Path.Combine(Server.MapPath("~/profil/") +file.FileName);
                        string path2 = Path.Combine(("~/profil/") + file.FileName);
                        file.SaveAs(path);
                        ViewBag.FileStatus = "Yükleme Başarılı";

                        string kulAdi = Session["kulAdi"].ToString().Trim();
                        kullanicilar zBul = (from y in datas.kullanicilar where y.kulAdi == kulAdi select y).FirstOrDefault();
                        if (zBul != null)
                        {
                            zBul.foto = path2;
                            datas.SaveChanges();

                        }
                    }

                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Hata oluştu";
                }

            }
            return View("hesabiDuzenle");
        }


        [HttpGet]

        public ActionResult Add()
        {
            return View();
        }
    }
}