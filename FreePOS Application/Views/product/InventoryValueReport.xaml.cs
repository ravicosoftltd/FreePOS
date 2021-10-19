
using FreePOS.data;
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
using Telerik.Windows.Data;

namespace FreePOS.Views.product
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class InventoryValueReport : Window
    {
        productrepo productrepo = new productrepo();
        public InventoryValueReport()
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
                var products = productrepo.get();
                var list = from p in products
                           select new
                           {
                               id = p.id,
                               name = p.name,
                               saleprice = p.saleprice,
                               purchaseprice = p.purchaseprice,
                               discount = p.discount,
                               carrycost = p.carrycost,
                               barcode = p.barcode,
                               quantity = p.quantity,
                               category = p.category,
                               salevalue = p.saleprice * p.quantity,
                               salevaluewdiscount = (p.saleprice - p.discount) * p.quantity,
                               purchasevalue = p.purchaseprice * p.quantity,
                               purchasevaluewcarrycost = (p.purchaseprice + p.carrycost) * p.quantity
                           };

                dg.ItemsSource = null;
                foreach (var item in list)
                {
                    dg.Items.Add(item);
                }
                
            }
            else
            {
                var searchBy = (searchTypeText == "Category") ? "category" : "name";
                var products = productrepo.search(query_tb.Text, searchBy, null);
                var list = from p in products
                           select new
                           {
                               id = p.id,
                               name = p.name,
                               saleprice = p.saleprice,
                               purchaseprice = p.purchaseprice,
                               discount = p.discount,
                               carrycost = p.carrycost,
                               barcode = p.barcode,
                               quantity = p.quantity,
                               category = p.category,
                               salevalue = p.saleprice * p.quantity,
                               salevaluewdiscount = (p.saleprice - p.discount) * p.quantity,
                               purchasevalue = p.purchaseprice * p.quantity,
                               purchasevaluewcarrycost = (p.purchaseprice + p.carrycost) * p.quantity
                           };

                dg.ItemsSource = null;
                foreach (var item in list)
                {
                    dg.Items.Add(item);
                }
            }
            UpdateLayout();

        }
    }
}
