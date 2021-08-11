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
    [System.ComponentModel.DataAnnotations.Schema.Table("softwaresetting")]

    public class softwaresetting
    {
        public int id { get; set; }
        public string name { get; set; }
        public string valuetype { get; set; }
        public string stringvalue { get; set; }
        public int intvalue { get; set; }
        public Nullable<bool> boolvalue { get; set; }
        public Nullable<double> floatvalue { get; set; }
        public Nullable<System.DateTime> datevalue { get; set; }
    }
    

    
    public class softwaresettingrepo
    {
        string conn = databaseutils.connectionstring;
        
        
        public dapper.softwaresetting get(int id)
        {
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Get<dapper.softwaresetting>(id);
                return res;
            }
        }
        public dapper.softwaresetting getbyname(string name)
        {
            var sql = "select * from softwaresetting where name='" + name + "'";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.softwaresetting>(sql).FirstOrDefault();

                return res;
            }
        }
        public dapper.softwaresetting save(dapper.softwaresetting softwaresetting)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Insert<dapper.softwaresetting>(softwaresetting);
                softwaresetting.id = (int)res;
                return softwaresetting;
            }
        }
        public softwaresetting update(dapper.softwaresetting softwaresetting)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var identity = connection.Update<dapper.softwaresetting>(softwaresetting);
                return softwaresetting;
            }
        }
    }
}
