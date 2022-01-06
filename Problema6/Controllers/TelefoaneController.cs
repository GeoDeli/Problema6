using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Problema6.Models;

namespace Problema6.Controllers
{
    public class TelefoaneController : Controller
    {
        private Gestiune_Telefoane db = new Gestiune_Telefoane();

        // GET: Telefoane
        public ActionResult Index(string model)
        {

            var telefoane = from c in db.Telefon select c;
            if (!String.IsNullOrEmpty(model))
            {
                telefoane = telefoane.Where(c => c.Model.Contains(model));
            }

            return View(telefoane);

            // return View(db.Telefon.ToList());
        }

        // GET: Telefoane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefon telefon = db.Telefon.Find(id);
            if (telefon == null)
            {
                return HttpNotFound();
            }
            return View(telefon);
        }

        // GET: Telefoane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Telefoane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_telefon,Model,An,Specificatii,Pret,Stoc")] Telefon telefon)
        {
            if (ModelState.IsValid)
            {
                db.Telefon.Add(telefon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telefon);
        }

        // GET: Telefoane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefon telefon = db.Telefon.Find(id);
            if (telefon == null)
            {
                return HttpNotFound();
            }
            return View(telefon);
        }

        // POST: Telefoane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_telefon,Model,An,Specificatii,Pret,Stoc")] Telefon telefon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefon);
        }

        // GET: Telefoane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefon telefon = db.Telefon.Find(id);
            if (telefon == null)
            {
                return HttpNotFound();
            }
            return View(telefon);
        }

        // POST: Telefoane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefon telefon = db.Telefon.Find(id);
            db.Telefon.Remove(telefon);
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
