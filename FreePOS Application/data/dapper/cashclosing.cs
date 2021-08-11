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
    [System.ComponentModel.DataAnnotations.Schema.Table("cashclosing")]

    public class cashclosing
    {
        public int id { get; set; }
        public Nullable<double> closingbalance { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<double> expence { get; set; }
        public string note { get; set; }
        public Nullable<double> sale { get; set; }
        public Nullable<int> fk_user_in_cashclosing { get; set; }
    }
    public class cashclosingextended : cashclosing
    {
        public string username { get; set; }
    }
    public class cashclosingrepo
    {
        string joinselect = "t1.id,t1.sale,t1.closingbalance,t1.date,t1.expence,t1.note,t1.fk_user_in_cashclosing,t2.name as username from cashclosing t1 join user t2 on t1.fk_user_in_cashclosing = t2.id";

        string conn = databaseutils.connectionstring;
        
        public List<dapper.cashclosingextended> get()
        {
            var sql = "select " + joinselect + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.cashclosingextended>(sql).ToList();
                return res;
            }
        }
        public dapper.cashclosingextended getlast()
        {
            var sql = "select * from cashclosing order by id desc limit 1;";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.cashclosingextended>(sql).FirstOrDefault();
                return res;
            }
        }
        public dapper.cashclosing save(dapper.cashclosing cashclosingtransaction)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Insert<dapper.cashclosing>(cashclosingtransaction);
                cashclosingtransaction.id = (int)res;
                return cashclosingtransaction;
            }
        }
    }
}
