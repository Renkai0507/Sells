using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sells.DB
{
    public class BasicDb<T,Y>
    {
        protected string conn;
        OleDbConnection db;
        public BasicDb(string _conn)
        {
            conn = _conn;
            Connect();
        }
        protected void Connect()
        {
            db = new OleDbConnection(conn);
            db.ConnectionString = conn;
        }
        protected List<T> ConectSQL(string SQLstr)
        {
            if (db.State == ConnectionState.Closed) db.Open();            
            var dbresult = db.Query<T>(SQLstr, commandType: CommandType.Text).ToList();
            db.Close();
            return dbresult;//dbresult.ToList();
        }
        //protected int ExecSQL(string SQLstr, T entity)
        //{
        //    if (db.State == ConnectionState.Closed) db.Open();
        //    var dbresult = db.Execute(SQLstr,entity, commandType: CommandType.Text);
        //    db.Close();
        //    return dbresult;//dbresult.ToList();
        //}
        protected List<T> ConectSQL(string SQLstr, string[] Codes)
        {
            if (db.State == ConnectionState.Closed) db.Open();
            var dbresult = db.Query<T>(SQLstr, new { Codes }, commandType: CommandType.Text);
            db.Close();
            return dbresult.ToList();
        }
        protected List<T> SearchSQLKey(string SQLstr, Y key)
        {
            if (db.State == ConnectionState.Closed) db.Open();
            var dbresult = db.Query<T>(SQLstr, key, commandTimeout: 90, commandType: CommandType.Text);
            db.Close();
            return dbresult.ToList();
        }
        /// <summary>
        /// 傳入SQL字傳執行
        /// </summary>
        /// <param name="執行SQL指令"></param>
        /// <param name="代入的物件"></param>
        /// <returns>返回SQL執行結果</returns>
        protected List<T> ConectSQL(string SQLstr, T entity)
        {           
            if (db.State == ConnectionState.Closed) db.Open();
            var dbresult = db.Query<T>(SQLstr, entity, commandType: CommandType.Text);
            db.Close();
            return dbresult.ToList();
        }
        protected List<T> ConectSQL(string SQLstr, DynamicParameters Dp)
        {
            if (db.State == ConnectionState.Closed) db.Open();
            var dbresult = db.Query<T>(SQLstr, Dp, commandType: CommandType.Text);
            db.Close();
            return dbresult.ToList();
        }
        protected List<T> ConectSQL(string SQLstr, List<T> entity)
        {
            if (db.State == ConnectionState.Closed) db.Open();
            var dbresult = db.Query<T>(SQLstr, entity, commandType: CommandType.Text);
            db.Close();
            return dbresult.ToList();
        }
         protected int ExecSQL(string SQLstr, T entity)
        {
            if (db.State == ConnectionState.Closed) db.Open();
            var result = db.Execute(SQLstr, entity, commandTimeout: 180, commandType: CommandType.Text);
            db.Close();
            return result;
        }
         protected List<string> GetStrs(string SQLstr)
        {
            IDbConnection db = new SqlConnection(conn);
            if (db.State == ConnectionState.Closed) db.Open();
            var result = db.Query<string>(SQLstr, commandTimeout: 180, commandType: CommandType.Text);
            db.Close();
            return result.ToList();
        }
        public static DataTable ListConvertDataTable<T>(List<T> model) where T : class
        {
            try
            {
                Type value = typeof(T);
                List<PropertyInfo> list = new List<PropertyInfo>(value.GetProperties()); //属性列表
                DataTable table = new DataTable();//实例化datatable
                table.TableName = typeof(T).Name; //表名
                foreach (var property in list)
                {
                    //获取属性数据类型
                    Type PropertyType = property.PropertyType;
                    //验证数据类型是否为空
                    if (PropertyType.IsGenericType && PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        PropertyType = property.PropertyType.GetGenericArguments()[0];
                    }
                    table.Columns.Add(property.Name, PropertyType);
                }
                foreach (var dataValue in model)
                {
                    DataRow row = table.NewRow();
                    list.ForEach(p => { row[p.Name] = p.GetValue(dataValue); });
                    table.Rows.Add(row);
                }
                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
