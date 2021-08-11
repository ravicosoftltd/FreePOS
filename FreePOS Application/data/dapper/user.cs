using BusinessBook.bll;
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
    [System.ComponentModel.DataAnnotations.Schema.Table("user")]
    public class user
    {
        public int id { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string phone2 { get; set; }
        public string role { get; set; }
    }
    public class userrepo
    {
        string conn = databaseutils.connectionstring;
        public List<dapper.user> get() {
            var sql = "select * from user;";
            using (var connection = new MySqlConnection(conn))
            {
                // var res = connection.Query<user>(sql).ToList();
                var res = connection.GetAll<dapper.user>().ToList();
                return res;
            }
        }
        public dapper.user get(int id)
        {
            var sql = "select * from user where id=" + id+";";

            using (var connection = new MySqlConnection(conn))
            {
                //var res = connection.Query<user>(sql).FirstOrDefault();
                var res = connection.Get<dapper.user>(id);

                return res;
            }
        }
        public dapper.user getonerandom()
        {
            using (var connection = new MySqlConnection(conn))
            {
                //var res = connection.Query<user>(sql).FirstOrDefault();
                var res = connection.GetAll<dapper.user>().FirstOrDefault();
                return res;
            }
        }
        public dapper.user get(string username,string password)
        {
            var sql = "select * from user where username='" + username + "' and password = '"+password+"';";

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<user>(sql).FirstOrDefault();
                return res;
            }
        }
        public List<dapper.user> getbywherein(string key,object[] values)
        {
            string a= databaseutils.getWhereInSql(values);
            string sql = "select * from user where "+key+" in ("+a+");";

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<user>(sql).ToList();
                return res;
            }
        }

        public dapper.user save(dapper.user user)
        {
            if (user.phone != null)
            {
                user.phone = otherutils.parsenumber(user.phone);
            }
            if (user.phone2 != null)
            {
                user.phone2 = otherutils.parsenumber(user.phone2);
            }
            using (var connection = new MySqlConnection(conn))
            {
                var identity = connection.Insert<dapper.user>(user);
                user.id = (int)identity;
                return user;
            }
        }
        public void update(dapper.user user)
        {
            if (user.phone != null)
            {
                user.phone = otherutils.parsenumber(user.phone);
            }
            if (user.phone2 != null)
            {
                user.phone2 = otherutils.parsenumber(user.phone2);
            }
            using (var connection = new MySqlConnection(conn))
            {
                var identity = connection.Update<dapper.user>(user);
                var i = 0;
            }
        }
        public void delete(dapper.user user)
        {
            var finnacetransactionrepo = new financetransactionrepo();
            bool hasuserfinancetransactions = finnacetransactionrepo.hasuserfinancetransactions(user.id);
            if (hasuserfinancetransactions==false)
            {
                using (var connection = new MySqlConnection(conn))
                {
                    var identity = connection.Delete<dapper.user>(user);
                    var i = 0;
                }
            }
            else
            {
                otherutils.notify("Alert", "User has finance transaction, This user can not be deleted", 5000);
            }
        }

    }
}
