using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOApplication.Models.EntityFramework;
using TODOApplication.ViewModels;

namespace TODOApplication.Controllers
{
    public class HomeController : Controller
    {
        private TODOdbEntities db = new TODOdbEntities();
        public ActionResult Index()
        {
            DateTime startDate = DateTime.Today;
            var model = db.Content.ToList();          
            var idModel = db.Kullanici.ToList();
            var id = idModel.Find(x => x.Username.Equals(HttpContext.User.Identity.Name)).Id;
   
            var filteredData = model.Where(t => t.Date >= startDate && t.Status==false && t.UserId == id);
            return View(filteredData.ToList());
        }
       
        [HttpGet]
        public ActionResult Yeni()
        {
            
            var model = new ContentFormView()
            {
                Content = new Models.EntityFramework.Content(),
                Kullanicilar = db.Kullanici.ToList()
            };
            return View("ContentForm",model);
        }
        
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Content content)
        {
            if (!ModelState.IsValid)
            {
                var model = new ContentFormView()
                {
                    Kullanicilar = db.Kullanici.ToList(),
                    Content = content
                };
                return View("ContentForm",model);
            }

            if (content.Id == 0)
            {
                db.Content.Add(content);
            }
            else
            {
                db.Entry(content).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Guncelle(int id)
        {
            var model = new ContentFormView()
            {
                Kullanicilar = db.Kullanici.ToList(),
                Content = db.Content.Find(id)
            };
            return View("ContentForm",model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekContent = db.Content.Find(id);

            if(silinecekContent == null)
            {
                return HttpNotFound();
            }
            db.Content.Remove(silinecekContent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Done(int id)
        {
            var düzenlenecekContent = db.Content.Find(id);
            if(düzenlenecekContent == null)
            {
                return HttpNotFound();
            }
            db.Content.Find(id).Status= true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}