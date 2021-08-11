using BusinessBook.data.dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BusinessBook.Views.others
{
    /// <summary>
    /// Interaction logic for SQLQueryBuilder.xaml
    /// </summary>
    public partial class SQLQueryBuilder : Window
    {
        public SQLQueryBuilder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = null;

            var query = tb_query.Text;
            if (query != "") {
                var result =  databaseutils.runCustomQuery(query);
                if (result != null) {
                    try { } catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Error in display data");
                    }
                    dg.ItemsSource = result;

                }
                var i = 0;
            }
        }
        public DataTable ConvertToDataTable(IEnumerable<dynamic> items)
        {
            var t = new DataTable();
            var first = (IDictionary<string, object>)items.First();
            foreach (var k in first.Keys)
            {
                var c = t.Columns.Add(k);
                var val = first[k];
                if (val != null) c.DataType = val.GetType();
            }

            foreach (var item in items)
            {
                var r = t.NewRow();
                var i = (IDictionary<string, object>)item;
                foreach (var k in i.Keys)
                {
                    var val = i[k];
                    if (val == null) val = DBNull.Value;
                    r[k] = val;
                }
                t.Rows.Add(r);
            }
            return t;
        }
    }
}
