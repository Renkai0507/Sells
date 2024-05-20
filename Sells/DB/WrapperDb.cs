
using Sells.DB;

namespace Sells
{
    public interface IDbServiceWrapper
    {
        PopularProductDb ProductData { get; }
        CustomerDataDb CustomerData { get; }
        SellsDb Sells { get; }
    }
    class DbServiceWrapper : IDbServiceWrapper
    {
        string conn;
        public DbServiceWrapper()
        {
            conn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:/testdb.mdb;Jet OLEDB:Database Password=12345";            
        }
        public PopularProductDb ProductData => new PopularProductDb(conn);
        public CustomerDataDb CustomerData => new CustomerDataDb(conn);
        public SellsDb Sells =>  new SellsDb(conn);
    }
}
