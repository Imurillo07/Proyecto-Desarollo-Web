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
    public class preguntasController : Controller
    {
        private DBEntities1 db = new DBEntities1();

        // GET: preguntas
        public ActionResult Index()
        {
            return View(db.pregunta.ToList());
        }

        // GET: preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.pregunta.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // GET: preguntas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: preguntas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titulo_pregunta,descripcion_pregunta,correo_personal_pregunta")] pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.pregunta.Add(pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pregunta);
        }

        // GET: preguntas/Edit/5
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
                pregunta pregunta = db.pregunta.Find(id);
                if (pregunta == null)
                {
                    return HttpNotFound();
                }
                return View(pregunta);
            }
        }

        // POST: preguntas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo_pregunta,descripcion_pregunta,correo_personal_pregunta")] pregunta pregunta)
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pregunta).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(pregunta);
            }
        }

        // GET: preguntas/Delete/5
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
                pregunta pregunta = db.pregunta.Find(id);
                if (pregunta == null)
                {
                    return HttpNotFound();
                }
                return View(pregunta);
            }
        }

        // POST: preguntas/Delete/5
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
                pregunta pregunta = db.pregunta.Find(id);
                db.pregunta.Remove(pregunta);
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
