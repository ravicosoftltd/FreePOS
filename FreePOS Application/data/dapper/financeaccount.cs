using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBook.data.dapper
{
    [System.ComponentModel.DataAnnotations.Schema.Table("financeaccount")]

    public class financeaccount
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Nullable<int> fk_parent_in_financeaccount { get; set; }
    }
    public class financeaccountswihparentnames : financeaccount
    {
        public string fk_parent_in_financeaccount_name { get; set; }
    }
    public class financeaccountbalance: financeaccount
    {
        public int total { get; set; }
    }
    public class financeaccountrepo
    {
        string conn = databaseutils.connectionstring;
        public void  test()
        {
            //dapper.financeaccount p = new financeaccount { barcode = "1231321234234", carrycost = 0, discount = 0, name = "deal 1", purchaseprice = 40,purchaseactive=false, quantity = 0,saleprice=50,saleactive=true };
            //this.save(p);
        }
        public List<dapper.financeaccount> get() {
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.GetAll<dapper.financeaccount>().ToList();
                return res;
            }
        }
        public dapper.financeaccount get(int id)
        {
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Get<dapper.financeaccount>(id);
                return res;
            }
        }
        public List<dapper.financeaccountswihparentnames> getwithparentnames()
        {
            string sql = "select t1.id,t1.name,t1.type,t1.fk_parent_in_financeaccount, t2.name as fk_parent_in_financeaccount_name from financeaccount t1 left join financeaccount t2 on t1.fk_parent_in_financeaccount = t2.id;";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financeaccountswihparentnames>(sql).ToList();
                return res;
            }
        }
        public dapper.financeaccount getonebyname(string name)
        {
            var sql = "select * from financeaccount where name='"+name+"';";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financeaccount>(sql).FirstOrDefault();
                return res;
            }
        }
        public List<dapper.financeaccount> getmanybynames(string[] names)
        {
            var nameswhereinstatement = databaseutils.getWhereInSql(names);
            var sql = "select * from financeaccount where name in (" + nameswhereinstatement + ");";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financeaccount>(sql).ToList();
                return res;
            }
        }
        public List<dapper.financeaccount> getmanybytype(string type)
        {
            var sql = "select * from financeaccount where type='" + type + "';";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financeaccount>(sql).ToList();
                return res;
            }
        }
        
        public List<dapper.financeaccount> getmanybysqlor(dynamic listofkeyvaluepairs)
        {
            string orsql = databaseutils.getkeyValuesToSqlOr(listofkeyvaluepairs);
            var sql = "select * from financeaccount where "+ orsql + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financeaccount>(sql).ToList();
                return res;
            }
        }
        public List<dapper.financeaccount> getmanybysqland(dynamic listofkeyvaluepairs)
        {
            string andsql = databaseutils.getkeyValuestoSqlAnd(listofkeyvaluepairs);
            var sql = "select * from financeaccount where " + andsql + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financeaccount>(sql).ToList();
                return res;
            }
        }
        public dapper.financeaccount save(dapper.financeaccount financeaccount)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Insert<dapper.financeaccount>(financeaccount);
                financeaccount.id = (int)res;
                return financeaccount;
            }
        }
        public bool update(dapper.financeaccount financeaccount)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var identity = connection.Update<dapper.financeaccount>(financeaccount);
                return identity;
            }
        }

        public dynamic getaccountsbalances()
        {
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            string sql = " select t1.total,t1.id,t2.name from (select sum(amount) total,fk_financeaccount_in_financetransaction id FROM financetransaction group by fk_financeaccount_in_financetransaction) as t1 join financeaccount t2 on t1.id = t2.id;";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<financeaccountbalance>(sql);
                return res;
            }
        }
    }
}
