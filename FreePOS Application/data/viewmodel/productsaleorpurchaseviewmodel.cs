using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBook.data.viewmodel
{
    public class productsaleorpurchaseviewmodel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string barcode { set; get; }
        public double price { set; get; }
        public double quantity { set; get; }
        public double total { set; get; }
    }
}
