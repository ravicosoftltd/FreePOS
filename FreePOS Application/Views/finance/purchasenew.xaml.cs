
using FreePOS.bll;
using FreePOS.data.dapper;
using FreePOS.data.viewmodel;
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
    /// Interaction logic for purchasenew.xaml
    /// </summary>
    public partial class purchasenew : Window
    {
        List<productsaleorpurchaseviewmodel> mappedproducts;
        List<productsaleorpurchaseviewmodel> purchaselist = new List<productsaleorpurchaseviewmodel>();
        productrepo productrepo = new productrepo();
        userrepo userrepo = new userrepo();
        public purchasenew()
        {
            InitializeComponent();
            initFormOperations();
        }

        void initFormOperations()
        {
            var products = this.productrepo.get();
            mappedproducts = productutils.mapproducttoproductpurchasemodel(products);
            tb_Search.Focus();
            var vendors = userrepo.getbywherein("role", new object[] { "vendor" });
            vendor_combobox.ItemsSource = vendors;
            vendor_combobox.DisplayMemberPath = "name";
            vendor_combobox.SelectedValuePath = "id";
            
        }

        void addItem_To_purchase(productsaleorpurchaseviewmodel item)
        {
            foreach (productsaleorpurchaseviewmodel oldItem in purchaselist)
            {
                if (item.id == oldItem.id)
                {
                    oldItem.quantity += 1;
                    oldItem.total = oldItem.quantity * oldItem.price;
                    dg.Items.Clear();
                    double totalBill1 = 0;
                    foreach (productsaleorpurchaseviewmodel item1 in purchaselist)
                    {
                        totalBill1 += item1.total;
                        dg.Items.Add(item1);
                    }
                    total_label.Content = totalBill1;
                    return;
                }
            }
            purchaselist.Add(item);
            dg.Items.Clear();
            double totalBill = 0;
            foreach (productsaleorpurchaseviewmodel item1 in purchaselist)
            {
                totalBill += item1.total;
                dg.Items.Add(item1);
            }
            total_label.Content = totalBill;
        }

        private void btn_AddQuantity(object sender, RoutedEventArgs e)
        {
            productsaleorpurchaseviewmodel obj = ((FrameworkElement)sender).DataContext as productsaleorpurchaseviewmodel;
            addItem_To_purchase(obj);
        }

        private void btn_RemoveQuantity(object sender, RoutedEventArgs e)
        {
            productsaleorpurchaseviewmodel obj = ((FrameworkElement)sender).DataContext as productsaleorpurchaseviewmodel;

            foreach (productsaleorpurchaseviewmodel oldItem in purchaselist)
            {
                if (obj.id == oldItem.id)
                {
                    if (oldItem.quantity > 1)
                    {
                        oldItem.quantity -= 1;
                        oldItem.total = oldItem.quantity * oldItem.price;
                        dg.Items.Clear();
                        double totalBill1 = 0;
                        foreach (productsaleorpurchaseviewmodel item1 in purchaselist)
                        {
                            totalBill1 += item1.total;
                            dg.Items.Add(item1);
                        }
                        total_label.Content = totalBill1;
                        return;
                    }
                    else
                    {
                        purchaselist.Remove(obj);
                        dg.Items.Clear();
                        double totalBill1 = 0;
                        foreach (productsaleorpurchaseviewmodel item1 in purchaselist)
                        {
                            totalBill1 += item1.total;
                            dg.Items.Add(item1);
                        }
                        total_label.Content = totalBill1;
                        return;
                    }
                }
            }
        }

        private void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_Search.Text != "")
            {
                string s = tb_Search.Text;
                List<productsaleorpurchaseviewmodel> productList = mappedproducts.Where(a => a.name.ToLower().Contains(s.ToLower())).ToList();
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
                lv_SearchFoodItem.SelectedIndex = index;
                return;
            }
            if (e.Key == Key.Up)
            {
                int index = lv_SearchFoodItem.SelectedIndex - 1;
                lv_SearchFoodItem.SelectedIndex = index;
                return;
            }
            if (e.Key == Key.Enter)
            {
                if (lv_SearchFoodItem.SelectedItem != null)
                {
                    productsaleorpurchaseviewmodel item = (productsaleorpurchaseviewmodel)lv_SearchFoodItem.SelectedItem;
                    addItem_To_purchase(item);
                    tb_Search.Text = "";
                    lv_SearchFoodItem.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btn_doPurchase(object sender, RoutedEventArgs e)
        {
            donePurchase();
        }

        void donePurchase()
        {

            try 
            {
                
                if (purchaselist.Count == 0)
                {
                    MessageBox.Show("Add products to cart", "Information");
                    return;
                }

                var totalbill = purchaselist.Sum(a => a.total);
                

                if (paying_textbox.Text == "")
                {
                    MessageBox.Show("Please Enter payment", "Information");
                    return;
                }
                var totalpayment = Convert.ToDouble(paying_textbox.Text);
                if (!(bool)ledger_checkbox.IsChecked)
                {
                    if (totalbill != totalpayment)
                    {
                        MessageBox.Show("Ledger is not checked", "Information");
                        return;
                    }
                }
                if (vendor_combobox.SelectedItem==null)
                {
                    MessageBox.Show("Please Select vendor", "Information");
                    return;
                }
                var vendor = vendor_combobox.SelectedItem as data.dapper.user;




                purchaseutils.newpurchase(purchaselist, totalpayment, vendor.id);

                MessageBox.Show("Purchase Done::: Total Bill :" + totalbill+"   Total Payment:"+totalpayment, "Success");
                Close();
                new purchasenew().Show();

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please fill all fields", "Information");
                return;
            }
            
            
            
            
        }
    }
}
