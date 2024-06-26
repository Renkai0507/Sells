using Dapper;
using Sells.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.DB
{
    public class CustRptDb : BasicDb<CustRpt, string>
    {
        public CustRptDb(string _conn) : base(_conn)
        {
        }
        public List<CustRpt> GetAllByDate(Searchkey key)
        {
            DynamicParameters Dp = new DynamicParameters();
            Dp.Add("StartDay", key.StartDay);
            Dp.Add("EndDay", key.EndDay);
            string Sqlstr = $@"
               select 客戶編號,客戶名稱,總金額
FROM(
                    SELECT distinct 客戶編號,客戶名稱,總金額
        FROM SellInProduct 
        where 銷貨日期>=@StartDay and 銷貨日期<=@EndDay and 客戶名稱<>''        
    )AA

                    ";
            var dbresult = ConectSQL(Sqlstr, Dp);
            return dbresult;
            //group by 產品編號,光源,總金額
        }
        public List<CustRpt> SearchByDate(Searchkey key)
        {
            DynamicParameters Dp = new DynamicParameters();
            Dp.Add("StartDay", key.StartDay);
            Dp.Add("EndDay", key.EndDay);
            Dp.Add("SearchStr", key.SearchCust);
            string Sqlstr = $@"
               select 銷貨日期,銷貨單號,客戶編號,客戶名稱,總金額
FROM(
                    SELECT distinct 銷貨日期,銷貨單號,客戶編號,客戶名稱,總金額
        FROM SellInProduct 
        where 銷貨日期>=@StartDay and 銷貨日期<=@EndDay         
    )AA where 客戶名稱=@SearchStr

                    ";
            var dbresult = ConectSQL(Sqlstr, Dp);
            return dbresult;
            //group by 產品編號,光源,總金額
        }
    }
}
//客戶編號
//客戶名稱
//總金額  
