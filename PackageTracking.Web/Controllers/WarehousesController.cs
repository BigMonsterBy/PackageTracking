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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WarehouseId,ClientId,Name,Email,PhoneNumber,Skype,Telegram,Address," +
            "WorkingTime,ResponsiblePerson")] Warehouse warehouse)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WarehouseId,ClientId,Name,Email,PhoneNumber,Skype,Telegram,Address," +
            "WorkingTime,ResponsiblePerson")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _packageTrackingContext.Warehouse.Attach(warehouse);
                _packageTrackingContext.Entry(warehouse).State = EntityState.Modified;
                _packageTrackingContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(_packageTrackingContext.Client, "ClientId", "Name", warehouse.ClientId);
            return View(warehouse);
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var warehouse = _packageTrackingContext.Warehouse.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            warehouse.Enabled = !warehouse.Enabled;
            _packageTrackingContext.SaveChanges();
            return RedirectToAction("Edit", "Clients");
        }
    }
}
