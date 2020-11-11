using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOApplication.Models.EntityFramework;
using TODOApplication.ViewModels;

namespace TODOApplication.Controllers
{
    public class DoneController : Controller
    {
        private TODOdbEntities db = new TODOdbEntities();
        public ActionResult Index()
        {
            DateTime startDate = DateTime.Today;
            var model = db.Content.ToList();
            var idModel = db.Kullanici.ToList();
            var id = idModel.Find(x => x.Username.Equals(HttpContext.User.Identity.Name)).Id;
            var filteredData = model.Where(t => (t.Date < startDate || t.Status ==true) && t.UserId == id);
            return View(filteredData.ToList());
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

    }
}