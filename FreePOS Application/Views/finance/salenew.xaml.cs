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

using System.Reflection;
using System.Media;
using FreePOS.data.viewmodel;
using FreePOS.bll;
using FreePOS.data.dapper;

namespace FreePOS.Views.finance
{
    /// <summary>
    /// Interaction logic for Window_NewSale.xaml
    /// </summary>
    public partial class salenew : Window
    {
        List<productsaleorpurchaseviewmodel> mappedproducts;
        List<productsaleorpurchaseviewmodel> cart = new List<productsaleorpurchaseviewmodel>();
        productrepo productrepo = new productrepo();
        userrepo userrepo = new userrepo();
        productsaleorpurchaseviewmodel lastInsertedProductInCart = null;
        public salenew()
        {
            InitializeComponent();
            initFormOperations();
        }

        void initFormOperations()
        {
            BarcodeMode_cb.IsChecked = AppSetting.BarcodeMode;
            if ((bool)BarcodeMode_cb.IsChecked)
            {
                tb_Search.Text = "";
                tb_Search.Visibility = Visibility.Hidden;
                tb_Search_Barcode.Text = "";
                lv_SearchFoodItem.Visibility = Visibility.Hidden;
                tb_Search_Barcode.Visibility = Visibility.Visible;
                tb_Search_Barcode.Focus();
            }
            else
            {
                tb_Search.Text = "";
                tb_Search.Visibility = Visibility.Visible;
                tb_Search.Focus();
                tb_Search_Barcode.Text = "";
                tb_Search_Barcode.Visibility = Visibility.Hidden;
            }
            var products = this.productrepo.get();
            mappedproducts = productutils.mapproducttoproductsalemodel(products);
            cart_dg.ItemsSource = cart;
            var customers = userrepo.getbywherein("role", new dynamic[] { "customer" });
            customer_combobox.ItemsSource = customers;
            customer_combobox.DisplayMemberPath = "name";
            customer_combobox.SelectedValuePath = "id";

        }

