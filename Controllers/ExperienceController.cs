using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        DbAcunmedyaAkademiPortfolioEntities db = new DbAcunmedyaAkademiPortfolioEntities();

        // GET: Experience
        public ActionResult Index()
        {
            var values = db.TblExperiences.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience model)
        {
            db.TblExperiences.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperience model)
        {
            var value = db.TblExperiences.Find(model.ExperienceId);
            value.Title = model.Title;
            value.StartYear = model.Description;
            value.EndYear = model.EndYear;
            value.Company = model.Company;
            value.City = model.City;
            value.Description = model.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}