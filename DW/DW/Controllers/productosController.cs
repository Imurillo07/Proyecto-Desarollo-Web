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
    public class productosController : Controller
    {
        private DBEntities1 db = new DBEntities1();

        // GET: productos
        public ActionResult Index()
        {
            return View(db.producto.ToList());
        }
        public ActionResult vistaAdmin()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.producto.ToList());
            }
        }

        public ActionResult Aprobar()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.producto.ToList());
            }
        }

        public ActionResult Denegado()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.producto.ToList());
            }
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: productos/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null && Session["user"] == null) 
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View();
            }
        }

        // POST: productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre_prod,estado,descripcion_prod,telefono_prod,correo_personal_prod,imagen")] producto producto)
        {

            if (Session["admin"] == null && Session["user"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.producto.Add(producto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(producto);
            }
        }

        // GET: productos/Edit/5
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
                producto producto = db.producto.Find(id);
                if (producto == null)
                {
                    return HttpNotFound();
                }
                return View(producto);
            }
        }

        // POST: productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre_prod,estado,descripcion_prod,telefono_prod,correo_personal_prod,imagen")] producto producto)
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(producto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(producto);
            }
        }

        // GET: productos/Delete/5
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
                producto producto = db.producto.Find(id);
                if (producto == null)
                {
                    return HttpNotFound();
                }
                return View(producto);
            }
        }

        // POST: productos/Delete/5
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
                producto producto = db.producto.Find(id);
                db.producto.Remove(producto);
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
