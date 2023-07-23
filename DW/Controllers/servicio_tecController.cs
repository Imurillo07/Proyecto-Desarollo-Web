using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DW.Models;

namespace DW.Controllers
{
    public class servicio_tecController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: servicio_tec
        public ActionResult Index()
        {
            return View(db.servicio_tec.ToList());
        }

        // GET: servicio_tec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_tec servicio_tec = db.servicio_tec.Find(id);
            if (servicio_tec == null)
            {
                return HttpNotFound();
            }
            return View(servicio_tec);
        }

        // GET: servicio_tec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: servicio_tec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titulo_sertec,descripcion_sertec,estado")] servicio_tec servicio_tec)
        {
            if (ModelState.IsValid)
            {
                db.servicio_tec.Add(servicio_tec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicio_tec);
        }

        // GET: servicio_tec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_tec servicio_tec = db.servicio_tec.Find(id);
            if (servicio_tec == null)
            {
                return HttpNotFound();
            }
            return View(servicio_tec);
        }

        // POST: servicio_tec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo_sertec,descripcion_sertec,estado")] servicio_tec servicio_tec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio_tec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicio_tec);
        }

        // GET: servicio_tec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio_tec servicio_tec = db.servicio_tec.Find(id);
            if (servicio_tec == null)
            {
                return HttpNotFound();
            }
            return View(servicio_tec);
        }

        // POST: servicio_tec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicio_tec servicio_tec = db.servicio_tec.Find(id);
            db.servicio_tec.Remove(servicio_tec);
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
