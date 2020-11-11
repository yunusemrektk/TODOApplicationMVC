using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TODOApplication.Models.EntityFramework;

namespace TODOApplication.Controllers
{
    public class KullaniciController : Controller
    {
        TODOdbEntities db = new TODOdbEntities();
        // GET: Security
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(Kullanici kullanici)
        {
           
            if (ModelState.IsValid)
            {
                db.Kullanici.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("LogIn", "Security");
            }
            return View();
        
        }

    }
}