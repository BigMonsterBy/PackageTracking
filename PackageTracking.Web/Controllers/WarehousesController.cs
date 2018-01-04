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
    public class WarehousesController : WebController
    {
        public WarehousesController(PackageTrackingContext packageTrackingContext) : base(packageTrackingContext)
        {
        }

        // GET: Warehouses
        public ActionResult Index()
        {
            var warehouse = _packageTrackingContext.Warehouse.Include(w => w.Client);
            return View(warehouse.ToList());
        }

        // GET: Warehouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = _packageTrackingContext.Warehouse.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // GET: Warehouses/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_packageTrackingContext.Client, "ClientId", "Name");
            return View();
        }

        // POST: Warehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WarehouseId,ClientId,Name")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _packageTrackingContext.Warehouse.Add(warehouse);
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_packageTrackingContext.Client, "ClientId", "Name", warehouse.ClientId);
            return View(warehouse);
        }
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WarehouseId,ClientId,Name")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                DbSet dbSet = _packageTrackingContext.Warehouse;
                dbSet.Add(warehouse);
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_packageTrackingContext.Client, "ClientId", "Name", warehouse.ClientId);
            return View(warehouse);
        }*/

        // GET: Warehouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = _packageTrackingContext.Warehouse.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(_packageTrackingContext.Client, "ClientId", "Name", warehouse.ClientId);
            return View(warehouse);
        }

        // POST: Warehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WarehouseId,ClientId,Name")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _packageTrackingContext.Entry(warehouse).State = EntityState.Modified;
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(_packageTrackingContext.Client, "ClientId", "Name", warehouse.ClientId);
            return View(warehouse);
        }

        // GET: Warehouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse warehouse = _packageTrackingContext.Warehouse.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warehouse warehouse = _packageTrackingContext.Warehouse.Find(id);
            _packageTrackingContext.Warehouse.Remove(warehouse);
            _packageTrackingContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
