using DW.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace DW.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Correo, string Pass)
        {
            try
            {
                using (Models.DBEntities db = new Models.DBEntities())
                {
                    var oCorreo = (from d in db.usuarios
                                   where d.correo_personal == Correo && d.clave == Pass
                                   select d).FirstOrDefault();

                    if (oCorreo.permiso == 3)
                    {
                        Session["admin"] = oCorreo;
                        return RedirectToAction("Index", "Home");

                    }

                    if (oCorreo.permiso == 2)
                    {
                        return Content("Cuenta desactivada, contactar servicio tecnico");
                    }

                    if (oCorreo.permiso == 1)
                    {
                        Session["user"] = oCorreo;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Content("Usuario o contraseña incorrecta, intente de nuevo");
                    }

                }


            }
            catch (Exception ex)
            {
                return Content("error encontrado: " + ex.ToString());
            }
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            Session["user"] = null;
            return View();
        }
    }
}