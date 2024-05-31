using Dapper;
using Sells.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.DB
{
    public class PdctRptDb : BasicDb<PdctRpt, string>
    {
        public PdctRptDb(string _conn) : base(_conn)
        {
        }
        public List<PdctRpt> GetAllByDate(Searchkey key)
        {           
            DynamicParameters Dp = new DynamicParameters();
            Dp.Add("StartDay", key.StartDay);
            Dp.Add("EndDay", key.EndDay);
            string Sqlstr = $@"
             
                    SELECT  產品編號,光源 as 產品名稱,SUM(數量) as 數量,
        SUM(金額) as 單價 ,SUM(總金額) as 總金額
        FROM SellInProduct 
        where 銷貨日期>=@StartDay and 銷貨日期<=@EndDay         
        group by 產品編號,光源

                    ";
            var dbresult = ConectSQL(Sqlstr, Dp);
            return dbresult;
            //group by 產品編號,光源,總金額
        }
    }
}
//總金額
//產品編號
//光源   
//數量   
//金額   
