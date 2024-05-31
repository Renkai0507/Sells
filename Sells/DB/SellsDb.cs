using Dapper;
using Sells.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.DB
{
    public class SellsDb : BasicDb<SellInProduct, string>
    {
        public SellsDb(string _conn) : base(_conn)
        {
        }
        public List<SellInProduct> GetAll()
        {
            string Sqlstr = $@"SELECT * FROM SellInProduct";
            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
        public List<SellInProduct> GetAllByDate(DateTime date)
        {
            string DateStr = $@"{date.Year}/{date.Month}";
            int Length = DateStr.Length;
            DynamicParameters Dp = new DynamicParameters();
            Dp.Add("DateStr" , DateStr);
            string Sqlstr = $@"SELECT distinct 銷貨單號,銷貨日期,客戶名稱 FROM SellInProduct where LEFT(銷貨日期,{Length})=@DateStr";
            var dbresult = ConectSQL(Sqlstr, Dp);
            return dbresult;
        }
        


        internal List<SellInProduct> GetAllBySearch(DateTime date, string Cus,string Pdct)
        {
            string DateStr = $@"{date.Year}/{date.Month}";
            DynamicParameters Dp = new DynamicParameters();
            string CusStr = string.IsNullOrWhiteSpace(Cus) ?"": $"and ({ArrayToSqlStrs("客戶名稱", Global.StrToArray(Cus))})";
            string PdctStr = string.IsNullOrWhiteSpace(Pdct) ?"": $"and ({ArrayToSqlStrs("光源", Global.StrToArray(Pdct))})";
            
            string Sqlstr = $@"SELECT distinct 銷貨單號,銷貨日期,客戶名稱 FROM SellInProduct where LEFT(銷貨日期,7)=@DateStr
                             {CusStr} {PdctStr}";
            Dp.Add("DateStr", DateStr);
            var dbresult = ConectSQL(Sqlstr, Dp);
            return dbresult;
        }
        internal List<SellInProduct> GetPdcByKey(string 銷貨單號)
        {
            DynamicParameters Dp = new DynamicParameters();
            string Sqlstr = $@"SELECT * from SellInProduct where 銷貨單號 = @DateStr";

            Dp.Add("DateStr", 銷貨單號);
            var dbresult = ConectSQL(Sqlstr, Dp);
            return dbresult;

        }

       

        public bool AddNew(SellInProduct entity)
        {
            string SnNo = GetSnno(entity);
            string DateStr = $@"{entity.銷貨日期.Year}/{entity.銷貨日期.Month}/{entity.銷貨日期.Day}";
            string Sqlstr = $@"Insert into SellInProduct 
(銷貨單號,項次,銷貨日期,客戶編號,客戶名稱,總金額,備註,產品編號,光源,數量,水電價,安裝價,零售價,金額,牌價,小計,產品備註,成本,發票編號)
values ('{entity.銷貨單號}',{SnNo},'{DateStr}','{entity.客戶編號}','{entity.客戶名稱}','{entity.總金額}','{entity.備註}'
,'{entity.產品編號}','{entity.光源}','{entity.數量}','{entity.水電價}','{entity.安裝價}',
'{entity.零售價}','{entity.金額}','{entity.牌價}','{entity.小計}','{entity.產品備註}','{entity.成本}','{entity.發票編號}')
";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }

        public string GetSnno(SellInProduct entity)
        {
            string Sqlstr = $@"SELECT  銷貨單號 FROM SellInProduct WHERE 銷貨單號='{entity.銷貨單號}' ";
            var sli = ConectSQL(Sqlstr, entity);
            if (sli==null)
            {
                return "1";
            }
            return ( sli.Count + 1).ToString();
        }
        public string GetByKey(SellInProduct entity)
        {
            string Sqlstr = $@"SELECT  銷貨單號,項次 FROM SellInProduct WHERE 銷貨單號='{entity.銷貨單號}' and 項次='{entity.項次}' ";
            var sli = ConectSQL(Sqlstr, entity);
            if (sli == null)
            {
                return "0";
            }
            return (sli.FirstOrDefault().項次 ).ToString();
        }

        public bool Edit(SellInProduct entity)
        {
            
            string DateStr = $@"{entity.銷貨日期.Year}/{entity.銷貨日期.Month}/{entity.銷貨日期.Day}";
            string Sqlstr = $@"UPDATE SellInProduct Set 銷貨日期='{DateStr}',
                            客戶編號='{entity.客戶編號}',客戶名稱='{entity.客戶名稱}',總金額='{entity.總金額}',備註='{entity.備註}',產品編號='{entity.產品編號}',光源='{entity.光源}',數量='{entity.數量}',
                            水電價='{entity.水電價}',安裝價='{entity.安裝價}',零售價='{entity.零售價}',金額='{entity.金額}',小計='{entity.小計}'
                            ,產品備註='{entity.產品備註}',成本='{entity.成本}',發票編號='{entity.發票編號}'
WHERE 銷貨單號='{entity.銷貨單號}' and 項次='{entity.項次}'";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }
        public bool Delete(SellInProduct entity)
        {
            string Sqlstr = $@"DELETE FROM SellInProduct
                            WHERE 銷貨單號=@銷貨單號 and 項次=@項次
";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }
        

        internal List<SellInProduct> GetPdcfortxt(string 銷貨單號)
        {
            DynamicParameters Dp = new DynamicParameters();
            if (string.IsNullOrWhiteSpace(銷貨單號))
            {
                return null;
            }
            
            string Sqlstr = $@"SELECT top 10 distinct  產品規格 PopularProduct where 產品規格 like @DateStr%";
                             
            Dp.Add("DateStr", 銷貨單號);
            var dbresult = ConectSQL(Sqlstr, Dp);
            return dbresult;
        }

        internal void SetTotal(string snNo, string result)
        {
           
            string Sqlstr = $@"UPDATE SellInProduct Set 總金額='{result}'
WHERE 銷貨單號='{snNo}'";
            int dbresult = ExecSQL(Sqlstr);
           
        }
    }
}
