using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageTracking.Data;

namespace PackageTracking.Web.Controllers
{
    public class ClientsController : WebController
    {
        public ClientsController(PackageTrackingContext packageTrackingContext) : base(packageTrackingContext)
        {
        }

        public ActionResult Index(bool? showDisabled)
        {
            var query = _packageTrackingContext.Client.AsQueryable();
            if (showDisabled == false)
            {
                query = query.Where(c => c.Enabled);
            }
            query = query.OrderBy(c => c.Name);
            return View(query.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.Enabled = true;
                _packageTrackingContext.Client.Add(client);
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _packageTrackingContext.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                _packageTrackingContext.Entry(client).State = EntityState.Modified;
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //todo - move to ajax call
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = _packageTrackingContext.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            client.Enabled = !client.Enabled;
            _packageTrackingContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
