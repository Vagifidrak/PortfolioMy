using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Areas.PortAdmin.Controllers
{
    public class AdminServicesCountersController : Controller
    {
        private DevPortfolioDP db = new DevPortfolioDP();

        // GET: PortAdmin/AdminServicesCounters
        public ActionResult Index()
        {
            return View(db.ServicesCounters.ToList());
        }

        // GET: PortAdmin/AdminServicesCounters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesCounter servicesCounter = db.ServicesCounters.Find(id);
            if (servicesCounter == null)
            {
                return HttpNotFound();
            }
            return View(servicesCounter);
        }

        // GET: PortAdmin/AdminServicesCounters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortAdmin/AdminServicesCounters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Counterİcon,CounterNum,CounterText")] ServicesCounter servicesCounter)
        {
            if (ModelState.IsValid)
            {
                db.ServicesCounters.Add(servicesCounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicesCounter);
        }

        // GET: PortAdmin/AdminServicesCounters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesCounter servicesCounter = db.ServicesCounters.Find(id);
            if (servicesCounter == null)
            {
                return HttpNotFound();
            }
            return View(servicesCounter);
        }

        // POST: PortAdmin/AdminServicesCounters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Counterİcon,CounterNum,CounterText")] ServicesCounter servicesCounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicesCounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicesCounter);
        }

        // GET: PortAdmin/AdminServicesCounters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesCounter servicesCounter = db.ServicesCounters.Find(id);
            if (servicesCounter == null)
            {
                return HttpNotFound();
            }
            return View(servicesCounter);
        }

        // POST: PortAdmin/AdminServicesCounters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicesCounter servicesCounter = db.ServicesCounters.Find(id);
            db.ServicesCounters.Remove(servicesCounter);
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
