using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeTheResource.Utility;

namespace TradeTheResource.Models
{
  public  class UserEntity
    {
        [Display(Name = "序号")]
        public int Id { get; set; }
        [Display(Name ="账号")]
        public string Account { get; set; }
        [Display(Name = "密码")]
        public string Password { get; set; }
        [Display(Name = "角色")]
        public Role Role { get; set; }
        [Display(Name = "用户名")]
        public string ShowName { get; set; }
        [Display(Name = "QQ")]
        public string QQ { get; set; }
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        [Display(Name ="手机号码")]
        public string Phone { get; set; }

        [Display(Name="余额")]
        public decimal Balance { get; set; }
        [Display(Name = "收款账户")]
        public string PaymentAccount { get; set; }

        [Display(Name = "收款方式")]
        public PaymentMethods PaymentMethods { get; set; }
    }
}
