
using BusinessBook.data;
using BusinessBook.data.dapper;
using BusinessBook.data.viewmodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBook.bll
{
    class purchaseutils
    {
        public static void newpurchase(List<productsaleorpurchaseviewmodel> purchaseList, double totalpayment, int vendorid)
        {
            var purchaseid = financeutils.insertPurchaseTransactions(purchaseList, totalpayment, vendorid);
            Task.Run(() => {
                insertPurchasingProductsInDatabase(purchaseList, purchaseid);
                inventoryutils.updateInventoryonpurchase(purchaseList, purchaseid);
            });
        }
        private static void insertPurchasingProductsInDatabase(List<productsaleorpurchaseviewmodel> purchaseList, int purchaseid)
        {
            var salepurchaseproducrepo = new productsalepurchaserepo();
            foreach (productsaleorpurchaseviewmodel item in purchaseList)
            {
                data.dapper.productsalepurchase saleItem = new data.dapper.productsalepurchase();
                saleItem.price = item.price;
                saleItem.quantity = item.quantity;
                saleItem.total = item.total;
                saleItem.fk_product_in_productsalepurchase = item.id;
                saleItem.fk_financetransaction_in_productsalepurchase = purchaseid;
                salepurchaseproducrepo.save(saleItem);
            }
        }
    }
}
