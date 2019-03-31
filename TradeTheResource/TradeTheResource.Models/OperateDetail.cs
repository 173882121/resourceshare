using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeTheResource.Utility;

namespace TradeTheResource.Models
{
    public class OperateDetail
    {

        public int Id { get; set; }
        public string FromUrlStr { get; set; }
        public string ToResourceUrl { get; set; }
        public string FileName { get; set; }

        public int UserId { get; set; }
        public string UnpackCode { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }


    }
}
