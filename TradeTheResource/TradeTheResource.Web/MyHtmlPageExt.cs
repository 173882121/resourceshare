using System;
using System.Text;
using System.Web.Mvc;

//using System.Web.Mvc;

namespace TradeTheResource.Web
{
    public static class MyHtmlPageExt
    {
        public static MvcHtmlString ShowPageNavigate(/*this HtmlHelper htmlHelper,*/ int pageIndex, int pageSize, int totalCount)
        {


            StringBuilder sb = new StringBuilder();

            //1.计算总页数
            int totalPages = Math.Max(Convert.ToInt32(Math.Ceiling(totalCount * 1.0 / pageSize)), 1);

            //显示的页数为当前的前5和后5,共11个页数

            //处理首页
            sb.AppendFormat("<a href={0}?pageIndex=1>首页</a>",string.Empty);
            sb.Append("   ");

            //处理上一页
            if (pageIndex == 1)
            {
                sb.Append("<span disabled='disabled'>上一页</span>");
            }
            else if (pageIndex > 1)
            {
                sb.AppendFormat("<a href={0}?pageIndex={1}>上一页</a>", string.Empty, pageIndex - 1);

            }
            sb.Append(" ");
            int currint = 5;
            for (int i = 0; i <= 10; i++)
            {
                //页码必须在1到最大页面的范围之内
                if ((pageIndex - currint + i >= 1) && (pageIndex - currint + i <= totalPages))
                {
                    //当前页
                    if (pageIndex - currint + i == pageIndex)
                    {
                        //给当前页加class类样式，以示和其他页的不同
                        sb.AppendFormat("<a class='cpb' href={0}?pageIndex={1}>{1}</a>", string.Empty, pageIndex);
                    }
                    else//其他页
                    {
                        sb.AppendFormat("<a href={0}?pageIndex={1}>{1}</a>", string.Empty, pageIndex - currint + i);
                    }

                }

                sb.Append("   ");
            }




            sb.Append(" ");

            //处理下一页
            if (pageIndex == totalPages)
            {
                sb.Append("<span disabled='disabled'>下一页</span>");
            }
            else if (pageIndex < totalPages)
            {
                sb.AppendFormat("<a href={0}?pageIndex={1}>下一页</a>", string.Empty, totalPages + 1);

            }

            sb.Append(" ");

            //处理尾页  a标签href为空，默认跳转/请求到本页面
            sb.AppendFormat("<a href={0}?pageIndex={1}>尾页</a>", string.Empty, totalPages);

            //添加总页数
            sb.AppendFormat("当前第{0}页/共{1}页", pageIndex, totalPages);

            return  new MvcHtmlString(sb.ToString());

        }
        }
    }



