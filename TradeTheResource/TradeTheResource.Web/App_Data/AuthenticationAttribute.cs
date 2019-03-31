using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TradeTheResource.Models;


namespace TradeTheResource.Web
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {

       public UserEntity userEntity { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
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
