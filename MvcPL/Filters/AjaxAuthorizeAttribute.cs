using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcPL.Filters
{
    public class AjaxAuthorizeAttribute:AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult{JsonRequestBehavior=JsonRequestBehavior.AllowGet, Data=new {redirectTo=FormsAuthentication.LoginUrl}}; 
            }
            else base.HandleUnauthorizedRequest(filterContext);
        }
    }
}