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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusinessBook.Views.others
{
    /// <summary>
    /// Interaction logic for ProductsTextBoxAutoComplete.xaml
    /// </summary>
    public partial class ProductsTextBoxAutoComplete : UserControl
    {
        productrepo productrepo = new productrepo();
        private data.dapper.product selectedItem;
        public ProductsTextBoxAutoComplete()
        {
            try
            {
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

        public data.dapper.product SelectedItem
        {
            get { return this.selectedItem; }
            set { this.selectedItem = value; }
        }


        private void OpenAutoSuggestionBox()
        {
            try
            {
                this.autoListPopup.Visibility = Visibility.Visible;
                this.autoListPopup.IsOpen = true;
                this.productsListBox.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }
        
        private void CloseAutoSuggestionBox()
        {
            try
            {
                this.autoListPopup.Visibility = Visibility.Collapsed;
                this.autoListPopup.IsOpen = false;
                this.productsListBox.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }
        private void autoTextBox_Focus(object sender, RoutedEventArgs e)
        {
            autoTextBox.Text = "";
            selectedItem = null;
        }
        private void AutoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.autoTextBox.Text))
                {
                    this.CloseAutoSuggestionBox();
                    return;
                }

                this.OpenAutoSuggestionBox();

                this.productsListBox.ItemsSource = this.productrepo.search(this.autoTextBox.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }
        private void AutoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.productsListBox.SelectedIndex <= -1)
                {
                    this.CloseAutoSuggestionBox();

                    return;
                }
 
                this.CloseAutoSuggestionBox();
                var selectedItem = this.productsListBox.SelectedItem as data.dapper.product;
                this.autoTextBox.Text = selectedItem.name;
                this.selectedItem = selectedItem;
                this.productsListBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {  
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

        
    }
}
