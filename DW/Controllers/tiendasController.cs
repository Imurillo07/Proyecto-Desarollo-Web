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
    public class tiendasController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: tiendas
        public ActionResult Index()
        {
            return View(db.tiendas.ToList());
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
            return View();
        }

        // POST: tiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre_tienda,descripcion_tienda,telefono_tienda,imagen_tienda,correo_tienda,imagen")] tienda tienda)
        {
            if (ModelState.IsValid)
            {
                db.tiendas.Add(tienda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tienda);
        }

        // GET: tiendas/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: tiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre_tienda,descripcion_tienda,telefono_tienda,imagen_tienda,correo_tienda,imagen")] tienda tienda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tienda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tienda);
        }

        // GET: tiendas/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tienda tienda = db.tiendas.Find(id);
            db.tiendas.Remove(tienda);
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