
using Microsoft.SqlServer.Server;
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
    public partial class accounts : Window
    {
        public accounts()
        {
            InitializeComponent();
            var accountytpes = new string[] { "asset", "liabitity", "equity", "income", "expence" };
            category_combobox.ItemsSource = accountytpes;

            //var db = new dbctx();
            //var list = db.financeaccount.ToList();
            var financeaccountrepo = new financeaccountrepo();
            var list = financeaccountrepo.getwithparentnames();
            foreach (var item in list)
            {
                dg.Items.Add(item);
            }
            parent_combobox.ItemsSource = list;
            parent_combobox.DisplayMemberPath = "name";
            parent_combobox.SelectedValuePath = "id";
        }
        private void save(object sender, RoutedEventArgs e)
        {
            //var financeaccount = new financeaccount();
            data.dapper.financeaccount financeaccount = new data.dapper.financeaccount();
            financeaccount.name = tb_Name.Text;
            financeaccount.type =(string)category_combobox.SelectedValue;
            
            if (parent_combobox.SelectedItem != null) {
                var parent = parent_combobox.SelectedItem as data.dapper.financeaccount;
                financeaccount.fk_parent_in_financeaccount = parent.id;
                financeaccount.type = parent.type;
            }
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financeaccountrepo.save(financeaccount);
            //var db = new dbctx();
            //db.financeaccount.Add(financeaccount);
            //db.SaveChanges();
            Close();
            new accounts().Show();

        }
    }
    
}
