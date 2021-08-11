
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
    public class financeutils
    {
        public static int insertSaleTransactions(string accountname,List<productsaleorpurchaseviewmodel> saleList,double totalpayment, int targetuserid)
        {
            var loggedinuserid = userutils.loggedinuserd.id;
            //var db = new dbctx();
            productrepo productrepo = new productrepo();
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financetransactionrepo financetransactionrepo = new financetransactionrepo();

            //List<financeaccount> accounts = db.financeaccount.ToList();
            List<data.dapper.financeaccount> accounts = financeaccountrepo.get();
            var saleaccountid = accounts.Where(a => a.name == accountname).FirstOrDefault().id;
            var discountaccountid = accounts.Where(a => a.name == "discount").FirstOrDefault().id;
            var cashaccountid = accounts.Where(a => a.name == "cash").FirstOrDefault().id;
            var accountreciveableaccountid = accounts.Where(a => a.name == "account receivable").FirstOrDefault().id;
            var cgsaccountid = accounts.Where(a => a.name == "cgs").FirstOrDefault().id;
            var inventoryaccountid = accounts.Where(a => a.name == "inventory").FirstOrDefault().id;
      
            double totalbill = 0;
            double costofgoodssold = 0;
            foreach (var item in saleList)
            {
                totalbill += (item.price * item.quantity);
                //product p = db.product.Find(item.id);
                data.dapper.product p = productrepo.get(item.id);
                double productcarrycost = 0;
                if (p.carrycost != null) {
                    productcarrycost = (double)p.carrycost;
                }
                double productpurchaseprice = 0;
                if (p.purchaseprice != null)
                {
                    productpurchaseprice = (double)p.purchaseprice;
                }
                costofgoodssold += ((double)((productpurchaseprice + productcarrycost) * item.quantity));
            }

            //New Sale Transaction
            //financetransaction ftsale = new financetransaction();
            data.dapper.financetransaction ftsale = new data.dapper.financetransaction();
            ftsale.amount = -totalbill;
            
            ftsale.date = DateTime.Now;
            ftsale.status = "posted";
            ftsale.fk_user_createdby_in_financetransaction = loggedinuserid;
            if (targetuserid != 0)
            {
                ftsale.fk_user_targetto_in_financetransaction = targetuserid;
            }
            ftsale.fk_financeaccount_in_financetransaction = saleaccountid;
            financetransactionrepo.save(ftsale);
            //db.financetransaction.Add(ftsale);
            //db.SaveChanges();
            
            //New Payment Transaction against sale . if customer is paying some money
            if (totalpayment > 0)
            {
                //financetransaction ftpayment = new financetransaction();
                data.dapper.financetransaction ftpayment = new data.dapper.financetransaction();
                ftpayment.amount = totalpayment;
                ftpayment.date = DateTime.Now;
                ftpayment.status = "posted";
                ftpayment.fk_user_createdby_in_financetransaction = loggedinuserid;
                if (targetuserid != 0)
                {
                    ftpayment.fk_user_targetto_in_financetransaction = targetuserid;
                }
                ftpayment.fk_financeaccount_in_financetransaction = cashaccountid;
                //db.financetransaction.Add(ftpayment);
                //db.SaveChanges();
                financetransactionrepo.save(ftpayment);
            }


            // New AR Transaction if Ledger is true
            if (totalpayment!=totalbill)
            {
                //financetransaction ftar = new financetransaction();
                data.dapper.financetransaction ftar = new data.dapper.financetransaction();
                ftar.amount = totalbill - totalpayment;
                
                ftar.date = DateTime.Now;
                ftar.status = "posted";
                ftar.fk_user_createdby_in_financetransaction = loggedinuserid;
                if (targetuserid != 0)
                {
                    ftar.fk_user_targetto_in_financetransaction = targetuserid;
                }
                ftar.fk_financeaccount_in_financetransaction = accountreciveableaccountid;
                //db.financetransaction.Add(ftar);
                //db.SaveChanges();
                financetransactionrepo.save(ftar);
            }

            // new cost of goods transaction against sale
            //financetransaction ftcgs = new financetransaction();
            data.dapper.financetransaction ftcgs = new data.dapper.financetransaction();
            ftcgs.amount = costofgoodssold;
            ftcgs.fk_financeaccount_in_financetransaction = cgsaccountid;
            ftcgs.date = DateTime.Now;
            ftcgs.status = "posted";
            ftcgs.fk_user_createdby_in_financetransaction = loggedinuserid;
            //db.financetransaction.Add(ftcgs);
            //db.SaveChanges();
            financetransactionrepo.save(ftcgs);


            // new inventory detct transaction against against sale
            //financetransaction ftid = new financetransaction();
            data.dapper.financetransaction ftid = new data.dapper.financetransaction();
            ftid.name = "--inventory--on--sale--";
            ftid.amount = -costofgoodssold;
            ftid.fk_financeaccount_in_financetransaction = inventoryaccountid;
            ftid.date = DateTime.Now;
            ftid.status = "posted";
            ftid.fk_user_createdby_in_financetransaction = loggedinuserid;
            //db.financetransaction.Add(ftid);
            //db.SaveChanges();
            financetransactionrepo.save(ftid);


            return ftsale.id;
            
        }

        public static int insertPurchaseTransactions(List<productsaleorpurchaseviewmodel> purchaseList, double totalpayment, int targetuserid)
        {
            var loggedinuserid = userutils.loggedinuserd.id;
            //var db = new dbctx();

            productrepo productrepo = new productrepo();
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financetransactionrepo financetransactionrepo = new financetransactionrepo();

            //List<financeaccount> accounts = db.financeaccount.ToList();
            List<data.dapper.financeaccount> accounts = financeaccountrepo.get();

            //List<financeaccount> accounts = db.financeaccount.ToList();
            var discountaccountid = accounts.Where(a => a.name == "discount").FirstOrDefault().id;
            var cashaccountid = accounts.Where(a => a.name == "cash").FirstOrDefault().id;
            var accountreciveableaccountid = accounts.Where(a => a.name == "account receivable").FirstOrDefault().id;
            var accountpayableableaccountid = accounts.Where(a => a.name == "account payable").FirstOrDefault().id;
            var cgsaccountid = accounts.Where(a => a.name == "cgs").FirstOrDefault().id;
            var inventoryaccountid = accounts.Where(a => a.name == "inventory").FirstOrDefault().id;

            double totalbill = 0;
            foreach (var item in purchaseList)
            {
                totalbill += (item.price * item.quantity);
            }


            //New purchase Transaction
            //financetransaction ftpurchase = new financetransaction();
            data.dapper.financetransaction ftpurchase = new data.dapper.financetransaction();
            ftpurchase.amount = totalbill;
            ftpurchase.name = "--inventory--on--purchase--";
            ftpurchase.fk_financeaccount_in_financetransaction = inventoryaccountid;
            ftpurchase.fk_user_targetto_in_financetransaction = targetuserid;
            ftpurchase.date = DateTime.Now;
            ftpurchase.status = "posted";
            ftpurchase.fk_user_createdby_in_financetransaction = loggedinuserid;
            //db.financetransaction.Add(ftpurchase);
            //db.SaveChanges();
            financetransactionrepo.save(ftpurchase);

            //New Payment Transaction against sale . if we are paying some money
            if (totalpayment > 0)
            {
                data.dapper.financetransaction ftpayment = new data.dapper.financetransaction();
                ftpayment.amount = -(totalpayment);
                ftpayment.date = DateTime.Now;
                ftpayment.status = "posted";
                ftpayment.fk_user_createdby_in_financetransaction = loggedinuserid;
                ftpayment.fk_user_targetto_in_financetransaction = targetuserid;
                ftpayment.fk_financeaccount_in_financetransaction = cashaccountid;
                //db.financetransaction.Add(ftpayment);
                //db.SaveChanges();
                financetransactionrepo.save(ftpayment);
            }


            // New AP Transaction if TotalRemaining has ammount
            if ( totalbill!= totalpayment)
            {
                data.dapper.financetransaction ftap = new data.dapper.financetransaction();
                ftap.amount = -(totalbill - totalpayment);
                ftap.date = DateTime.Now;
                ftap.status = "Posted";
                ftap.fk_user_createdby_in_financetransaction = loggedinuserid;
                ftap.fk_user_targetto_in_financetransaction = targetuserid;
                ftap.fk_financeaccount_in_financetransaction = accountpayableableaccountid;
                //db.financetransaction.Add(ftap);
                //db.SaveChanges();
                financetransactionrepo.save(ftap);
            }
            return ftpurchase.id;

        }

        public static void insertCustomerPayment(int accountid, double amount, int targetid) 
        {
            var loggedinuserid = userutils.loggedinuserd.id;
            //var db = new dbctx();

            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financetransactionrepo financetransactionrepo = new financetransactionrepo();
            List<data.dapper.financeaccount> accounts = financeaccountrepo.get();
            //List<financeaccount> accounts = db.financeaccount.ToList();
            var accountreciveableaccountid = accounts.Where(a => a.name == "account receivable").FirstOrDefault().id;


            data.dapper.financetransaction ftcash = new data.dapper.financetransaction();
            ftcash.amount = amount;
            ftcash.date = DateTime.Now;
            ftcash.status = "posted";
            ftcash.fk_user_createdby_in_financetransaction = loggedinuserid;
            ftcash.fk_user_targetto_in_financetransaction = targetid;
            ftcash.fk_financeaccount_in_financetransaction = accountid;
            //db.financetransaction.Add(ftcash);
            //db.SaveChanges();
            financetransactionrepo.save(ftcash);


            data.dapper.financetransaction ftar = new data.dapper.financetransaction();
            ftar.amount = -amount;
            ftar.date = DateTime.Now;
            ftar.status = "posted";
            ftar.fk_user_createdby_in_financetransaction = loggedinuserid;
            ftar.fk_user_targetto_in_financetransaction = targetid;
            ftar.fk_financeaccount_in_financetransaction = accountreciveableaccountid;
            //db.financetransaction.Add(ftar);
            //db.SaveChanges();
            financetransactionrepo.save(ftar);
        }

        public static void insertVendorPayment(int accountid, double amount, int targetid)
        {
            var loggedinuserid = userutils.loggedinuserd.id;
            //var db = new dbctx();
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financetransactionrepo financetransactionrepo = new financetransactionrepo();
            List<data.dapper.financeaccount> accounts = financeaccountrepo.get();
            //List<financeaccount> accounts = db.financeaccount.ToList();
            var accountpayableableaccountid = accounts.Where(a => a.name == "account payable").FirstOrDefault().id; ;


            data.dapper.financetransaction ftcash = new data.dapper.financetransaction();
            ftcash.amount = -amount;
            ftcash.date = DateTime.Now;
            ftcash.status = "posted";
            ftcash.fk_user_createdby_in_financetransaction = loggedinuserid;
            ftcash.fk_user_targetto_in_financetransaction = targetid;
            ftcash.fk_financeaccount_in_financetransaction = accountid;
            //db.financetransaction.Add(ftcash);
            //db.SaveChanges();
            financetransactionrepo.save(ftcash);


            data.dapper.financetransaction ftar = new data.dapper.financetransaction();
            ftar.amount = amount;
            ftar.date = DateTime.Now;
            ftar.status = "posted";
            ftar.fk_user_createdby_in_financetransaction = loggedinuserid;
            ftar.fk_user_targetto_in_financetransaction = targetid;
            ftar.fk_financeaccount_in_financetransaction = accountpayableableaccountid;
            //db.financetransaction.Add(ftar);
            //db.SaveChanges();
            financetransactionrepo.save(ftar);
        }

        public static void insertexpence(int payingaccount,  int expenceaccount, double amount)
        {
            var loggedinuserid = userutils.loggedinuserd.id;
            //var db = new dbctx();
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financetransactionrepo financetransactionrepo = new financetransactionrepo();
            List<data.dapper.financeaccount> accounts = financeaccountrepo.get();
            data.dapper.financetransaction ftexpence = new data.dapper.financetransaction();
            ftexpence.amount = amount;
            ftexpence.fk_financeaccount_in_financetransaction = expenceaccount;
            ftexpence.date = DateTime.Now;
            ftexpence.status = "posted";
            ftexpence.fk_user_createdby_in_financetransaction = loggedinuserid;
            //db.financetransaction.Add(ftexpence);
            //db.SaveChanges();
            financetransactionrepo.save(ftexpence);

            data.dapper.financetransaction ftasset = new data.dapper.financetransaction();
            ftasset.amount = -amount;
            ftasset.fk_financeaccount_in_financetransaction = payingaccount;
            ftasset.date = DateTime.Now;
            ftasset.status = "posted";
            ftasset.fk_user_createdby_in_financetransaction = loggedinuserid;
            //db.financetransaction.Add(ftasset);
            //db.SaveChanges();
            financetransactionrepo.save(ftasset);
        }

        public static void inserttransaction(int fromaccount, int toaccount, double amount)
        {
            var loggedinuserid = userutils.loggedinuserd.id;
            financeaccountrepo financeaccountrepo = new financeaccountrepo();
            financetransactionrepo financetransactionrepo = new financetransactionrepo();
            List<data.dapper.financeaccount> accounts = financeaccountrepo.get();
            //var db = new dbctx();

            data.dapper.financetransaction ftexpence = new data.dapper.financetransaction();
            ftexpence.amount = -amount;
            ftexpence.fk_financeaccount_in_financetransaction = fromaccount;
            ftexpence.date = DateTime.Now;
            ftexpence.status = "posted";
            ftexpence.fk_user_createdby_in_financetransaction = loggedinuserid;
            //db.financetransaction.Add(ftexpence);
            //db.SaveChanges();
            financetransactionrepo.save(ftexpence);

            data.dapper.financetransaction ftasset = new data.dapper.financetransaction();
            ftasset.amount = amount;
            ftasset.fk_financeaccount_in_financetransaction = toaccount;
            ftasset.date = DateTime.Now;
            ftasset.status = "posted";
            ftasset.fk_user_createdby_in_financetransaction = loggedinuserid;
            //db.financetransaction.Add(ftasset);
            //db.SaveChanges();
            financetransactionrepo.save(ftasset);
        }

        public static void getaccountsbalances()
        {
            //var db = new dbctx();
            //financeaccountrepo financeaccountrepo = new financeaccountrepo();
            //financetransactionrepo financetransactionrepo = new financetransactionrepo();
            //List<data.dapper.financeaccount> accounts = financeaccountrepo.get();



            //List<data.financeaccount> list = db.financeaccount.Include(a => a.financetransaction).ToList();
            //var data = from d in list
            //           select new
            //           {
            //               id = d.id,
            //               name = d.name,
            //               type = d.type,
            //               today = (float)d.financetransaction.Where(a => (a.date >= DateTime.Now.Date && a.date <= DateTime.Now.Date.AddDays(1).AddTicks(-1))).Sum(a => a.amount),
            //               month = (float)d.financetransaction.Where(a => (a.date >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) && a.date <= DateTime.Now.Date.AddMonths(1).AddDays(-1))).Sum(a => a.amount),
            //               total = (float)d.financetransaction.Sum(a => a.amount)
            //           };

            //List<Finance_Account_SumAllTransaction> list1 = new List<Finance_Account_SumAllTransaction>();
            //foreach (FinanceAccount item in list)
            //{
            //    Finance_Account_SumAllTransaction i = new Finance_Account_SumAllTransaction();
            //    i.AccountId = item.Id;
            //    i.AccountName = item.Name;
            //    i.AccountType = item.FinanceAccountType;
            //    i.AccountAmountToday = (float)item.FinanceTransaction.Where(a=>(a.DateTime>=DateTime.Now.Date && a.DateTime <= DateTime.Now.Date.AddDays(1).AddTicks(-1))).Sum(a => a.Amount);
            //    i.AccountAmountMonth = (float)item.FinanceTransaction.Where(a => (a.DateTime >= new DateTime(DateTime.Now.Year,DateTime.Now.Month,1) && a.DateTime <= DateTime.Now.Date.AddMonths(1).AddDays(-1))).Sum(a => a.Amount);
            //    i.AccountAmountTotal = (float)item.FinanceTransaction.Sum(a => a.Amount);
            //    list1.Add(i);
            //}
            // return data.ToList();
        }

        public static void finance_transaction_getAll_groupby_Month(string FinanceAccount)
        {
        //    var db = new dbctx();
        //    financeaccountrepo financeaccountrepo = new financeaccountrepo();
        //    financetransactionrepo financetransactionrepo = new financetransactionrepo();
        //    List<data.dapper.financeaccount> accounts = financeaccountrepo.get();

        //    List<data.financetransaction> list;
        //    list = db.financetransaction.Where(a => a.financeaccount.name == FinanceAccount).Include(a => a.financeaccount).ToList();
        //    // var groups = list.GroupBy(x => new { Month=x.DateTime.Value.Month, Year = x.DateTime.Value.Year });
        //    var trendData =
        //     (from d in db.financetransaction.Where(a => a.financeaccount.name == FinanceAccount)
        //      group d by new
        //      {
        //          Year = d.date.Value.Year,
        //          Month = d.date.Value.Month
        //      } into g
        //      select new
        //      {
        //          Year = g.Key.Year,
        //          Month = g.Key.Month,
        //          Total = g.Sum(x => x.amount)
        //      }
        //).AsEnumerable()
        // .Select(g => new
        // {
        //     Period = g.Year + "-" + g.Month,
        //     Total = g.Total
        // });
        //    return trendData;

        }

    }
}
