
using Microsoft.SqlServer.Server;
using BusinessBook.bll;
using BusinessBook.data;
using BusinessBook.data.dapper;
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
    /// Interaction logic for sales.xaml
    /// </summary>
    public partial class accountsbalance : Window
    {
        public accountsbalance()
        {
            InitializeComponent();
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            var list = financeaccountrepo.getaccountsbalances();
            foreach (var item in list)
            {
                dg.Items.Add(item);
            }
        }
    }
    
}
