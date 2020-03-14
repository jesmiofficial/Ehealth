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
    public class test_typeController : Controller
    {
        private EhealthContext db = new EhealthContext();

        // GET: test_type
        public ActionResult Index()
        {
            return View(db.test_types.ToList());
        }

        // GET: test_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test_types test_types = db.test_types.Find(id);
            if (test_types == null)
            {
                return HttpNotFound();
            }
            return View(test_types);
        }

        // GET: test_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: test_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,testName")] test_types test_types)
        {
            if (ModelState.IsValid)
            {
                db.test_types.Add(test_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test_types);
        }

        // GET: test_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test_types test_types = db.test_types.Find(id);
            if (test_types == null)
            {
                return HttpNotFound();
            }
            return View(test_types);
        }

        // POST: test_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,testName")] test_types test_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test_types);
        }

        // GET: test_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test_types test_types = db.test_types.Find(id);
            if (test_types == null)
            {
                return HttpNotFound();
            }
            return View(test_types);
        }

        // POST: test_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            test_types test_types = db.test_types.Find(id);
            db.test_types.Remove(test_types);
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
