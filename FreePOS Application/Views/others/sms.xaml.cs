using FreePOS.bll;
using FreePOS.data.dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace FreePOS.Views.others
{
    /// <summary>
    /// Interaction logic for sms.xaml
    /// </summary>
    public partial class sms : Window
    {
        userrepo ur = new userrepo();
        List<data.dapper.user> users;
        public sms()
        {
            InitializeComponent();
            this.users = ur.get();
            dg.ItemsSource = users;
        }

        private void sendsms(object sender, RoutedEventArgs e)
        {
            string[] dgselectednumbers = otherutils.parsenumbersfromdynamiclist(dg.SelectedItems);
            if (commaseperatednumbers_tb.Text != "")
            {
                string[] commaseperatednumbers =   otherutils.parsenumbersfromcommaorspaceseperatedstring(commaseperatednumbers_tb.Text);
                dgselectednumbers = commaseperatednumbers.Concat(dgselectednumbers).ToArray();
            }
            var isvalid = otherutils.checkmessagevalidation(text_tb.Text, dgselectednumbers);
            if (isvalid)
            {
                var isuservalid = userutils.checkravicosoftuseridexits();
                if (!isuservalid)
                {
                    otherutils.notify("Alert", "Message sending failed, Ravicosoft user does not exists", 10000);
                    return;
                }
                networkutils.sendsms(text_tb.Text, dgselectednumbers);
                Close();
                new sms().Show();
            }
            
        }
    }
}
