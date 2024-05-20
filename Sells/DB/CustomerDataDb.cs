using Dapper;
using Sells.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.DB
{
    public class CustomerDataDb : BasicDb<CustomerData, string>
    {
        public CustomerDataDb(string _conn) : base(_conn)
        {
        }
        public List<CustomerData> GetAll()
        {

            string Sqlstr = $@"SELECT * FROM CustomerData";
            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
        public List<CustomerData> GetAllAuto()
        {

            string Sqlstr = $@"SELECT distinct 客戶編號,客戶名稱 FROM CustomerData";
            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
        public List<CustomerData> SearchAll(string Search)
        {

            string Sqlstr = $@"SELECT * FROM CustomerData 
                            where  {ArrayToSqlStrs("客戶名稱", Global.StrToArray(Search))} or {ArrayToSqlStrs("備註", Global.StrToArray(Search))}
                            or {ArrayToSqlStrs("業務", Global.StrToArray(Search))} or {ArrayToSqlStrs("聯絡人", Global.StrToArray(Search))}
                            or {ArrayToSqlStrs("地址", Global.StrToArray(Search))}
                ";

            var dbresult = ConectSQL(Sqlstr);
            return dbresult;
        }
        public bool AddNew(CustomerData entity)
        {
            //            string Sqlstr = $@"Insert into CustomerData 
            //       ( email, 客戶編號, 客戶名稱, 公司電話, 電話, 手機號碼, 公司傳真, 地址, 送貨地址, 統一編號, 備註, 發票抬頭, 聯絡人, 月結日期, 業務, 屬性)
            //values (@email,@客戶編號,@客戶名稱,@公司電話,@電話,@手機號碼,@公司傳真,@地址,@送貨地址,@統一編號,@備註,@發票抬頭,@聯絡人,@月結日期,@業務,@屬性)
            //";
            string Sqlstr = $@"Insert into CustomerData 
       ( 客戶編號, 客戶名稱, 公司電話, 電話, 手機號碼, 公司傳真, 地址, 送貨地址, 統一編號, 備註, 發票抬頭, 聯絡人, 月結日期, 業務, 屬性,email)
values ('{entity.客戶編號}','{entity.客戶名稱}','{entity.公司電話}','{entity.電話}','{entity.手機號碼}','{entity.公司傳真}','{entity.地址}','{entity.送貨地址}','{entity.統一編號}','{entity.備註}','{entity.發票抬頭}',
'{entity.聯絡人}','{entity.月結日期}','{entity.業務}','{entity.屬性}','{entity.email}')
";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }
        public bool Edit(CustomerData entity)
        {
            //string Sqlstr = $@"UPDATE CustomerData Set 客戶名稱=@客戶名稱,公司電話=@公司電話,
            //                電話=@電話,手機號碼=@手機號碼,公司傳真=@公司傳真,地址=@地址,送貨地址=@送貨地址,備註=@備註,發票抬頭=@發票抬頭,
            //                聯絡人=@聯絡人,月結日期=@月結日期,業務=@業務,屬性=@屬性,email=@email
            //                WHERE 客戶編號=@客戶編號";

            string Sqlstr = $@"UPDATE CustomerData Set 客戶名稱='{entity.客戶名稱}',公司電話='{entity.公司電話}',
                            電話='{entity.電話}',手機號碼='{entity.手機號碼}',公司傳真='{entity.公司傳真}',地址='{entity.地址}',送貨地址='{entity.送貨地址}',備註='{entity.備註}',發票抬頭='{entity.發票抬頭}',
                            聯絡人='{entity.聯絡人}',月結日期='{entity.月結日期}',業務='{entity.業務}',屬性='{entity.屬性}',email='{entity.email}'
                            WHERE 客戶編號='{entity.客戶編號}'";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }
        public bool Delete(CustomerData entity)
        {
            string Sqlstr = $@"DELETE FROM CustomerData
                            WHERE 客戶編號=@客戶編號
";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult == 1;
        }

        public DataTable TurnTable(List<CustomerData> lst)
        {
            return ListConvertDataTable(lst);
        }

        internal CustomerData SinglebyName(string keyStr)
        {
            DynamicParameters Dp = new DynamicParameters();
            Dp.Add("keyStr", keyStr);
            string Sqlstr = $@"SELECT top 1 * FROM CustomerData where 客戶名稱 =@keyStr";
            var dbresult = ConectSQL(Sqlstr, Dp).FirstOrDefault();
            return dbresult;           
        }
    }
}
