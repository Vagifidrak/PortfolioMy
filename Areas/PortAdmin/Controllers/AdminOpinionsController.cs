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
    public class AdminOpinionsController : Controller
    {
        private DevPortfolioDP db = new DevPortfolioDP();

        // GET: PortAdmin/AdminOpinions
        public ActionResult Index()
        {
            return View(db.Opinions.ToList());
        }

        // GET: PortAdmin/AdminOpinions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinion opinion = db.Opinions.Find(id);
            if (opinion == null)
            {
                return HttpNotFound();
            }
            return View(opinion);
        }

        // GET: PortAdmin/AdminOpinions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortAdmin/AdminOpinions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Opinionİmg,OpinionName,OpinionDescription")] Opinion opinion, HttpPostedFileBase OpinionUa)
        {
            if (ModelState.IsValid)
            {
                if (OpinionUa != null)
                {
                    if(OpinionUa != null){
                        if (OpinionUa.ContentLength > 0)
                        {
                            if(OpinionUa.ContentType.ToLower() == "image/jpg" ||
                             OpinionUa.ContentType.ToLower() == "image/png" ||
                             OpinionUa.ContentType.ToLower() == "image/gif" ||
                             OpinionUa.ContentType.ToLower() == "image/bmp" ||
                             OpinionUa.ContentType.ToLower() == "image/jpeg")
                            {
                                WebImage img = new WebImage(OpinionUa.InputStream);
                                FileInfo flinfo = new FileInfo(OpinionUa.FileName);
                                string filename = "Opinion" + Guid.NewGuid() + flinfo.Extension;
                                img.Save("~/Upload/Opinion/" + filename);
                                opinion.Opinionİmg="/Upload/Opinion/"+filename;
                            }
                        }
                    }
                }
                db.Opinions.Add(opinion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opinion);
        }

        // GET: PortAdmin/AdminOpinions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinion opinion = db.Opinions.Find(id);
            if (opinion == null)
            {
                return HttpNotFound();
            }
            return View(opinion);
        }

        // POST: PortAdmin/AdminOpinions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Opinionİmg,OpinionName,OpinionDescription")] Opinion opinion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opinion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opinion);
        }

        // GET: PortAdmin/AdminOpinions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinion opinion = db.Opinions.Find(id);
            if (opinion == null)
            {
                return HttpNotFound();
            }
            return View(opinion);
        }

        // POST: PortAdmin/AdminOpinions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opinion opinion = db.Opinions.Find(id);
            db.Opinions.Remove(opinion);
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
