using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class ContactController : Controller
    {
        DbAcunmedyaAkademiPortfolioEntities db = new DbAcunmedyaAkademiPortfolioEntities();

        // GET: Contact
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(TblContact model)
        {
            db.TblContacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContacts.Find(id);
            db.TblContacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(TblContact model)
        {
            var value = db.TblContacts.Find(model.ContactId);
            value.Email = model.Email;
            value.Adress = model.Adress;
            value.Phone = model.Phone;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}