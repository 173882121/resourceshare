using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeTheResource.BLL;
using TradeTheResource.Models;
using TradeTheResource.Utility;

namespace TradeTheResource.Web.Controllers
{
    public class UserController : Controller
    {

        private ResouceEntityService resouceEntityService = new ResouceEntityService();

        private UserEntityService userEntityService = new UserEntityService();

        private OperateDetailService operateDetailService = new OperateDetailService();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 后台主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Manage()
        {

            return View();

        }

        /// <summary>
        /// 资源管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ResouseManager(int pageIndex=1)
        {
            int uid = 1;
            //ViewData.Model = resouceEntityService.GetAllResouce(uid);

           
            ViewBag.pageIndex = pageIndex;
            int pageSize = 5;
            ViewBag.pageSize = pageSize;
           
            ViewData.Model = resouceEntityService.GetPagelResouce(pageIndex,pageSize,out int total,uid);

            ViewBag.totalCount = total;//esouceEntityService.GetCount(uid);
            return PartialView("rmpp");
        }
        #region 资源管理

        [HttpGet]
        public ActionResult UploadResouse()
        {

            return PartialView("upResoucepp");




        }

        [HttpPost]
        public ActionResult UploadResouse(string price, string surl, string UnpackCode)
        {
            if (Request.IsAjaxRequest())
            {
                int uid = 1;
                //TODO:对提交上来的数据做处理，可用交到BLL层做处理
                if (resouceEntityService.Insert(price, surl, UnpackCode, uid))
                {
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }

            return Redirect("/User/Index");


        } 
        #endregion



        public ActionResult UserCenter(int id = 1)
        {
            ViewData.Model = userEntityService.GetUserById(id);


            return PartialView("ucpp");

        }

        #region 修改用户信息

        #endregion        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteResource(int id)
        {
            int uid = 1;
            if (resouceEntityService.DeleteResourceById(id, uid))
            {

                return Content("ok");
            }


            return Content("no");
        }

        
        /// <summary>
        /// 用户点击查看的时候，生成html页面
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public ActionResult Check(int sid)
        {
            //查看的时候可以先看之前后没有生成


            int uid = 1;
            ResouceEntity resouceEntity = resouceEntityService.GetResourceById(sid, uid);

            //做防盗链
            string resourceUrl = resouceEntity.Url;
            string ucode = resouceEntity.UnpackCode;
            decimal price = resouceEntity.Price;
            //查看的时候，生成支付的页面的html页面

            //这里的url为数据库中的url，用于记录用户从那里来，然后去找寻对应的数据
            string FromUrlStr = Guid.NewGuid().ToString("N");

            //IO操作的文件需要为全路径
            string payHtml = System.IO.File.ReadAllText(Request.MapPath("/HtmlFiles/HtmlTemp/PaymentTemp.html")).Replace("@resourceUrl", resourceUrl).Replace("@FromUrlStr", FromUrlStr);

            DateTime dateTime = DateTime.Now;
            //这里可以往下新建年月日的文件夹，这样搜索起来的压力小点
            string dir = string.Format("/HtmlFiles/HtmlResource/{0}-{1}-{2}", dateTime.Year, dateTime.Month.ToString("00"), dateTime.Day.ToString("00"));

            //如果不存在该文件夹则创建
            if (!Directory.Exists(dir))
            {
                //可以设置文件夹的访问权限
                Directory.CreateDirectory(Request.MapPath(dir));
            }

            //可以对文件名作加密处理
            string fileName = string.Format("{0}{1}{2}{3}{4}{5}.html", dateTime.Year, dateTime.Month.ToString("00"), dateTime.Day.ToString("00"), dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

            System.IO.File.WriteAllText(Request.MapPath(string.Format("/{0}/{1}",dir ,fileName)), payHtml);
            //把相关信息存入数据库

            OperateDetail operateDetail = new OperateDetail() {
                FromUrlStr= FromUrlStr,
                ToResourceUrl= resourceUrl,
                FileName=fileName,
                UserId=uid,
                UnpackCode= ucode,
                Price= price,
                Status=Status.NonPay

            };
            if (operateDetailService.Insert(operateDetail))
            {

                ViewData["FromUrlStr"] = FromUrlStr;
                return View();
            }

            else
            {
                return Content("查看失败");
            }

        }








        public ActionResult Login()
        {
            return View();
        }

    }
}