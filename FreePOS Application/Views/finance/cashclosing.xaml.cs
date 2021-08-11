
using BusinessBook.bll;
using BusinessBook.data;
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

namespace BusinessBook.Views.finance
{
    /// <summary>
    /// Interaction logic for transactions.xaml
    /// </summary>
    public partial class cashclosing : Window
    {
        List<data.dapper.financeaccount> financeaccounts = null;
        public cashclosing()
        {
            InitializeComponent();
            var closingbalancerepo = new data.dapper.cashclosingrepo();
            var closingbalancetransactions = closingbalancerepo.get();
            foreach (var item in closingbalancetransactions)
            {
                dg.Items.Add(item);
            }
        }
    }
}
