using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class AboutController : Controller
    {
        DbAcunmedyaAkademiPortfolioEntities db = new DbAcunmedyaAkademiPortfolioEntities();

        // GET: About
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
            
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(TblAbout model)
        {
            db.TblAbouts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout model)
        {
            var value = db.TblAbouts.Find(model.id);
            value.name = model.name;
            value.description = model.description;
            value.title = model.title;
            value.birthday = model.birthday;
            value.phone = model.phone;
            value.city = model.city;
            value.age = model.age;
            value.degree = model.degree;
            value.email = model.email;
            value.freelance = model.freelance;
            value.imgUrl = model.imgUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}