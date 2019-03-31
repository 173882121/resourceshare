using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeTheResource.Utility;
using TradeTheResource.BLL;
using TradeTheResource.Models;

namespace TradeTheResource.Web.Controllers
{
    public class HomeController : Controller
    {

        private ResouceEntityService resouceEntityService = new ResouceEntityService();

        private OperateDetailService operateDetailService = new OperateDetailService();

        private UserEntityService userEntityService = new UserEntityService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        /// <summary>
        /// 静态页面跳转到这里
        /// </summary>
        /// <param name="fuStr"></param>
        /// <param name="rUrl"></param>
        /// <returns></returns>
        public ActionResult Payment(string fuStr, string rUrl)
        {
            //这里的url为数据库中的url，用于记录用户从那里来，然后去找寻对应的数据
            //根据传递过来的url，找到资源实体记录，获取相关信息

            int uid = 1;
            OperateDetail operateDetail = operateDetailService.GetOperateDetailByFromUrlStrAndStatus(fuStr, uid, Status.NonPay);

            string host = Request.Url.Authority;

            //请求支付二维码  填充到网页中
            //string qrcode = AlipayHelper.CreateAlipayQRCode(host);


            Response.ContentType = "text/html";
            Response.Charset = "utf8";

            ViewBag.FromUrlstr = fuStr;
            ViewBag.ToResourceUrl = rUrl;

            return View();

        }



        public ActionResult Paid(string fuStr, string rUrl)
        {

            int uid = 1;



            OperateDetail operateDetail = operateDetailService.GetOperateDetailByFromUrlStrAndStatus(fuStr, uid, Status.NonPay);

            if (operateDetail == null)
            {

                return Content("资源失效，请重新申请html文件，支付后获取解压码。");

            }
            else
            {


            //更新操作表
            operateDetailService.Update(operateDetail.Id, Status.Paid);
            

            //更新资源表

            resouceEntityService.Update(rUrl, operateDetail.UserId, operateDetail.UnpackCode);

            //更新用户表
            userEntityService.Update(uid, operateDetail.Price);

            return Content(operateDetail.UnpackCode);
            //return Content("支付未完成");

            }

        }


        /// <summary>
        /// 用户下载html的请求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Download(string id)
        {
            //由于路由配置的原因，这里用id代替fromUrlStr变量

            string fromUrlStr = id;

            //需要设置客户端的保存名，不然会呈文本展示，而不是下载文件。


            int uid = 1;

            OperateDetail operateDetail = operateDetailService.GetOperateDetailByFromUrlStrAndStatus(fromUrlStr, uid, Status.NonPay);

            string dir = operateDetail.FileName.Substring(0, 8).Insert(6, "-").Insert(4, "-");



            return File(string.Format("/HtmlFiles/HtmlResource/{0}/{1}", dir, operateDetail.FileName), "text/plain", "1.html");


        }
    }
}