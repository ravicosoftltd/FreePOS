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
using Microsoft.Reporting.WinForms;

namespace FreePOS.Views
{
    /// <summary>
    /// Interaction logic for report.xaml
    /// </summary>
    public partial class reportviewer : Window
    {
        public reportviewer(string reportpath, List<KeyValuePair<string, string>> prms, List<KeyValuePair<string, DataTable>> datasources)
        {
            InitializeComponent();
            _reportviewer.LocalReport.ReportPath = @reportpath;
            appendparams(prms);
            appenddatasrouces(datasources);
            _reportviewer.RefreshReport();
        }
        void appendparams(List<KeyValuePair<string,string>> prms)
        {
            foreach(KeyValuePair<string, string> obj in prms)
            {
                var prm = new ReportParameter(obj.Key, obj.Value);
                _reportviewer.LocalReport.SetParameters(prm);
            }
        }

        void appenddatasrouces(List<KeyValuePair<string, DataTable>> datasources)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("id", typeof(string));
            //dt.Columns.Add("name", typeof(string));

            //DataRow myDataRow = dt.NewRow();
            //myDataRow["id"] = "1";
            //myDataRow["name"] = "aaa";
            //dt.Rows.Add(myDataRow);

            //DataRow myDataRow1 = dt.NewRow();
            //myDataRow1["id"] = "2";
            //myDataRow1["name"] = "bbb";
            //dt.Rows.Add(myDataRow1);

            //var reportDataSource = new ReportDataSource("products", dt);
            //_reportviewer.LocalReport.DataSources.Add(reportDataSource);

            foreach (KeyValuePair<string, DataTable> obj in datasources)
            {
                var reportDataSource = new ReportDataSource(obj.Key, obj.Value);
                _reportviewer.LocalReport.DataSources.Add(reportDataSource);
            }
        }

    }

}
