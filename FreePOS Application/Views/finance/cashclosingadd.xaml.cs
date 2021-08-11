
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
    /// Interaction logic for transactions.xaml
    /// </summary>
    public partial class cashclosingadd : Window
    {
        cashclosingrepo cashclosingrepo = null;
        data.dapper.cashclosing lastclosing = null;
        public cashclosingadd()
        {
            InitializeComponent();
            initformoperations();
        }
        private void initformoperations() 
        {
            cashclosingrepo = new data.dapper.cashclosingrepo();
            lastclosing = cashclosingrepo.getlast();
            if (lastclosing != null)
            {
                lastclosing_lbl.Content = "Last Closing: " + lastclosing.closingbalance + " " + lastclosing.date.Value.ToShortDateString();
            }

            double lastclosingbalance = 0;
            if (lastclosing != null)
            {
                lastclosingbalance = (lastclosing.closingbalance!=null)? (double)lastclosing.closingbalance:0;
            }
            double salefromlastclosingdate = 0;
            double expencefromlastclosingdate = 0;

            sale_tb.Text = salefromlastclosingdate.ToString();
            expence_tb.Text = expencefromlastclosingdate.ToString();

            closingbalance_tb.Text =(lastclosingbalance+salefromlastclosingdate- expencefromlastclosingdate).ToString();

        }
        private void save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (
                    sale_tb.Text == ""||
                    expence_tb.Text == ""||
                    closingbalance_tb.Text == ""
                    )
                {
                    MessageBox.Show("Please fill important fields");
                    return;
                }
                var cashclosing = new data.dapper.cashclosing();
                cashclosing.date = DateTime.Now;
                cashclosing.sale = Convert.ToDouble(sale_tb.Text);
                cashclosing.expence = Convert.ToDouble(expence_tb.Text);
                cashclosing.closingbalance = Convert.ToDouble(closingbalance_tb.Text);
                cashclosing.note = note_tb.Text;
                cashclosing.fk_user_in_cashclosing = userutils.loggedinuserd.id;
                cashclosingrepo.save(cashclosing);
                MessageBox.Show("Cashclosing saved");
                Close();
            }
            catch
            {
                MessageBox.Show("Cashclosing not saved");
            }
        }
    }
}
