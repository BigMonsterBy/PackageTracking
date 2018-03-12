using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using PackageTracking.Data;
using PackageTracking.Web.Infrastructure;

namespace PackageTracking.Web.Controllers
{
    public class UsersController : WebController
    {
        public UsersController(PackageTrackingContext packageTrackingContext) : base(packageTrackingContext)
        {
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _packageTrackingContext.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Password,IsGlobalAdmin,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                
                user.Password = Chipher.GetMd5Hash(user.Password);
                user.LastLogOn = DateTime.UtcNow;
                _packageTrackingContext.User.Add(user);
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _packageTrackingContext.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Password,IsGlobalAdmin,Email,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = _packageTrackingContext.User.Find(user.UserId);
                updatedUser.PhoneNumber = user.PhoneNumber;
                //user.Password = Chipher.GetMd5Hash(user.Password);
                _packageTrackingContext.Entry(updatedUser).State = EntityState.Modified;
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _packageTrackingContext.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _packageTrackingContext.User.Find(id);
            _packageTrackingContext.User.Remove(user);
            _packageTrackingContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
