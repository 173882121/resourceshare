using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TradeTheResource.BLL;

namespace TradeTheResource.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        //protected static OperateDetailService operateEntityService { get; set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //operateEntityService = new OperateDetailService();

        }
        void Application_BeginRequest(object sender, EventArgs e)
        {


            //string url = Request.Url.ToString();

            //Models.OperateDetail operateDetail = operateEntityService.GetOperateDetailByUrlAndStatus(url, 1, TradeTheResource.Utility.Status.NonPay);


        }
    }
}
