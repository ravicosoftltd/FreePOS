
using FreePOS.bll;
using FreePOS.data;
using FreePOS.data.dapper;
using System;
using System.Collections.Generic;
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

namespace FreePOS.Views.finance
{
    /// <summary>
    /// Interaction logic for sales.xaml
    /// </summary>
    public partial class salespurchases : Window
    {
        
        string listtype;
        financetransactionrepo financetransactionrepo= new data.dapper.financetransactionrepo();
        public salespurchases(string type)
        {
            InitializeComponent();
            listtype = type;;
            this.Title = "Sales";
            if (listtype == "purchase")
            {
                this.Title = "Purchases";
            }
        }
        private void Btn_Search_Transactions_Click(object sender, RoutedEventArgs e)
        {
            var fromdate = FromDate.SelectedDate;
            var toDate = ToDate.SelectedDate;
            if (fromdate != null && toDate != null)
            {
                toDate = TimeUtils.getEndDate(toDate);
                dg.ItemsSource = null;
                dg.Items.Clear();
                dg.Items.Refresh();
                List<financetransactionextended> list = new List<financetransactionextended>();
                if (listtype == "sale")
                {
                    
                    list = financetransactionrepo.getmanybymanyfinanceaccountnames(new string[] { "pos sale", "sale", "service sale" }, fromdate, toDate);
                }
                else if (listtype == "purchase")
                {
                    list = financetransactionrepo.getmanybyselfnameandfinanceaccountname("--inventory--on--purchase--", "inventory", fromdate, toDate);
                }
                foreach (var item in list)
                {
                    if (listtype == "sale")
                    {
                        item.amount = -item.amount;
                    };
                    dg.Items.Add(item);
                }
            }

        }
        public void details(object sender, RoutedEventArgs e)
        {
            data.dapper.financetransaction obj = ((FrameworkElement)sender).DataContext as data.dapper.financetransaction;
            new salepurchasedetails(obj.id, listtype).Show();
        }
        public void report(object sender, RoutedEventArgs e)
        {
            
            data.dapper.financetransaction obj = ((FrameworkElement)sender).DataContext as data.dapper.financetransaction;
            
            reportingutils.prepareinvoicereport(obj.id);
        }
    }
}
