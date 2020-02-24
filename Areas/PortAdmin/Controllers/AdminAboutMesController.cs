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
    public class AdminAboutMesController : Controller
    {
        private DevPortfolioDP db = new DevPortfolioDP();

        // GET: PortAdmin/AdminAboutMes
        public ActionResult Index()
        {
            return View(db.AboutMes.ToList());
        }

        // GET: PortAdmin/AdminAboutMes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutMe aboutMe = db.AboutMes.Find(id);
            if (aboutMe == null)
            {
                return HttpNotFound();
            }
            return View(aboutMe);
        }

        // GET: PortAdmin/AdminAboutMes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortAdmin/AdminAboutMes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MeName,MeProfile,MeEmail,MePhone,MeAbout")] AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                db.AboutMes.Add(aboutMe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutMe);
        }

        // GET: PortAdmin/AdminAboutMes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutMe aboutMe = db.AboutMes.Find(id);
            if (aboutMe == null)
            {
                return HttpNotFound();
            }
            return View(aboutMe);
        }

        // POST: PortAdmin/AdminAboutMes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MeName,MeProfile,MeEmail,MePhone,MeAbout")] AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutMe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutMe);
        }

        // GET: PortAdmin/AdminAboutMes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutMe aboutMe = db.AboutMes.Find(id);
            if (aboutMe == null)
            {
                return HttpNotFound();
            }
            return View(aboutMe);
        }

        // POST: PortAdmin/AdminAboutMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutMe aboutMe = db.AboutMes.Find(id);
            db.AboutMes.Remove(aboutMe);
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
