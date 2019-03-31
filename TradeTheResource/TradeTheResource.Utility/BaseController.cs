using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TradeTheResource.Web.Utility
{
    public class BaseController :Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] == null)
            {

                filterContext.Result = new RedirectResult("/Home/Index",true);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}