using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspTry_1.Controllers
{
    public class kullaniciYonetimiController : Controller
    {
        // GET: kullaniciYonetimi
        public ActionResult YonKullanicilar()
        {
            return View();
        }
    }
}