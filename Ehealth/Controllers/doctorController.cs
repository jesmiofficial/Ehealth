using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ehealth.Models;
using System.Data.SqlClient;

namespace Ehealth.Controllers
{
    public class doctorController : Controller
    {
        private EhealthContext db = new EhealthContext();

        // GET: doctor
        public ActionResult Index()
        {
            var doctors = db.doctors.Include(d => d.speciality).Include(d => d.user);
            return View(doctors.ToList());
        }

        // GET: doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

          // GET: doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.speciality_id = new SelectList(db.specialities, "id", "specialityName", doctor.speciality_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", doctor.user_id);
            return View(doctor);
        }

        // GET: doctor/Create
        public ActionResult Create()
        {
            ViewBag.speciality_id = new SelectList(db.specialities, "id", "specialityName");
           // ViewBag.user_id = new SelectList(db.users, "id", "username");
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            try
            {

                EhealthContext db = new EhealthContext();
                ViewBag.speciality_id = new SelectList(db.specialities, "id", "specialityName");

                user user = new user();
                user.username = model.username;
                user.password = model.password;
                user.role_id = model.role_id;

                db.users.Add(user);
                db.SaveChanges();

                int latestUserId = user.id;


                doctor doctor = new doctor();
                doctor.doctorName = model.doctorName;
                doctor.speciality_id = model.speciality_id;
                doctor.availableTime = model.availableTime;
                doctor.availableDate = model.availableDate;
                doctor.doctorContact = model.doctorContact;
                doctor.doctorEmail = model.doctorEmail;
                doctor.user_id = latestUserId;

                db.doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw ex;
            }

#pragma warning disable CS0162 // Unreachable code detected
            return View(model);
#pragma warning restore CS0162 // Unreachable code detected
        }


        // POST: doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,doctorName,speciality_id,availableTime,availableDate,doctorContact,doctorEmail,user_id")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.speciality_id = new SelectList(db.specialities, "id", "specialityName", doctor.speciality_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", doctor.user_id);
            return View(doctor);
        }

        // GET: doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doctor doctor = db.doctors.Find(id);
            db.doctors.Remove(doctor);
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
