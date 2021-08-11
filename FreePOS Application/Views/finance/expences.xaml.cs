using FreePOS.bll;
using FreePOS.data;
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
    /// Interaction logic for ledger.xaml
    /// </summary>
    public partial class expences : Window
    {
        //List<financeaccount> financeaccounts = null;
        List<data.dapper.financeaccount> financeaccounts = null;
        public expences()
        {
            InitializeComponent();
            //var db = new dbctx();
            //financeaccounts = db.financeaccount.ToList();
            var financeaccountrepo = new data.dapper.financeaccountrepo();
            var financetransactionrepo = new data.dapper.financetransactionrepo();
            financeaccounts = financeaccountrepo.get();
            //var list = db.financetransaction.Where(a => (a.financeaccount.type == "expence")).ToList();
            var list = financetransactionrepo.getmanybyfinanceaccounttype("expence");
            foreach (var item in list)
            {
                dg.Items.Add(item);
            }
            var assetaccounts = financeaccounts.Where(a => a.type == "asset").ToList();
            payingaccount_combobox.ItemsSource = assetaccounts;
            payingaccount_combobox.DisplayMemberPath = "name";
            payingaccount_combobox.SelectedValuePath = "id";
            var expenceaccounts = financeaccounts.Where(a => a.type == "expence").ToList();
            expenceaccount_combobox.ItemsSource = expenceaccounts;
            expenceaccount_combobox.DisplayMemberPath = "name";
            expenceaccount_combobox.SelectedValuePath = "id";

        }

        private void save(object sender, RoutedEventArgs e) 
        {
            try 
            {
                if (payingaccount_combobox.SelectedItem == null || expenceaccount_combobox.SelectedItem == null)
                {
                    MessageBox.Show("Please select account");
                }
                if (tb_amount.Text == "")
                {
                    MessageBox.Show("Please enter amount");
                }

                var amount = Convert.ToDouble(tb_amount.Text);
                var paingaccount = (int)payingaccount_combobox.SelectedValue;
                var expenceaccount = (int)expenceaccount_combobox.SelectedValue;
                financeutils.insertexpence(paingaccount, expenceaccount, amount);
             
                MessageBox.Show("Operation Successfull");
                Close();
                new expences().Show();
            } catch 
            {
                MessageBox.Show("Operation Successfull");
            }
            
            
        }
    }

}
