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
    public class tiendasController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: tiendas
        public ActionResult Index()
        {
            return View(db.tiendas.ToList());
        }

        public ActionResult Aprobar()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.tiendas.ToList());
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
                return View(db.tiendas.ToList());
            }
        }

        public ActionResult vistaAdmin()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.tiendas.ToList());
            }
        }

        // GET: tiendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tienda tienda = db.tiendas.Find(id);
            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        // GET: tiendas/Create
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

        // POST: tiendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre_tienda,estado,descripcion_tienda,telefono_tienda,imagen_tienda,correo_tienda")] tienda tienda)
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
                        db.tiendas.Add(tienda);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "tiendas");

            }

            return View(tienda);
        }

        // GET: tiendas/Edit/5
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
                tienda tienda = db.tiendas.Find(id);
                if (tienda == null)
                {
                    return HttpNotFound();
                }
                return View(tienda);
            }
        }

        // POST: tiendas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre_tienda,estado,descripcion_tienda,telefono_tienda,imagen_tienda,correo_tienda")] tienda tienda)
        {
            try
            {
                if (Session["admin"] == null)
                {
                    return Redirect(Url.Content("~/Home/Index"));
                }
                else
                {
                    if (Session["admin"] == null)
                    {
                        return Redirect(Url.Content("~/Home/Index"));
                    }
                    else
                    {
                        if (ModelState.IsValid)
                        {
                            db.Entry(tienda).State = EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        return View(tienda);
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "tiendas");

            }
        }
         
        

        // GET: tiendas/Delete/5
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
                tienda tienda = db.tiendas.Find(id);
                if (tienda == null)
                {
                    return HttpNotFound();
                }
                return View(tienda);
            }
        }

        // POST: tiendas/Delete/5
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
                tienda tienda = db.tiendas.Find(id);
                db.tiendas.Remove(tienda);
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
