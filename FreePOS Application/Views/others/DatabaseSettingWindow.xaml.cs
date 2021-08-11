using FreePOS.bll;
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

namespace FreePOS.Views.others
{
    /// <summary>
    /// Interaction logic for DatabaseSettingWindow.xaml
    /// </summary>
    public partial class DatabaseSettingWindow : Window
    {
        public DatabaseSettingWindow()
        {
            InitializeComponent();
            tb_DatabaseServer.Text = AppSetting.DatabaseServer;
            tb_DatabaseName.Text = AppSetting.DatabaseName;
            tb_DatabaseUsername.Text = AppSetting.DatabaseUsername;
            tb_DatabasePassword.Password = AppSetting.DatabasePassword;
        }
        private void Button_CheckDatabaseConnection_Click(object sender, RoutedEventArgs e)
        {
            if (tb_DatabaseServer.Text != "" && tb_DatabaseName.Text != "" || tb_DatabaseUsername.Text != "" || tb_DatabasePassword.Password != "")
            {
                dynamic result = databaseutils.checkServerConnectionWithCredentials(tb_DatabaseServer.Text, tb_DatabaseUsername.Text, tb_DatabasePassword.Password);
                var isbool = (result is bool);
                if (isbool) {
                    if (result == true)
                    {
                        MessageBox.Show("Server connected successfully", "Info");
                        btn_Save.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Server not connected. You may have these issues " +
                        "\n1. MySql Database server not installed or not availabe" +
                        "\n2. If server is installed then check its service is running  " +
                        "\n3. Wrong credentials entered" +
                        "\n Exception Details: \n" +
                        result
                        ,
                        "Info");
                }
            }
            else
            {
                MessageBox.Show("Please enter correct credentials", "Info");
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            btn_Save.IsEnabled = false;
            if (tb_DatabaseServer.Text!=""&& tb_DatabaseName.Text != "" || tb_DatabaseUsername.Text != "" || tb_DatabasePassword.Password != "")
            {
                AppSetting.saveDatabaseSettings(tb_DatabaseServer.Text, tb_DatabaseName.Text, tb_DatabaseUsername.Text, tb_DatabasePassword.Password);
                MessageBox.Show("Database Setting Updated, Please restart application", "Info");
            }
            else
            {
                otherutils.notify("Info", "Wrong configuration", 5000);
            }
        }
        
    }
}
