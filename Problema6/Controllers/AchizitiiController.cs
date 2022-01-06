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
    public class AchizitiiController : Controller
    {
        private Gestiune_Telefoane db = new Gestiune_Telefoane();

        // GET: Achizitii
        public ActionResult Index()
        {

            var achizite = db.Achizite.Include(a => a.Client).Include(a => a.Telefon);

            return View(achizite.ToList());
        }

        // GET: Achizitii/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achizitie achizitie = db.Achizite.Find(id);
            if (achizitie == null)
            {
                return HttpNotFound();
            }
            return View(achizitie);
        }

        // GET: Achizitii/Create
        public ActionResult Create()
        {
            var telefoane = from c in db.Telefon select c;
            //preia doar inregistrarile care au un stoc >0
            ViewBag.ID_telefon = new SelectList(db.Telefon.Where(c => c.Stoc > 0), "ID_telefon", "Model");
            ViewBag.ID_client = new SelectList(db.Client, "ID_client", "Nume");

            return View();
        }

        // POST: Achizitii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_achizitie,ID_client,ID_telefon,DataAchizitie,Pret")] Achizitie achizitie)
        {
            if (ModelState.IsValid)
            {
                db.Achizite.Add(achizitie);

                //preia inregistrarea dupa ID-ul telefonului introdus
                var tel = db.Telefon.Find(achizitie.ID_telefon);
                if (tel != null)
                {
                    //modifica stocul
                    tel.Stoc += -1;
                }
                //salveaza modificarile facute
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_client = new SelectList(db.Client, "ID_client", "Nume", achizitie.ID_client);
            ViewBag.ID_telefon = new SelectList(db.Telefon, "ID_telefon", "Model", achizitie.ID_telefon);



            return View(achizitie);
        }

        // GET: Achizitii/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achizitie achizitie = db.Achizite.Find(id);
            if (achizitie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_client = new SelectList(db.Client, "ID_client", "Nume", achizitie.ID_client);
            ViewBag.ID_telefon = new SelectList(db.Telefon, "ID_telefon", "Model", achizitie.ID_telefon);
            return View(achizitie);
        }

        // POST: Achizitii/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_achizitie,ID_client,ID_telefon,DataAchizitie,Pret")] Achizitie achizitie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(achizitie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_client = new SelectList(db.Client, "ID_client", "Nume", achizitie.ID_client);
            ViewBag.ID_telefon = new SelectList(db.Telefon, "ID_telefon", "Model", achizitie.ID_telefon);
            return View(achizitie);
        }

        // GET: Achizitii/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achizitie achizitie = db.Achizite.Find(id);
            if (achizitie == null)
            {
                return HttpNotFound();
            }
            return View(achizitie);
        }

        // POST: Achizitii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Achizitie achizitie = db.Achizite.Find(id);
            db.Achizite.Remove(achizitie);
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
