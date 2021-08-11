
using BusinessBook.bll;
using BusinessBook.data;
using BusinessBook.data.dapper;
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

namespace BusinessBook.Views.product
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        List<data.dapper.product> items;
        public ProductList()
        {
            InitializeComponent();
            initFormOperations();
        }
        private void initFormOperations()
        {
            // var db = dbctxsinglton.getInstance();
            var productrepo = new productrepo().get();
            dg_ProductList.ItemsSource = null;
            items = productrepo;
            dg_ProductList.ItemsSource = productrepo;
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
