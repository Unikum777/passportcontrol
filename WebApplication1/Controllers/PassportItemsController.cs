using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PassportItemsController : Controller
    {
        private PassportControlEntities db = new PassportControlEntities();

        // GET: PassportItems
        public ActionResult Index()
        {
            var passportList = db.Passports.ToList();

            passportList.ForEach(p => p.PlaceOfBirthItem = db.Places.Single(pl => pl.Id == p.PlaceOfBirthId));
            passportList.Sort();
            return View(passportList);
        }

        // GET: PassportItems/Search
        public ActionResult Search()
        {
            var passportList = db.Passports.ToList();

            passportList.ForEach(p => p.PlaceOfBirthItem = db.Places.Single(pl => pl.Id == p.PlaceOfBirthId));
            passportList.Sort();
            return View(passportList);
        }

        // GET: PassportItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassportItem passportItem = db.Passports.Find(id);
            passportItem.PlaceOfBirthItem = db.Places.Single(pl => pl.Id == passportItem.PlaceOfBirthId);
            if (passportItem == null)
            {
                return HttpNotFound();
            }
            return View(passportItem);
        }

        // GET: PassportItems/Create
        public ActionResult Create()
        {
            ViewBag.PlacesList = new SelectList(db.Places, "Id", "Name", "1");
            return View();
        }

        // POST: PassportItems/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,Name,MiddleName,Birthday,Sex,Series,Number,DateOfIssue,IssuaDepartmentCode,PlaceOfBirthId,PlaceOfIssue")] PassportItem passportItem)
        {
            if (ModelState.IsValid)
            {
                db.Passports.Add(passportItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlacesList = new SelectList(db.Places, "Id", "Name", "1");
            return View(passportItem);
        }

        // GET: PassportItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassportItem passportItem = db.Passports.Find(id);
            passportItem.PlaceOfBirthItem = db.Places.Single(pl => pl.Id == passportItem.PlaceOfBirthId);
            if (passportItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlacesList = new SelectList(db.Places, "Id", "Name", passportItem.PlaceOfBirthId);
            return View(passportItem);
        }

        // POST: PassportItems/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,MiddleName,Birthday,Sex,Series,Number,DateOfIssue,IssuaDepartmentCode,PlaceOfBirthId,PlaceOfIssue")] PassportItem passportItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passportItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlacesList = new SelectList(db.Places, "Id", "Name", passportItem.PlaceOfBirthId);
            return View(passportItem);
        }

        // GET: PassportItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PassportItem passportItem = db.Passports.Find(id);
            if (passportItem == null)
            {
                return HttpNotFound();
            }
            return View(passportItem);
        }

        // POST: PassportItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PassportItem passportItem = db.Passports.Find(id);
            db.Passports.Remove(passportItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
