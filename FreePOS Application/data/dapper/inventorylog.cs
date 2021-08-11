using FreePOS.bll;
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
    [System.ComponentModel.DataAnnotations.Schema.Table("inventorylog")]

    public class inventorylog
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string note { get; set; }
        public Nullable<double> quantity { get; set; }
        public Nullable<int> fk_product_in_inventorylog { get; set; }
    }
    public class inventorylogrepo
    {
        string conn = databaseutils.connectionstring;

        public List<dapper.inventorylog> get(int productid, DateTime? FromDate = null, DateTime? ToDate = null)
        {
            
            var sql = "select * from inventorylog where fk_product_in_inventorylog=" + productid + "";
            if (FromDate != null)
            {
                var fromdate = TimeUtils.getStartDate(FromDate);
                sql += " and date>='"+fromdate.Year+"-"+ fromdate.Month+"-"+ fromdate.Day+ "'";
            }
            if (ToDate != null)
            {
                var todate = TimeUtils.getEndDate(ToDate);
                todate = todate.AddDays(1); //add day mean next day at 00:00:00, so it will be todate end
                sql += " and date<='" + todate.Year + "-" + todate.Month + "-" + todate.Day + "'";
            }
            sql +=";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.inventorylog>(sql).ToList();
                return res;
            }
        }
        public bool save(dapper.inventorylog product)
        {
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Insert<dapper.inventorylog>(product);
                return true;
            }
        }
    }
}