        private void paying_textbox_KeyDownPressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                doneSale();
            }
        }
        void addItem_To_cart(productsaleorpurchaseviewmodel item)
        {
            lastInsertedProductInCart = item;
            foreach (productsaleorpurchaseviewmodel oldItem in cart)
            {
                if (item.id == oldItem.id)
                {
                    oldItem.quantity += 1;
                    oldItem.total = oldItem.quantity * oldItem.price;
                    refreshCartAndTotal();
                    return;
                }
            }
            item.quantity = 1;
            cart.Add(item);
            refreshCartAndTotal();
        }

        private void removeItemFromCart_btn_click(object sender, RoutedEventArgs e)
        {
            productsaleorpurchaseviewmodel obj = ((FrameworkElement)sender).DataContext as productsaleorpurchaseviewmodel;
            cart_dg.SelectedItem = null;
            lastInsertedProductInCart = null;
            foreach (productsaleorpurchaseviewmodel oldItem in cart)
            {
                if (obj.id == oldItem.id)
                {
                    cart.Remove(obj);
                    refreshCartAndTotal();
                    break;
                }
            }
        }
        private async void cart_dg_roweditending(object sender, DataGridRowEditEndingEventArgs e)
        {
            productsaleorpurchaseviewmodel item = e.Row.Item as productsaleorpurchaseviewmodel;
            if (item != null)
            {
                foreach (productsaleorpurchaseviewmodel oldItem in cart)
                {
                    if (item.id == oldItem.id)
                    {
                        oldItem.total = oldItem.quantity * oldItem.price;
                        break;
                    }
                }
                await Task.Delay(TimeSpan.FromMilliseconds(5));
                refreshCartAndTotal();
            }
        }

        private void refreshCartAndTotal()
        {
            try
            {
                cart_dg.SelectedItem = lastInsertedProductInCart;
                cart_dg.Items.Refresh();
                double totalBill1 = 0;
                foreach (productsaleorpurchaseviewmodel item1 in cart)
                {
                    totalBill1 += item1.total;
                }
                total_label.Content = totalBill1;
            }
            catch (Exception ex)
            {
                otherutils.notify("Info", "Update may not be applied", 10000);
                Console.WriteLine(ex);
            }
        }

        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_Search.Text != "")
            {
                string s = tb_Search.Text;
                List<productsaleorpurchaseviewmodel> productList = mappedproducts.Where(a => a.name.ToLower().Contains(s.ToLower())).Take(6).ToList();
                lv_SearchFoodItem.ItemsSource = null;
                lv_SearchFoodItem.ItemsSource = productList;
                lv_SearchFoodItem.Visibility = Visibility.Visible;
                lv_SearchFoodItem.SelectedIndex = 0;
                lv_SearchFoodItem.Visibility = Visibility.Visible;
            }
            else { lv_SearchFoodItem.Visibility = Visibility.Hidden; }
        }

        private void tb_Search_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                int index = lv_SearchFoodItem.SelectedIndex + 1;
                if (index < lv_SearchFoodItem.Items.Count)
                {
                    lv_SearchFoodItem.SelectedIndex = index;
                }
                return;
            }
            else if (e.Key == Key.Up)
            {
                int index = lv_SearchFoodItem.SelectedIndex - 1;
                if (index > -1)
                {
                    lv_SearchFoodItem.SelectedIndex = index;
                }
                return;
            }
            else if (e.Key == Key.Enter)
            {
                if (lv_SearchFoodItem.SelectedItem != null)
                {
                    productsaleorpurchaseviewmodel item = (productsaleorpurchaseviewmodel)lv_SearchFoodItem.SelectedItem;
                    addItem_To_cart(item);
                    tb_Search.Text = "";
                    lv_SearchFoodItem.Visibility = Visibility.Hidden;
                }
            }
            else if (e.Key == Key.End)
            {
                doneSale();
            }

        }

        private void btn_doSale(object sender, RoutedEventArgs e)
        {
            doneSale();
        }
        private void tb_Search_Barcode_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tb_Search_Barcode.Text != "")
                {
                    productsaleorpurchaseviewmodel product = mappedproducts.Where(a => a.barcode == tb_Search_Barcode.Text).FirstOrDefault();
                    if (product != null)
                    {
                        addItem_To_cart(product);
                    }
                    tb_Search_Barcode.Text = "";
                }
                else
                {
                    if (lastInsertedProductInCart != null)
                    {
                        addItem_To_cart(lastInsertedProductInCart);
                    }
                }
            }

        }

        private void BarcodeMode_cb_Checked(object sender, RoutedEventArgs e)
        {
            tb_Search.Text = "";
            tb_Search.Visibility = Visibility.Hidden;
            tb_Search_Barcode.Text = "";
            lv_SearchFoodItem.Visibility = Visibility.Hidden;
            tb_Search_Barcode.Visibility = Visibility.Visible;
            tb_Search_Barcode.Focus();

        }

        private void BarcodeMode_cb_UnChecked(object sender, RoutedEventArgs e)
        {
            tb_Search.Text = "";
            tb_Search.Visibility = Visibility.Visible;
            tb_Search.Focus();
            tb_Search_Barcode.Text = "";
            tb_Search_Barcode.Visibility = Visibility.Hidden;
        }

        void doneSale()
        {
            try
            {
                if (cart.Count == 0)
                {
                    MessageBox.Show("Add products to cart", "Information");
                    return;
                }

                if (customer_combobox.SelectedItem == null)
                {
                    MessageBox.Show("Please select customer", "Information");
                    return;
                }

                if (paying_textbox.Text == "")
                {
                    MessageBox.Show("Please enter payment, 0 for no payment", "Information");
                    return;
                }

                var totalbill = cart.Sum(a => a.total);
                double totalpayment = Convert.ToDouble(paying_textbox.Text);

                if (totalpayment > totalbill)
                {
                    MessageBox.Show("Paymet can not be greater than bill", "Information");
                    return;
                }

                if ((bool)ledger_checkbox.IsChecked)
                {

                    if (totalbill == totalpayment)
                    {
                        MessageBox.Show("Ledger not set properly", "Information");
                        return;
                    }
                }
                var customer = customer_combobox.SelectedItem as data.dapper.user;

                saleutils.newsale(cart, totalpayment, customer.id);

                MessageBox.Show("Ammount " + totalbill, "Success");
                Close();
                new pos().Show();
            }
            catch (Exception ex)
            {
            }

        }
    }

}
