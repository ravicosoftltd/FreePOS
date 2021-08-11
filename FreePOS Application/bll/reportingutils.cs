using FreePOS.data.dapper;
using FreePOS.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.bll
{
    public static class reportingutils
    {
        public static void prepareinvoicereport(int saleid) {

            var financetransactionrepo = new data.dapper.financetransactionrepo();
            financetransactionextended saletransaction = financetransactionrepo.get(saleid);
            if (saletransaction != null)
            {
                List <KeyValuePair<string, string>> parms = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> saleidkeyvalue = new KeyValuePair<string, string>("saleid",saleid.ToString());
                KeyValuePair<string, string> customernamekeyvalue = new KeyValuePair<string, string>("customername", (saletransaction.target!=null)? saletransaction.target:"");
                parms.Add(saleidkeyvalue);
                parms.Add(customernamekeyvalue);
                var productsalepurchaserepo = new data.dapper.productsalepurchaserepo();
                var productsinsale = productsalepurchaserepo.getmultiplebytransactionid(saleid);
                DataTable dt = ToDataTable<productsalepurchaseextended>(productsinsale);

                List<KeyValuePair<string, DataTable>> dss = new List<KeyValuePair<string, DataTable>>();
                KeyValuePair<string, DataTable> productsds = new KeyValuePair<string, DataTable>("products", dt);
                dss.Add(productsds);
                new reportviewer("data/reporttemplates/invoice.rdl", parms,dss).Show();
            }
        }
        private static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            { 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
