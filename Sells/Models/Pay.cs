using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.Models
{
    public class Pay
    {
        public string 客戶編號 { set; get; }
        public DateTime 銷貨日期 { set; get; }
        public int 金額 { set; get; }
        public bool 結清 { set; get; }
        public int 實收金額 { set; get; }
        public string 明細 { set; get; }
    }
}
