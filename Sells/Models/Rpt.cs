using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.Models
{
    public class PdctRpt
    {
        public string 總金額   { set; get; }
        public string 產品編號 { set; get; }
        public string 產品名稱 { set; get; }       
        public string 數量     { set; get; }     
        public string 單價    { set; get; }
      
    }
    public class CustRpt
    {
        public string 客戶編號 { set; get; }
        public string 客戶名稱 { set; get; }
        public string 總金額   { set; get; }
    }
}
