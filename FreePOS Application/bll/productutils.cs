using FreePOS.data.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.bll
{
    public class productutils
    {
        public static dynamic mapproducttoproductsalemodel(List<data.dapper.product> products) {
            var mappedList = new List<productsaleorpurchaseviewmodel>();
            foreach (var item in products)
            {
                productsaleorpurchaseviewmodel a = new productsaleorpurchaseviewmodel();
                a.id = item.id;
                a.name = item.name;
                a.barcode = item.barcode;
                a.quantity = 1;
                a.price = 0;
                if (item.saleprice != null) {
                    a.price = (double)item.saleprice;
                }
                if (item.discount != null) {
                    a.price = a.price - (double)item.discount;
                };
                a.total = a.price;
                mappedList.Add(a);
            }
            return mappedList;
        }
        public static dynamic mapproducttoproductpurchasemodel(List<data.dapper.product> products)
        {
            var mappedList = new List<productsaleorpurchaseviewmodel>();
            foreach (data.dapper.product item in products)
            {
                productsaleorpurchaseviewmodel a = new productsaleorpurchaseviewmodel();
                a.id = item.id;
                a.name = item.name;
                a.barcode = item.barcode;
                a.quantity = 1;
                a.price = 0;
                if (item.purchaseprice != null)
                {
                    a.price = (double)item.purchaseprice;
                }
                a.total = a.price;
                mappedList.Add(a);
            }
            return mappedList;
        }

    }
}
