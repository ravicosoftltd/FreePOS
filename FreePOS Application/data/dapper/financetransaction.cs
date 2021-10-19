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
using Windows.UI.Xaml;

namespace FreePOS.data.dapper
{
    [System.ComponentModel.DataAnnotations.Schema.Table("financetransaction")]

    public class financetransaction
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<double> amount { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string details { get; set; }
        public Nullable<int> fk_user_createdby_in_financetransaction { get; set; }
        public Nullable<int> fk_user_targetto_in_financetransaction { get; set; }
        public Nullable<int> fk_financeaccount_in_financetransaction { get; set; }

    }
    public class financetransactionextended : financetransaction 
    {
        public string accountname { get; set; }
        public string createdby { get; set; }
        public string target { get; set; }
    }
    public class financetransactionrepo
    {
        string joinselect = "t1.id,t1.name,t1.amount,t1.status,t1.details,t1.date,t1.fk_user_createdby_in_financetransaction,t1.fk_user_targetto_in_financetransaction,t1.fk_financeaccount_in_financetransaction,t2.name as accountname,t3.name as createdby,t4.name as target  from financetransaction t1 join financeaccount t2 on t1.fk_financeaccount_in_financetransaction = t2.id join `user` t3 on t1.fk_user_createdby_in_financetransaction=t3.id left join `user` t4 on  t1.fk_user_targetto_in_financetransaction=t4.id";
        string conn = databaseutils.connectionstring;
        public List<dapper.financetransaction> get() {
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.GetAll<dapper.financetransaction>().ToList();
                return res;
            }
        }
        public List<dapper.financetransactionextended> getWithReferencedNames(DateTime? fromDate, DateTime? toDate)
        {
            string sql = "select " + joinselect + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<financetransactionextended>(sql).Where(a=> a.date>=fromDate && a.date<=toDate).ToList();
                return res;
            }
        }
        public dapper.financetransactionextended get(int id)
        {
            string sql = "select " + joinselect + " where t1.id="+id+";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<financetransactionextended>(sql).FirstOrDefault();
                return res;
            }
        }
        public List<dapper.financetransactionextended> getmanybymanyfinanceaccountnames(string[] financeaccountnames, DateTime? fromDate, DateTime? toDate)
        {
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            List<financeaccount> financeaccounts = financeaccountrepo.getmanybynames(financeaccountnames);
            object[] financeaccountids = new object[financeaccounts.Count()];
            for (int i = 0; i < financeaccounts.Count(); i++)
            {
                financeaccountids[i] = financeaccounts[i].id;
            }
            var financeaccountsidarray = databaseutils.getWhereInSql(financeaccountids);
            string sql = "select " + joinselect + " where t1.fk_financeaccount_in_financetransaction in (" + financeaccountsidarray + ");";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financetransactionextended>(sql).Where(a => a.date >= fromDate && a.date <= toDate).ToList();
                return res;
            }
        }
        public List<dapper.financetransactionextended> getmanybyselfnameandfinanceaccountname(string selfname,string financeaccountname, DateTime? fromDate, DateTime? toDate)
        {
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financeaccount financeaccount = financeaccountrepo.getonebyname(financeaccountname);

            string sql = "select " + joinselect + " where t1.name='" + selfname+"' and t1.fk_financeaccount_in_financetransaction=" + financeaccount.id + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financetransactionextended>(sql).Where(a => a.date >= fromDate && a.date <= toDate).ToList();
                return res;
            }
        }
        public List<financetransactionextended> getmanybyfinanceaccounttype(string financeaccounttype, DateTime? fromDate, DateTime? toDate)
        {
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            List<financeaccount> financeaccounts = financeaccountrepo.getmanybytype(financeaccounttype);
            object[] financeaccountids = new object[financeaccounts.Count()];
            for (int i = 0; i < financeaccounts.Count(); i++)
            {
                financeaccountids[i] = financeaccounts[i].id;
            }
            
            string whereincontent = databaseutils.getWhereInSql(financeaccountids);
            string sql = "select " + joinselect + " where fk_financeaccount_in_financetransaction in (" + whereincontent + ");";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<financetransactionextended>(sql).Where(a => a.date >= fromDate && a.date <= toDate).ToList();
                return res;
            }
        }
        public int getuserreceiveablessum(int userid)
        {
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financeaccount financeaccount = financeaccountrepo.getonebyname("account receivable");
            string sql = "select sum(amount) from financetransaction where fk_user_targetto_in_financetransaction=" + userid + " and fk_financeaccount_in_financetransaction=" + financeaccount.id + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.ExecuteScalar<int>(sql);
                return res;
            }
        }
        public List<financetransactionextended> getusertransactions(int userid)
        {
            
            string sql = "select " + joinselect + " where t1.fk_user_targetto_in_financetransaction=" + userid + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Query<dapper.financetransactionextended>(sql).ToList();
                return res;
            }
        }
        public int getuserpayablesum(int userid)
        {
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financeaccount financeaccount = financeaccountrepo.getonebyname("account payable");
            var list = new List<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<string, object>("fk_user_targetto_in_financetransaction", userid));
            list.Add(new KeyValuePair<string, object>("fk_financeaccount_in_financetransaction", financeaccount.id));
            string and = databaseutils.getkeyValuestoSqlAnd(list);
            string sql = "select sum(amount) from financetransaction where "+and+";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.ExecuteScalar<int>(sql);
                return res;
            }
        }

        public int gettransactionsumbyaccountnamesandfromtodate(string[] financeaccountnames,DateTime? FromDate, DateTime? ToDate)
        {
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            List<financeaccount> financeaccounts = financeaccountrepo.getmanybynames(financeaccountnames);
            object[] financeaccountids = new object[financeaccounts.Count()];
            for (int i = 0; i < financeaccounts.Count(); i++)
            {
                financeaccountids[i] = financeaccounts[i].id;
            }
            var financeaccountsidarray = databaseutils.getWhereInSql(financeaccountids);
            string sql = "select sum(amount) from financetransaction where fk_financeaccount_in_financetransaction in (" + financeaccountsidarray + ")";
            if (FromDate != null)
            {
                var fromdate = TimeUtils.getStartDate(FromDate);
                sql += " and date>='" + fromdate.Year + "-" + fromdate.Month + "-" + fromdate.Day + "'";
            }
            if (ToDate != null)
            {
                var todate = TimeUtils.getEndDate(ToDate);
                todate = todate.AddDays(1); //add day mean next day at 00:00:00, so it will be todate end
                sql += " and date<='" + todate.Year + "-" + todate.Month + "-" + todate.Day + "'";
            }
            sql += ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.ExecuteScalar<int>(sql);
                return res;
            }
        }

        public dapper.financetransaction save(dapper.financetransaction financetransaction)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.Insert<dapper.financetransaction>(financetransaction);
                financetransaction.id = (int)res;
                return financetransaction;
            }
        }
        public bool update(dapper.financetransaction financetransaction)
        {

            using (var connection = new MySqlConnection(conn))
            {
                var identity = connection.Update<dapper.financetransaction>(financetransaction);
                return identity;
            }
        }

        public bool hasuserfinancetransactions(int userid)
        {
            string sql = "select count(*) from financetransaction where fk_user_createdby_in_financetransaction=" + userid + " or fk_user_targetto_in_financetransaction=" + userid + ";";
            using (var connection = new MySqlConnection(conn))
            {
                var res = connection.ExecuteScalar<int>(sql);
                if (res != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
