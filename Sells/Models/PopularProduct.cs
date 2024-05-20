using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.Models
{
    public  class PopularProduct
    {
        public string 產品編號 { set; get; }
        public string 產品規格 { set; get; }
        public string 單位 { set; get; }
        public string 進價價錢 { set; get; }
        public string 水電價 { set; get; }
        public string 安裝價 { set; get; }
        public string 零售價錢 { set; get; }
        public string 備註 { set; get; }
        public DateTime 進貨日期 { set; get; }
        public string 地址 { set; get; }
    }
}
