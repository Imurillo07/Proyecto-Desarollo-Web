using DW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DW.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class authorizedUser : AuthorizeAttribute
    {
        private usuario oUsuario;
        private DBEntities db = new DBEntities();
        private int permisos;

        public authorizedUser(int permisos = 0)
        {
            this.permisos = permisos;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String numPermiso = "";

            try
            {
                oUsuario = (usuario)HttpContext.Current.Session["Usuario"];
                var lstPermisos = from m in db.usuarios
                                  where m.permiso == permisos
                                  select m;

                if(lstPermisos.ToList().Count() == null) {

                }

            }
            catch(Exception ex)
            {

            }
        }

    }
}