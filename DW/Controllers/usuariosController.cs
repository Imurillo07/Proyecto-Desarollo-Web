﻿using System;
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
    public class usuariosController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: usuarios
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.usuarios.ToList());
            }
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            try
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
                    usuario usuario = db.usuarios.Find(id);
                    if (usuario == null)
                    {
                        return HttpNotFound();
                    }
                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "usuarios");

            }
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            if (Session["admin"] == null && Session["user"] == null)
            {
                return View();
            }
            else
            {
                return Redirect(Url.Content("~/Home/Index"));
            }

        }

            // POST: usuarios/Create

            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellido,correo_personal,clave,permiso")] usuario usuario)
        {
            try { 
                if (Session["admin"] == null && Session["user"] == null)
                {
                    if (ModelState.IsValid)
                    {
                        db.usuarios.Add(usuario);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(usuario);

                }
                else
                {
                    return Redirect(Url.Content("~/Home/Index"));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "usuarios");

            }


        }

        // GET: usuarios/Edit/5
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
                usuario usuario = db.usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
        }

            // POST: usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellido,correo_personal,clave,permiso")] usuario usuario)
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
                        db.Entry(usuario).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "servicio_tec");

            }
        }

        // GET: usuarios/Delete/5
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
                usuario usuario = db.usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
        }

        // POST: usuarios/Delete/5
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
                usuario usuario = db.usuarios.Find(id);
                db.usuarios.Remove(usuario);
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
