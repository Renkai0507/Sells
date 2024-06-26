using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.Models
{
    public class SellInProduct
    {
        public string 銷貨單號 { set; get; }
        public DateTime 銷貨日期 { set; get; }
        public string 客戶編號 { set; get; }
        public string 客戶名稱 { set; get; }       
        public string 備註 { set; get; }
        public string 項次 { set; get; }
        public string 產品編號 { set; get; }
        public string 光源 { set; get; }
        public string 數量 { set; get; }        
        public string 水電價 { set; get; }
        public string 安裝價 { set; get; }
        public string 零售價 { set; get; }
        public string 單價 { set; get; }

        public string 金額 { set; get; }
        public string 牌價 { set; get; }
        public string 小計 { set; get; }
        public string 產品備註 { set; get; }
        public string 成本 { set; get; }
        public string 發票編號 { set; get; }
        
        public int 總金額 { get 
            {
                int result = 0;
                if (int.TryParse(金額, out result))
                {
                    return result;
                }
                return 0;
            } }

    }
    public enum 價格類別
    { 
        零售價,水電價,安裝價
    }
}
