using Dapper;

using Sells.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.DB
{
    public class PopularProductDb : BasicDb<PopularProduct, string>
    {
        public PopularProductDb(string _conn) : base(_conn)
        {
        }

        public List<PopularProduct> GetAll()
        {
            string Sqlstr = $@"SELECT * FROM PopularProduct";
            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
        public PopularProduct SinglebyKey(string searchKey)
        {
            DynamicParameters Dp = new DynamicParameters();
            Dp.Add("searchKey", searchKey);
            string Sqlstr = $@"SELECT top 1 * FROM PopularProduct where 產品編號 =@searchKey";
            var dbresult = ConectSQL(Sqlstr, Dp).FirstOrDefault(); 
            return dbresult;

        }
        public PopularProduct SinglebyName(string searchKey)
        {
            DynamicParameters Dp = new DynamicParameters();
            Dp.Add("searchKey", searchKey);
            string Sqlstr = $@"SELECT top 1 * FROM PopularProduct where 產品規格 =@searchKey";
            var dbresult = ConectSQL(Sqlstr, Dp).FirstOrDefault();
            return dbresult;
        }
        public List<PopularProduct> GetAllAuto()
        {
            
            string Sqlstr = $@"SELECT distinct 產品編號,產品規格 FROM PopularProduct";
            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
        public List<PopularProduct> LikeSearchAll(string Search)
        {

            string Sqlstr = $@"SELECT * FROM PopularProduct 
                            where  {ArrayToSqlStrs("產品規格",Global.StrToArray(Search))} or {ArrayToSqlStrs("備註", Global.StrToArray(Search))}
or {ArrayToSqlStrs("單位", Global.StrToArray(Search))} or {ArrayToSqlStrs("地址", Global.StrToArray(Search))}
"//--產品規格 like '%{Search}%' or 備註 like '%{Search}%'  or 地址 like '%{Search}%' 
;

            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
        public bool AddNew(PopularProduct entity)
        {
            string Sqlstr = $@"Insert into PopularProduct 
(產品編號,產品規格,單位,進價價錢,水電價,安裝價,零售價錢,備註,進貨日期,地址)
values ({entity.產品編號},{entity.產品規格},{entity.單位},{entity.進價價錢},{entity.水電價},{entity.安裝價}
,{entity.零售價錢},{entity.備註},{entity.進貨日期},{entity.地址})
";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult==1;
        }
        public bool Edit(PopularProduct entity)
        {
            string Sqlstr = $@"UPDATE PopularProduct Set 產品規格='{entity.產品規格}',單位='{entity.單位}',
                            進價價錢='{entity.進價價錢}',水電價='{entity.水電價}',安裝價='{entity.安裝價}'
,零售價錢='{entity.零售價錢}',備註='{entity.備註}',進貨日期='{entity.進貨日期.Year}/{entity.進貨日期.Month}/{entity.進貨日期.Day}',地址='{entity.地址}'
                            WHERE 產品編號='{entity.產品編號}'

";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }
        public bool Delete(PopularProduct entity)
        {
            string Sqlstr = $@"DELETE FROM PopularProduct
                            WHERE 產品編號={entity.產品編號}
";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }

        public DataTable TurnTable(List<PopularProduct> lst)
        {
            return ListConvertDataTable(lst);
        }

        internal List<PopularProduct> SearchAll(string Search)
        {
            string Sqlstr = $@"SELECT * FROM PopularProduct 
                            where  產品規格 Like '%{Search}%' or 備註 Like '%{Search}%'
or 單位 Like '%{Search}%' or 地址 Like '%{Search}%'
"//--產品規格 like '%{Search}%' or 備註 like '%{Search}%'  or 地址 like '%{Search}%' 
;

            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
    }
}
