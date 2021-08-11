using BusinessBook.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using BusinessBook.data.dapper;


namespace BusinessBook.Views
{
    /// <summary>
    /// Interaction logic for Form_InputDialogForAddCustomerInNewSale.xaml
    /// </summary>
    public partial class DialogSelectUser : Window
    {
        string roletype = null;
        public data.dapper.user seleteduser { get; set; }
        List<data.dapper.user> allusers = null;
        
        public DialogSelectUser(string roletype)
        {
            InitializeComponent();
            tb_Phone.Focus();
            this.roletype = roletype;
            // var db = new dbctx();
            var userrepo = new userrepo();
            ////var db = new dbctx();
            if (roletype == "staff")
            {
                //dg_AllStaff.ItemsSource = db.user.Where(a => (a.role == "admin" || a.role == "user")).ToList();
                var roles = new object[] { "admin","user" };
                allusers = userrepo.getbywherein("role",roles);
            }
            else if (roletype == "customer")
            {
                //dg_AllStaff.ItemsSource = db.user.Where(a => a.role == "customer").ToList();
                var roles = new object[] { "customer" };
                allusers = userrepo.getbywherein("role", roles);
            }
            else
            {
                //dg_AllStaff.ItemsSource = db.user.Where(a => a.role == "vendor").ToList();
                var roles = new object[] { "vendor" };
                allusers = userrepo.getbywherein("role", roles);
            }
            dg.ItemsSource = allusers;
        }

        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var db = new dbctx();

            //if (tb_Search.Text != null)
            //{
            //    try
            //    {
            //        dg.ItemsSource = db.user.Where(a => (a.role == roletype) && (a.phone.Contains(tb_Search.Text))).ToList();
            //    }
            //    catch { }
            //}
        }

        public void select(object sender, RoutedEventArgs e)
        {
            data.dapper.user obj = ((FrameworkElement)sender).DataContext as data.dapper.user;
            this.seleteduser = obj;
            DialogResult = true;
        }
        public void cancel(object sender, RoutedEventArgs e)
        {
            this.seleteduser = null;
            DialogResult = true;
        }


        private void SaveAndSelect(object sender, System.Windows.RoutedEventArgs e)
        {
            //var db = new dbctx();
            data.dapper.user c = new data.dapper.user();
            c.phone = tb_Phone.Text;
            c.role = roletype;
            c.name = tb_Name.Text;
            c.address = tb_Address.Text;

            //db.user.Add(c);
            //db.SaveChanges();
            var userrepo = new userrepo();
            var customer = userrepo.save(c);
            this.seleteduser = customer;
            DialogResult = true;
        }

        

    }
}
