
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

namespace BusinessBook.Views.user
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        data.dapper.user loggedinpersond;
        bool createmode = true;
        string selectedrole ="";
        data.dapper.user selecteduser = null;
        data.dapper.userrepo userrepo;
        public Add(string role, int? userId = null)
        {
            InitializeComponent();
            userrepo = new userrepo();
            if (role == "")
            {
                role = "customer";
            }
            this.selectedrole = role;
            tb_Role.Text = this.selectedrole;

            if (userId == null || userId == 0)
            {
                this.createmode = true;
            }
            else
            {
                this.createmode = false;
                this.getone((int)userId);
            }

            this.loggedinpersond = userutils.loggedinuserd;
            
            
            
            if (selectedrole == "customer"|| selectedrole == "vendor")
            {
                tb_Password.IsEnabled = false;
                tb_UserName.IsEnabled = false;
            }
            
        }
        void getone(int userid)
        {
            selecteduser = userrepo.get(userid);
            tb_Name.Text = selecteduser.name;
            if (selecteduser.phone != null)
            {
                tb_Phone.Text = selecteduser.phone;
            }
            if (selecteduser.phone2 != null)
            {
                tb_Phone2.Text = selecteduser.phone2;
            }
            if (selecteduser.address != null)
            {
                tb_Address.Text = selecteduser.address;
            }
            if (selecteduser.role != null)
            {
                tb_Role.Text = selecteduser.role;
            }
            if (selecteduser.username != null)
            {
                tb_UserName.Text = selecteduser.username;
            }
            if (selecteduser.password != null)
            {
                tb_Password.Text = selecteduser.password;
            }
        }
        private void btn_Save(object sender, RoutedEventArgs e)
        {
            if (tb_Name.Text == "")
            {
                MessageBox.Show("Please enter name", "Info");
                return;
            }
            
            if (selectedrole == "admin" || selectedrole == "user") {
                if (tb_UserName.Text == "" || tb_Password.Text=="") {
                    MessageBox.Show("Enter Username or password", "Info");
                    return;
                }
            }
            data.dapper.user person = new data.dapper .user();
            person.name = tb_Name.Text;
            person.address = tb_Address.Text;
            person.phone = tb_Phone.Text;
            person.phone2 = tb_Phone2.Text;
            person.username = tb_UserName.Text;
            person.password = tb_Password.Text;
            person.role = this.selectedrole;
            userrepo a = new userrepo();
            if (this.createmode)
            {
                a.save(person);
                MessageBox.Show("Person Saved", "Info");
                Close();
                new Add(this.selectedrole).Show();
            }
            else
            {
                person.id = selecteduser.id;
                a.update(person);
                MessageBox.Show("Person Updated", "Info");
                Close();
                new Add(this.selectedrole,selecteduser.id).Show();
            }
        }
    }
}
