using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TradeTheResource.Models;

namespace TradeTheResource.Web
{
    public class BaseController :Controller
    {
        public UserEntity userEntity { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index", true);
                return;
            }
            else

            {
                userEntity = filterContext.HttpContext.Session["user"] as UserEntity;

            }

            base.OnActionExecuting(filterContext);
        }
    }
}