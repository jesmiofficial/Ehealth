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
    public class userController : Controller
    {
        private EhealthContext db = new EhealthContext();

        // GET: user
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: user/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: user/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,role_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: user/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,role_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: user/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Login(user user)
        //{
        //    using (EhealthContext db = new EhealthContext())
        //    {
        //        var usr = db.users.Single(u => u.username == user.username && u.password == user.password);
        //        if (usr != null)
        //        {
        //            Session["UserID"] = usr.id.ToString();
        //            Session["UserName"] = usr.username.ToString();
        //            return RedirectToAction("LoggedIn");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Username or Password is wrong");
        //        }
        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Login(user user)
        {
            using (EhealthContext db = new EhealthContext())
            {
                var usr = db.users.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();
                if (usr == null)
                {
                    user.LoginErrorMessage = "Wrong Username or Password";
                    return View("Login", user);
                }else
                {
                    Session["UserID"] = usr.id;
                    Session["UserName"] = usr.username;
                    return RedirectToAction("Index","Login");

                }
               }
#pragma warning disable CS0162 // Unreachable code detected
            return View();
#pragma warning restore CS0162 // Unreachable code detected
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");

            }
        }

        public ActionResult Logout()
        {
            int id = (int)Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Login","user");
        }
        
}}
