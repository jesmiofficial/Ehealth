using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ehealth.Models;

namespace Ehealth.Controllers
{
    public class HistoryController : Controller
    {
        private EhealthContext db = new EhealthContext();

        // GET: History
        public ActionResult Index()
        {
            var histories = db.histories.Include(h => h.patient);
            return View(histories.ToList());
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            history history = db.histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // GET: History/Create
        public ActionResult Create()
        {
            ViewBag.patient_id = new SelectList(db.patients, "id", "patientNhsNo");
            return View();
        }

        // POST: History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,patient_id,patientNhsNo,historyDetails")] history history)
        {
            if (ModelState.IsValid)
            {
                db.histories.Add(history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.patient_id = new SelectList(db.patients, "id", "patientNhsNo", history.patient_id);
            return View(history);
        }

        // GET: History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            history history = db.histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            ViewBag.patient_id = new SelectList(db.patients, "id", "patientNhsNo", history.patient_id);
            return View(history);
        }

        // POST: History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,patient_id,patientNhsNo,historyDetails")] history history)
        {
            if (ModelState.IsValid)
            {
                db.Entry(history).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.patient_id = new SelectList(db.patients, "id", "patientNhsNo", history.patient_id);
            return View(history);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            history history = db.histories.Find(id);
            if (history == null)
            {
                return HttpNotFound();
            }
            return View(history);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            history history = db.histories.Find(id);
            db.histories.Remove(history);
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
