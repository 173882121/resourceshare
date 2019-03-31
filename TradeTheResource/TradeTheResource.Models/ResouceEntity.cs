using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeTheResource.Models
{
    public class ResouceEntity
    {

        [Display(Name ="序号")]
        public int Id { get; set; }
        [Display(Name = "价格(元)")]
        public decimal Price { get; set; }
        [Display(Name = "网络地址")]
        public string Url { get; set; }
        public DateTime UploadTime { get; set; }
        [Display(Name = "付款次数")]
        public int PaymentTimes { get; set; }
        [Display(Name = "最后一次付款时间")]
        public DateTime? LastPayTime { get; set; }
        [Display(Name = "备注")]
        public string Comment { get; set; }
        [Display(Name = "组")]
        public int Group { get; set; }

        [Display(Name ="解压码")]
        public string UnpackCode { get; set; }

        [Display(Name ="用户Id")]
        public int UserId { get; set; }


    }
}
