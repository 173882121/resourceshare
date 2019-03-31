using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace TradeTheResource.Utility
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {

     
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index", true);
            }
          


            base.OnActionExecuting(filterContext);
        }

    }
}
