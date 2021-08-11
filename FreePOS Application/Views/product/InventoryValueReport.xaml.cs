
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
        public InventoryValueReport()
        {
            InitializeComponent();
            initFormOperations();
        }
        private void initFormOperations()
        {
            var productrepo = new productrepo().get();

            var invenotryreport = from p in productrepo
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
                                      salevalue = p.saleprice*p.quantity,
                                      salevaluewdiscount = (p.saleprice - p.discount) * p.quantity,
                                      purchasevalue = p.purchaseprice * p.quantity,
                                      purchasevaluewcarrycost = (p.purchaseprice + p.carrycost) * p.quantity
                                  };

            dg.ItemsSource = null;
            dg.ItemsSource = invenotryreport;
            
            UpdateLayout();
        }
    }
}
