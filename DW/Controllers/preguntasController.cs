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
    public class preguntasController : Controller
    {
        private DBEntities2 db = new DBEntities2();

        // GET: preguntas
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return Redirect(Url.Content("~/Home/Index"));
            }
            else
            {
                return View(db.preguntas.ToList());
            }
        }

        // GET: preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.preguntas.Find(id);
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
            try
            {
                if (ModelState.IsValid)
                {
                    db.preguntas.Add(pregunta);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch (Exception ex)
            {
                return RedirectToAction("Error", "preguntas");
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
                pregunta pregunta = db.preguntas.Find(id);
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
                        db.Entry(pregunta).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(pregunta);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "productos");

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
                pregunta pregunta = db.preguntas.Find(id);
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
                pregunta pregunta = db.preguntas.Find(id);
                db.preguntas.Remove(pregunta);
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
