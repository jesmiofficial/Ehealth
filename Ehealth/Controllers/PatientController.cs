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
    public class PatientController : Controller
    {
        private EhealthContext db = new EhealthContext();

        // GET: Patient
        public ActionResult Index()
        {
            var patients = db.patients.Include(p => p.doctor).Include(p => p.doctor1).Include(p => p.history).Include(p => p.hospital).Include(p => p.test_results).Include(p => p.test_types);
            return View(patients.ToList());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName");
            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName");
            ViewBag.history_id = new SelectList(db.histories, "id", "historyDetails");
            ViewBag.hospital_id = new SelectList(db.hospitals, "id", "hospitalName");
            ViewBag.test_result_id = new SelectList(db.test_results, "id", "patientNhsNo");
            ViewBag.test_type_id = new SelectList(db.test_types, "id", "testName");
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,patientNhsNo,patientName,patientContact,patientEmail,patientDob,patientAddress,hospital_id,arrivalTime,arrivalDate,history_id,test_result_id,test_type_id,doctor_id,followUps")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName", patient.doctor_id);
            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName", patient.doctor_id);
            ViewBag.history_id = new SelectList(db.histories, "id", "historyDetails", patient.history_id);
            ViewBag.hospital_id = new SelectList(db.hospitals, "id", "hospitalName", patient.hospital_id);
            ViewBag.test_result_id = new SelectList(db.test_results, "id", "patientNhsNo", patient.test_result_id);
            ViewBag.test_type_id = new SelectList(db.test_types, "id", "testName", patient.test_type_id);
            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName", patient.doctor_id);
            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName", patient.doctor_id);
            ViewBag.history_id = new SelectList(db.histories, "id", "historyDetails", patient.history_id);
            ViewBag.hospital_id = new SelectList(db.hospitals, "id", "hospitalName", patient.hospital_id);
            ViewBag.test_result_id = new SelectList(db.test_results, "id", "patientNhsNo", patient.test_result_id);
            ViewBag.test_type_id = new SelectList(db.test_types, "id", "testName", patient.test_type_id);
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,patientNhsNo,patientName,patientContact,patientEmail,patientDob,patientAddress,hospital_id,arrivalTime,arrivalDate,history_id,test_result_id,test_type_id,doctor_id,followUps")] patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName", patient.doctor_id);
            ViewBag.doctor_id = new SelectList(db.doctors, "id", "doctorName", patient.doctor_id);
            ViewBag.history_id = new SelectList(db.histories, "id", "historyDetails", patient.history_id);
            ViewBag.hospital_id = new SelectList(db.hospitals, "id", "hospitalName", patient.hospital_id);
            ViewBag.test_result_id = new SelectList(db.test_results, "id", "patientNhsNo", patient.test_result_id);
            ViewBag.test_type_id = new SelectList(db.test_types, "id", "testName", patient.test_type_id);
            return View(patient);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            patient patient = db.patients.Find(id);
            db.patients.Remove(patient);
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
