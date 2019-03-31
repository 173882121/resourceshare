using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Aop.Api.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeTheResource.Utility
{
    public static class AlipayHelper
    {

        /// <summary>
        /// 生成支付的二维码
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static string CreateAlipayQRCode(string host,decimal price)
        {
            DefaultAopClient client = new DefaultAopClient(AlipayConfig.gatewayUrl, AlipayConfig.app_id, AlipayConfig.private_key, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipay_public_key, AlipayConfig.charset, false);
            //外部订单号
            string out_trade_no = Guid.NewGuid().ToString("N");
            //订单名称
            const string subject = "描述订单";
            //付款金额
             string total_amout = price.ToString();
            //商品描述
            string body = "支付金额";
            //支付中途退出返回商户网站地址
            const string quit_url = "http://www.lilysunshine.top/Home/QuitPage";

            //组装业务参数model
            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel()
            {
                Body = body,
                Subject = subject,
                TotalAmount = total_amout,
                OutTradeNo = out_trade_no,
                ProductCode = "FAST_INSTANT_TRADE_PAY",
                QuitUrl = quit_url
            };
            //支付完成同步回调地址
            string returnUrl = host + "/Home/ReturnUrl";
            //支付完成异步通知接收网址
            string notifyUrl = host + "/Home/NotifyUrl"; ;

            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();//手机网页端  调用手机安卓支付宝app付款
            // AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();//电脑网页端 扫二维码付款
            request.SetReturnUrl(returnUrl);
            request.SetNotifyUrl(notifyUrl);

            //将业务model载入到request中
            request.SetBizModel(model);


            AlipayTradeWapPayResponse response = null;
            //AlipayTradePagePayResponse response = null;
            try
            {
                response = client.pageExecute(request, null, "post");
                string result = response.Body;
                return result;
            }

            catch (Exception exp)
            {

                throw exp;
            }

        }

        /// <summary>
        /// 支付完成异步通知地址
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRequestPost(NameValueCollection coll)
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();


            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], coll[requestItem[i]]);
            }

            
            return sArray;
        }

        /// <summary>
        /// 支付完成同步回调地址
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRequestGet(NameValueCollection coll)
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();

            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], coll[requestItem[i]]);
            }
            return sArray;

        }


        public static bool RSACheckV1(Dictionary<string, string> sArray)
        {
            bool flag = AlipaySignature.RSACheckV1(sArray, AlipayConfig.alipay_public_key, AlipayConfig.charset, AlipayConfig.sign_type, false);
            return flag;

        }
    }
}
