using System;
using System.Collections.Generic;
using System.Linq;
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
                                   where d.correo_personal == Correo.Trim() && d.clave == Pass.Trim()
                                   select d).FirstOrDefault();
                    if (oCorreo == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }

                    Session["Correo"] = oCorreo;

                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }




    }
}