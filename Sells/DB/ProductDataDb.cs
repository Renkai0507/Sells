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
        public bool AddNew(PopularProduct entity)
        {
            string Sqlstr = $@"Insert into PopularProduct 
(產品編號,產品規格,單位,進價價錢,水電價,安裝價,零售價,備註,進貨日期,地址)
values (@產品編號,@產品規格,@單位,@進價價錢,@水電價,@安裝價,@零售價,@備註,@進貨日期,@地址)
";
            int dbresult = ExecSQL(Sqlstr, entity);
            return dbresult==1;
        }
        public DataTable TurnTable(List<PopularProduct> lst)
        {
            return ListConvertDataTable(lst);
        }
    }
}
