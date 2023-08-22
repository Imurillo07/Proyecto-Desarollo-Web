using DW.Controllers;
using DW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DW.Filters
{
    public class AccessFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = (usuarios)HttpContext.Current.Session["admin"];





            if (session == null)
            {

                if (filterContext.Controller is usuarios == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/");
                }


            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/usuarios/");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}