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
    [System.ComponentModel.DataAnnotations.Schema.Table("productsub")]

    public class productsub
    {
        public int id { get; set; }
        public int fk_product_main_in_productsub { get; set; }
        public int fk_product_sub_in_productsub { get; set; }
        public double quantity { get; set; }



    }
    public class productsubextented : productsub
    {
        public virtual string productname { get; set; }
        public virtual string productsubname { get; set; }

    }
    public class productsubrepo
    {
        string conn = databaseutils.connectionstring;
        public List<dapper.productsub> get() {
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.GetAll<dapper.productsub>().ToList();
                return res;
            }
        }
        public dapper.productsub get(int id)
        {
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Get<dapper.productsub>(id);
                return res;
            }
        }
        public List<dapper.productsubextented> getproduct_productsubs(int id)
        {
            var sql = "select sp.id,fk_product_main_in_productsub,fk_product_sub_in_productsub,sp.quantity,sp_p.name as productname,sp_sp.name as productsubname from productsub sp inner join product sp_p on sp.fk_product_main_in_productsub = sp_p.id inner join product sp_sp on sp.fk_product_sub_in_productsub = sp_sp.id where fk_product_main_in_productsub = " + id+";";
            //var sql = "select * from productsub where fk_product_main_in_productsub="+id+";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.productsubextented>(sql).ToList();
                return res;
            }
        }
        public int save(dapper.productsub productsub)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Insert<dapper.productsub>(productsub);
                return (int)res;
            }
        }
        public bool update(dapper.productsub productsub)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var identity = connection.Update<dapper.productsub>(productsub);
                return identity;
            }
        }
        public bool delete(dapper.productsub productsub)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var identity = connection.Delete<dapper.productsub>(productsub);
                return identity;
            }
        }
    }
}
