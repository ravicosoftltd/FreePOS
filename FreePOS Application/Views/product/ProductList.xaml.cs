
using FreePOS.bll;
using FreePOS.data;
using FreePOS.data.dapper;
using Newtonsoft.Json;
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
using Telerik.Windows.Controls;

namespace FreePOS.Views.product
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        List<data.dapper.product> items;
        productrepo productrepo = new productrepo();
        public ProductList()
        {
            InitializeComponent();
        }
        private void Btn_Search_Transactions_Click(object sender, RoutedEventArgs e)
        {
            var searchType = searchType_cb.SelectedValue as ComboBoxItem;
            var searchTypeText = searchType.Content as string;
            if (searchTypeText == "Product" && query_tb.Text == "")
            {
                return;
            }
            dg.ItemsSource = null;
            dg.Items.Clear();
            dg.Items.Refresh();
            if (searchTypeText == "All")
            {
                var list = productrepo.get();
                items = list;
                dg.ItemsSource = null;
                foreach (var item in list)
                {
                    dg.Items.Add(item);
                }

            }
            else
            {
                var searchBy = (searchTypeText == "Category") ? "category" : "name";
                var list = productrepo.search(query_tb.Text, searchBy, null);
                items = list;

                dg.ItemsSource = null;
                foreach (var item in list)
                {
                    dg.Items.Add(item);
                }
            }
            UpdateLayout();

        }
        public void edit(object sender, RoutedEventArgs e)
        {
            data.dapper.product obj = ((FrameworkElement)sender).DataContext as data.dapper.product;
            new ProductAdd(obj.id).Show();
        }
        public void inventorylog(object sender, RoutedEventArgs e)
        {
            data.dapper.product obj = ((FrameworkElement)sender).DataContext as data.dapper.product;
            new Views.product.inventorylog(obj.id).Show();
        }
        private void dg_roweditended(object sender, GridViewRowEditEndedEventArgs e)
        {
            data.dapper.product item = e.Row.Item as data.dapper.product;
            if (item != null)
            {
                var originalProduct = new productrepo().get(item.id);
                var originalProduct2 = new productrepo().get(item.id);
                var isEqual = JsonConvert.SerializeObject(originalProduct) == JsonConvert.SerializeObject(item);
                if (isEqual) {
                    return;
                }
                try
                {
                    if (originalProduct != null)
                    {
                        if (item.name != "")
                        {
                            originalProduct.name = item.name;
                            originalProduct.barcode = item.barcode;
                            originalProduct.quantity = item.quantity;
                            originalProduct.category = item.category;
                            originalProduct.purchaseprice = item.purchaseprice;
                            originalProduct.carrycost = item.carrycost;
                            originalProduct.saleprice = item.saleprice;
                            originalProduct.discount = item.discount;
                            originalProduct.saleactive = item.saleactive;
                            originalProduct.purchaseactive = item.purchaseactive;
                            var updateResult = new productrepo().update(originalProduct);
                            if (updateResult == true)
                            {
                                otherutils.notify("Info", "Product updated", 10000);

                                inventoryutils.updateinventorylogonproductupdate(originalProduct.id, (double)item.quantity, (double)originalProduct.quantity);
                            }
                            else
                            {
                                otherutils.notify("Info", "Product not updated, barcode already exists", 10000);
                                var itemFromGrid = items.SingleOrDefault(x => x.id == item.id);
                                itemFromGrid.barcode = originalProduct2.barcode;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    otherutils.notify("Info", "Product is not updated", 10000);
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
