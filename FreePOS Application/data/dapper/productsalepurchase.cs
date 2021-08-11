using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.data.dapper
{
    [System.ComponentModel.DataAnnotations.Schema.Table("productsalepurchase")]

    public class productsalepurchase
    {
        public int id { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<double> quantity { get; set; }
        public Nullable<double> total { get; set; }
        public Nullable<int> fk_product_in_productsalepurchase { get; set; }
        public Nullable<int> fk_financetransaction_in_productsalepurchase { get; set; }
    }
    public class productsalepurchaseextended : productsalepurchase
    {
        public string productname { get; set; }
    }
    public class productsalepurchaserepo
    {
        string joinselect = "t1.id,t1.price,t1.quantity,t1.total,t1.fk_product_in_productsalepurchase,t1.fk_financetransaction_in_productsalepurchase,t2.name as productname from productsalepurchase t1 join product t2 on t1.fk_product_in_productsalepurchase = t2.id";

        string conn = databaseutils.connectionstring;
        
        public List<dapper.productsalepurchaseextended> getmultiplebytransactionid(int financetransactionid)
        {
            var sql = "select " + joinselect + " where fk_financetransaction_in_productsalepurchase=" + financetransactionid + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.productsalepurchaseextended>(sql).ToList();
                return res;
            }
        }
        public dapper.productsalepurchase save(dapper.productsalepurchase productsalepurchase)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Insert<dapper.productsalepurchase>(productsalepurchase);
                productsalepurchase.id = (int)res;
                return productsalepurchase;
            }
        }
    }
}
