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
        private DBEntities2 db = new DBEntities2();

        // GET: productos
        public ActionResult Index()
        {
            return View(db.productoes.ToList());
        }
        public ActionResult vistaAdmin()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.productoes.ToList());
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
                return View(db.productoes.ToList());
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
                return View(db.productoes.ToList());
            }
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.productoes.Find(id);
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
                return Redirect(Url.Content("~/usuarios/Create"));
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
            try
            {

                if (Session["admin"] == null && Session["user"] == null)
                {
                    return Redirect(Url.Content("~/usuarios/Create"));
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.productoes.Add(producto);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(producto);
                }
            }catch (Exception ex)
            {
                return RedirectToAction("Error", "productos");

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
                producto producto = db.productoes.Find(id);
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
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", "productos");

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
                producto producto = db.productoes.Find(id);
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
                producto producto = db.productoes.Find(id);
                db.productoes.Remove(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Error()
        {
            return View();
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
