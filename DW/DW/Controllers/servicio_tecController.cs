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
        private DBEntities1 db = new DBEntities1();

        // GET: servicio_tec
        public ActionResult Index()
        {
            return View(db.servicio_tec.ToList());
        }

        public ActionResult vistaAdmin()
        {

            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.servicio_tec.ToList());
            }
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
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
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
        }

        // POST: servicio_tec/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo_sertec,descripcion_sertec,estado")] servicio_tec servicio_tec)
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(servicio_tec).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(servicio_tec);
            }
        }

        // GET: servicio_tec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
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
        }

        // POST: servicio_tec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                servicio_tec servicio_tec = db.servicio_tec.Find(id);
                db.servicio_tec.Remove(servicio_tec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
