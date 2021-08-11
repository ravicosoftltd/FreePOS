
using BusinessBook.data;
using BusinessBook.data.dapper;
using BusinessBook.Views.finance;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
    public partial class List : Window
    {
        string selectedrole = "";
        data.dapper.userrepo userrepo;
        public List(string role)
        {
            selectedrole = role;
            InitializeComponent();
            
            userrepo = new userrepo();
            var roles = new object[] { role };
            dg_AllStaff.ItemsSource = userrepo.getbywherein("role", roles);
        }
        public void edit(object sender, RoutedEventArgs e)
        {
            data.dapper.user obj = ((FrameworkElement)sender).DataContext as data.dapper.user;
            new user.Add(selectedrole, obj.id).Show();
        }

        public void ledger(object sender, RoutedEventArgs e)
        {
            data.dapper.user obj = ((FrameworkElement)sender).DataContext as data.dapper.user;
            new ledger(obj.id).Show();
        }
        public void delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                data.dapper.user obj = ((FrameworkElement)sender).DataContext as data.dapper.user;
                userrepo.delete(obj);
                Close();
                new user.List(selectedrole).Show();
            }
        }
    }
}
