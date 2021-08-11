

using BusinessBook.data;
using BusinessBook.data.dapper;
using BusinessBook.data.viewmodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBook.bll
{
    public class saleutils
    {
        public static void possale(List<productsaleorpurchaseviewmodel> saleList,double change, data.dapper.user customer, int numberofrecipiets, bool printCustomerInfoOnReciept)
        {
            var totalpayment = saleList.Sum(a => a.total);
            var customerid = 0;
            var customeraddress = "";
            if (customer != null) 
            {
                customerid = customer.id;
                customeraddress = customer.address + " " + customer.phone + " " + customer.phone2;
            }
            var saleid = financeutils.insertSaleTransactions("pos sale", saleList, totalpayment, customerid);
            for (int i = 0; i < numberofrecipiets; i++)
            {
                printing.printSaleReceipt(saleid, saleList, totalpayment,totalpayment+change, change, printCustomerInfoOnReciept, customeraddress);

            }

            Task.Run(() => {
                insertSellingProductsInDatabase(saleList, saleid);
                inventoryutils.updateInventoryonsale(saleList, saleid);
            });
        }
        public static void newsale(List<productsaleorpurchaseviewmodel> saleList, double totalpayment, int customerId)
        {
            var saleid = financeutils.insertSaleTransactions("sale", saleList, totalpayment, customerId);
            Task.Run(() => {
                insertSellingProductsInDatabase(saleList, saleid);
                inventoryutils.updateInventoryonsale(saleList, saleid);
            });
        }
        private static void insertSellingProductsInDatabase(List<productsaleorpurchaseviewmodel> saleList, int saleid)
        {
            var salepurchaseproducrepo = new productsalepurchaserepo();
            foreach (productsaleorpurchaseviewmodel item in saleList)
            {
                data.dapper.productsalepurchase saleItem = new data.dapper.productsalepurchase();
                saleItem.price = item.price;
                saleItem.quantity = item.quantity;
                saleItem.total = item.total;
                saleItem.fk_product_in_productsalepurchase = item.id;
                saleItem.fk_financetransaction_in_productsalepurchase = saleid;
                salepurchaseproducrepo.save(saleItem);
            }
        }
        public static void printDuplicateRecipt(int saleid)
        {
            var financetransactionrepo = new financetransactionrepo();
            var userrepo = new userrepo();
            var productrepo = new productrepo();
            var productsalepurchaserepo = new productsalepurchaserepo();
            var ft = financetransactionrepo.get(saleid);
            data.dapper.user customer = null;
            if (ft.fk_user_targetto_in_financetransaction != null) {
                customer = userrepo.get((int)ft.fk_user_targetto_in_financetransaction);
            }
           // var soldproducts = db.productsalepurchase.Where(a => a.fk_financetransaction_in_productsalepurchase == saleid).ToList();
            var soldproducts = productsalepurchaserepo.getmultiplebytransactionid(saleid);

            float totalbill = 0;
            var salelist = new List<productsaleorpurchaseviewmodel>();

            foreach (var item in soldproducts)
            {
                totalbill = totalbill + (float)(item.price * item.quantity);
                //var dbproduct = db.product.Find(item.fk_product_in_productsalepurchase);
                var dbproduct = productrepo.get((int)item.fk_product_in_productsalepurchase);
                
                var p = new productsaleorpurchaseviewmodel();
                p.id = dbproduct.id;
                p.name = dbproduct.name;
                p.price = (double)item.price;
                p.quantity = (double)item.quantity;
                p.total = (double)item.total;
            };

            //int salesId, List< ItemOrDealSaleModel > list, int totalBill,int remaining, int saleType,string customerAddress
            string customerAddress ="";
            if (customer != null)
            {
                customerAddress = customer.address + " " + customer.phone;
            }
            printing.printSaleReceipt(saleid, salelist, (int)totalbill, (int)totalbill, 0, false, customerAddress);

        }
    }
}
