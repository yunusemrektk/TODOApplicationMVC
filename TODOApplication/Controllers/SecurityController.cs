using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TODOApplication.Models.EntityFramework;

namespace TODOApplication.Controllers
{
    public class SecurityController : Controller
    {
        TODOdbEntities db = new TODOdbEntities();
        // GET: Security

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciInDb = db.Kullanici.FirstOrDefault(x => x.Username == kullanici.Username && x.Password == kullanici.Password);
            if (kullaniciInDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

    }
}