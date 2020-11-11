﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOApplication.Models.EntityFramework;
using TODOApplication.ViewModels;

namespace TODOApplication.Controllers
{
    public class WeekController : Controller
    {
        private TODOdbEntities db = new TODOdbEntities();
        // GET: Today
        public ActionResult Index()
        {
            //Today-to 1 Week
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;
            if(startDate.DayOfWeek == DayOfWeek.Monday)
            {
                endDate = startDate.AddDays(1);
            }
            while (endDate.DayOfWeek != DayOfWeek.Monday)
            {
                endDate = endDate.AddDays(1);
            }
             

            var model = db.Content.ToList();
            var idModel = db.Kullanici.ToList();
            var id = idModel.Find(x => x.Username.Equals(HttpContext.User.Identity.Name)).Id;
            var filteredData = model.Where(t => t.Date >= startDate && t.Date < endDate && t.Status==false && t.UserId == id);
            return View(filteredData.ToList());
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
                return View("WeekContentForm", model);
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
            return View("WeekContentForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekContent = db.Content.Find(id);

            if (silinecekContent == null)
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
            if (düzenlenecekContent == null)
            {
                return HttpNotFound();
            }
            db.Content.Find(id).Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}