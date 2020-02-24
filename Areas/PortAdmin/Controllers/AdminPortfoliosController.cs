using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Areas.PortAdmin.Controllers
{
    public class AdminPortfoliosController : Controller
    {
        private DevPortfolioDP db = new DevPortfolioDP();

        // GET: PortAdmin/AdminPortfolios
        public ActionResult Index()
        {
            return View(db.Portfolios.ToList());
        }

        // GET: PortAdmin/AdminPortfolios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // GET: PortAdmin/AdminPortfolios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortAdmin/AdminPortfolios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Portİmg,Portİnfo,PortCategory")] Portfolio portfolio, HttpPostedFileBase PortFil)
        {
            if (ModelState.IsValid)
            {
                if (PortFil != null)
                {
                    if (PortFil != null)
                    {
                        if (PortFil.ContentLength > 0)
                        {
                            if
                            (PortFil.ContentType.ToLower() == "image/jpg" ||
                             PortFil.ContentType.ToLower() == "image/png" ||
                             PortFil.ContentType.ToLower() == "image/gif" ||
                             PortFil.ContentType.ToLower() == "image/bmp" ||
                             PortFil.ContentType.ToLower() == "image/jpeg")
                            {
                                WebImage img = new WebImage(PortFil.InputStream);
                                FileInfo flInfo = new FileInfo(PortFil.FileName);
                                string filename = "portfolio" + Guid.NewGuid() + flInfo.Extension;
                                img.Save("~/Upload/Portfolio/" + filename);
                                portfolio.PortDate = DateTime.Now;
                                portfolio.Portİmg = "/Upload/Portfolio/" + filename;
                            }
                        }
                    }
                }
                db.Portfolios.Add(portfolio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }

        // GET: PortAdmin/AdminPortfolios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // POST: PortAdmin/AdminPortfolios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Portİmg,Portİnfo,PortCategory,PortDate")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        // GET: PortAdmin/AdminPortfolios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // POST: PortAdmin/AdminPortfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
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
