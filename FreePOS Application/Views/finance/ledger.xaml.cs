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
    public partial class ledger : Window
    {
        //List<financeaccount> financeaccounts = null;
        data.dapper.user user;

        List<data.dapper.financeaccount> financeaccounts = null;

        public ledger(int userid)
        {
            InitializeComponent();

            var financeaccountrepo = new data.dapper.financeaccountrepo();
            var financetransactionrepo = new data.dapper.financetransactionrepo();
            var userrepo = new data.dapper.userrepo();
            financeaccounts = financeaccountrepo.get();
            user = userrepo.get(userid);
            var list = financetransactionrepo.getusertransactions(userid);
            foreach (var item in list)
            {
                dg.Items.Add(item);
            }

            var totalpending = 0;
            if (user.role == "customer")
            {
                totalpending = financetransactionrepo.getuserreceiveablessum(userid);

            }
            else if (user.role == "vendor")
            {
                totalpending = financetransactionrepo.getuserpayablesum(userid);
            }
            remaining_label.Content = totalpending;
            var assetaccounts = financeaccountrepo.getmanybytype("asset");
            account_combobox.ItemsSource = assetaccounts;
            account_combobox.DisplayMemberPath = "name";
            account_combobox.SelectedValuePath = "id";
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (account_combobox.SelectedItem == null)
            {
                MessageBox.Show("Please select account");
                return;
            }
            if (tb_amount.Text == "")
            {
                MessageBox.Show("Please enter amount");
                return;
            }

            var amount = Convert.ToDouble(tb_amount.Text);
            var account = (int)account_combobox.SelectedValue;
            if (user.role == "customer")
            {
                financeutils.insertCustomerPayment(account, amount, user.id);
            }
            else if (user.role == "vendor")
            {
                financeutils.insertVendorPayment(account, amount, user.id);
            }
            MessageBox.Show("Operation Successfull");
            Close();
            new ledger(user.id).Show();

        }
    }

}
