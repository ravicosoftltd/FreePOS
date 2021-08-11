//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using quickpossecure.Models.dbentities;
//using Microsoft.AspNetCore.Identity;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authorization;

//namespace quickpossecure.Controllers.Api
//{
//    [Produces("application/json")]
//    [Route("api/MainApi")]
//    [Authorize]
//    public class MainApiController : Controller
//    {

//        #region Customer

//        [Route("customer_getall")]
//        public dynamic customer_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            var data = from d in db.Customer.ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           Email = d.Email,
//                           Address = d.Address,
//                           Phone = d.Phone
//                       };
//            return data.ToList();
//        }
//        [Route("customer_insert")]
//        public int customer_insert(Customer c)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Customer.Add(c);
//            db.SaveChanges();
//            return c.Id;
//        }
//        [Route("customer_update")]
//        public int customer_update(Customer c)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            db.SaveChanges();
//            return c.Id;
//        }
//        #endregion customer


//        #region Vendor
//        [Route("vendor_getall")]
//        public dynamic vendor_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            var data = from d in db.Vendor.ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           Email = d.Email,
//                           Address = d.Address,
//                           Phone = d.Phone,
//                       };

//            return data.ToList();
//        }
//        [Route("vendor_insert")]
//        public int vendor_insert(Vendor v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Vendor.Add(v);
//            db.SaveChanges();
//            return v.Id;
//        }
//        [Route("vendor_update")]
//        public int vendor_update(Vendor v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Entry(v).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            db.SaveChanges();
//            return v.Id;
//        }

//        #endregion vendor


//        #region Manufacturer
//        [Route("Manufacturer_getall")]
//        public dynamic Manufacturer_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            var data = from d in db.Manufacturer.ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                       };
//            return data.ToList();
//        }
//        [Route("Manufacturer_insert")]
//        public int Manufacturer_insert(Manufacturer v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Manufacturer.Add(v);
//            db.SaveChanges();
//            return v.Id;
//        }
//        [Route("Manufacturer_update")]
//        public int Manufacturer_update(Manufacturer v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Entry(v).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            db.SaveChanges();
//            return v.Id;
//        }
//        #endregion Manufacturer


//        #region Notification
//        [Route("Notification_getall")]
//        public dynamic Notification_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            var data = from d in db.Notification.ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           CreatedDate = ((DateTime)d.CreatedDate).ToString("dd-MM-yyyy H:mm"),
//                           Title = d.Title,
//                           d.Text,
//                           d.Type,

//                       };
//            return data.Reverse().ToList();
//        }
//        [Route("Notification_insert")]
//        public dynamic Notification_insert(string title, string text, string type)
//        {
//            MyDbContext db = new MyDbContext();
//            Notification n = new Notification();
//            n.CreatedDate = DateTime.Now;
//            n.Title = title;
//            n.Text = text;
//            n.Type = type;
//            db.Notification.Add(n);
//            db.SaveChanges();
//            return Json(new { status = "success" });
//        }
//        [Route("Notification_delete")]
//        public dynamic Notification_delete(int NotificationId)
//        {

//            try
//            {
//                MyDbContext db = new MyDbContext();
//                Notification n = db.Notification.Find(NotificationId);
//                db.Notification.Remove(n);
//                db.Entry(n).State = EntityState.Deleted;
//                db.SaveChanges();
//                return Json(new { status = "success" });
//            }
//            catch (Exception ex)
//            {
//                return Json(new { status = "failed" });
//            }

//        }
//        #endregion Notification


//        #region Rack
//        [Route("Rack_getall")]
//        public dynamic Rack_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            var data = from d in db.Rack.ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                       };
//            return data.ToList();
//        }
//        [Route("Rack_insert")]
//        public int Rack_insert(Rack v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Rack.Add(v);
//            db.SaveChanges();
//            return v.Id;
//        }
//        [Route("Rack_update")]
//        public int Rack_update(Rack v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Entry(v).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            db.SaveChanges();
//            return v.Id;
//        }
//        #endregion Manufacturer


//        #region Category
//        [Route("Category_getall")]
//        public dynamic Category_getall()
//        {
//            MyDbContext db = new MyDbContext();

//            var data = from d in db.Category.ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                       };
//            return data.ToList();
//        }
//        [Route("Category_insert")]
//        public int Category_insert(Category v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Category.Add(v);
//            db.SaveChanges();
//            return v.Id;
//        }
//        [Route("Category_update")]
//        public int Category_update(Category v)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Entry(v).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            db.SaveChanges();
//            return v.Id;
//        }
//        #endregion Category


//        #region product
//        [Route("product_getall")]
//        public dynamic product_getall(string Type = "", bool ActiveOnSale = false, bool ActiveOnPurchase = false)
//        {
//            MyDbContext db = new MyDbContext();
//            List<Product> list = db.Product.Include(a => a.FkManufacturer).Include(a => a.FkCategory).ToList();
//            if (Type != "")
//            {
//                list = db.Product.Where(a => a.Type == Type).ToList();
//            }
//            if (ActiveOnSale != false)
//            {
//                list = db.Product.Where(a => a.ActiveOnSale == true).ToList();
//            }
//            if (ActiveOnPurchase != false)
//            {
//                list = db.Product.Where(a => a.ActiveOnPurchase == true).ToList();
//            }
//            var data = from d in list
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           Barcode = d.Barcode == null ? "" : d.Barcode,
//                           Description = d.Description == null ? "" : d.Description,
//                           SalePrice = d.SalePrice,
//                           PurchasePrice = d.PurchasePrice,
//                           Discount = d.Discount,
//                           Quantity = d.Quantity,
//                           FkCategoryId = d.FkCategoryId,
//                           FkManufacturerId = d.FkManufacturerId,
//                           FkCategory_Name = d.FkCategory == null ? "" : d.FkCategory.Name,
//                           FkManufacturer_Name = d.FkManufacturer == null ? "" : d.FkManufacturer.Name,
//                           Type = d.Type == null ? "" : d.Type,
//                           ActiveOnSale = d.ActiveOnSale == null ? false : d.ActiveOnSale,
//                           ActiveOnPurchase = d.ActiveOnPurchase == null ? false : d.ActiveOnPurchase,
//                           Sku = d.Sku,
//                           FkRackId = d.FkRackId,
//                           FkRack_Name = d.FkRack == null ? "" : d.FkRack.Name,
//                           LowInventoryNotification = d.LowInventoryNotification,
//                       };
//            var sorteddata = data.ToList();
//            return sorteddata;
//        }
//        [Route("product_getall_inventory_low")]
//        public dynamic product_getall_inventory_low(string Type = "", bool ActiveOnSale = false, bool ActiveOnPurchase = false)
//        {
//            MyDbContext db = new MyDbContext();
//            List<Product> list = db.Product.Include(a => a.FkManufacturer).Include(a => a.FkCategory).ToList();
//            if (Type != "")
//            {
//                list = db.Product.Where(a => a.Type == Type).ToList();
//            }
//            if (ActiveOnSale != false)
//            {
//                list = db.Product.Where(a => a.ActiveOnSale == true).ToList();
//            }
//            if (ActiveOnPurchase != false)
//            {
//                list = db.Product.Where(a => a.ActiveOnPurchase == true).ToList();
//            }
//            list = db.Product.Where(a => a.Quantity <= a.LowInventoryNotification).ToList();
//            var data = from d in list
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           Barcode = d.Barcode == null ? "" : d.Barcode,
//                           Description = d.Description == null ? "" : d.Description,
//                           SalePrice = d.SalePrice,
//                           PurchasePrice = d.PurchasePrice,
//                           Discount = d.Discount,
//                           Quantity = d.Quantity,
//                           FkCategoryId = d.FkCategoryId,
//                           FkManufacturerId = d.FkManufacturerId,
//                           FkCategory_Name = d.FkCategory == null ? "" : d.FkCategory.Name,
//                           FkManufacturer_Name = d.FkManufacturer == null ? "" : d.FkManufacturer.Name,
//                           Type = d.Type == null ? "" : d.Type,
//                           ActiveOnSale = d.ActiveOnSale == null ? false : d.ActiveOnSale,
//                           ActiveOnPurchase = d.ActiveOnPurchase == null ? false : d.ActiveOnPurchase,
//                           Sku = d.Sku,
//                           FkRackId = d.FkRackId,
//                           FkRack_Name = d.FkRack == null ? "" : d.FkRack.Name,
//                           LowInventoryNotification = d.LowInventoryNotification,
//                       };
//            var sorteddata = data.ToList();
//            return sorteddata;
//        }
//        [Route("product_getById")]
//        public dynamic product_getById(int Id)
//        {
//            MyDbContext db = new MyDbContext();
//            Product d = db.Product.Find(Id);
//            var data = new
//            {
//                Id = d.Id,
//                Name = d.Name,
//                Barcode = d.Barcode == null ? "" : d.Barcode,
//                Description = d.Description == null ? "" : d.Description,
//                SalePrice = d.SalePrice,
//                PurchasePrice = d.PurchasePrice,
//                Discount = d.Discount == null ? 0 : d.Discount,
//                Quantity = d.Quantity,
//                FkCategoryId = d.FkCategoryId,
//                FkManufacturerId = d.FkManufacturerId,
//                FkCategory_Name = d.FkCategory == null ? "" : d.FkCategory.Name,
//                FkManufacturer_Name = d.FkManufacturer == null ? "" : d.FkManufacturer.Name,
//                Type = d.Type == null ? "" : d.Type,
//                ActiveOnSale = d.ActiveOnSale == null ? false : d.ActiveOnSale,
//                ActiveOnPurchase = d.ActiveOnPurchase == null ? false : d.ActiveOnPurchase,
//                Sku = d.Sku,
//                FkRackId = d.FkRackId,
//                FkRack_Name = d.FkRack == null ? "" : d.FkRack.Name,
//                LowInventoryNotification = d.LowInventoryNotification,
//            };
//            return data;
//        }
//        [Route("product_insert")]
//        public int product_insert(Product a)
//        {
//            MyDbContext db = new MyDbContext();
//            a.Quantity = 0;
//            db.Product.Add(a);
//            db.SaveChanges();
//            return a.Id;
//        }
//        [Route("product_update")]
//        public int product_update(Product a)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            db.SaveChanges();
//            return a.Id;
//        }
//        [Route("product_delete")]
//        public dynamic product_delete(int ProductId)
//        {
//            MyDbContext db = new MyDbContext();
//            Product p = db.Product.Find(ProductId);
//            if (p.Type != "Product")
//            {
//                return Json(new { status = "failed" });
//            }
//            try
//            {
//                db.Product.Remove(p);
//                db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
//                db.SaveChanges();
//                return Json(new { status = "success" });
//            }
//            catch (Exception ex)
//            {
//                return Json(new { status = "failed" });
//            }

//        }
//        [Route("dealproduct_getall")]
//        public dynamic dealproduct_getall(int dealId = 0)
//        {
//            MyDbContext db = new MyDbContext();
//            List<Dealproductorreciperaw> list;
//            if (dealId == 0)
//            {
//                list = db.Dealproductorreciperaw.Include(a => a.FkMain).Include(a => a.FkSub).ToList();
//            }
//            else
//            {
//                list = db.Dealproductorreciperaw.Where(a => a.FkMainId == dealId).Include(a => a.FkMain).Include(a => a.FkSub).ToList();
//            }
//            var data = from d in list
//                       select new
//                       {
//                           Id = d.Id,
//                           SubId = d.FkSub.Id,
//                           SubName = d.FkSub.Name,
//                           Quantity = d.Quantity

//                       };
//            var sorteddata = data.ToList();
//            return sorteddata;
//        }
//        [Route("dealproduct_insert")]
//        public int dealproduct_insert(Dealproductorreciperaw a)
//        {
//            MyDbContext db = new MyDbContext();

//            db.Dealproductorreciperaw.Add(a);
//            db.SaveChanges();
//            return a.Id;
//        }
//        [Route("dealproduct_DeleteById")]
//        public bool dealproduct_DeleteById(int dealproductid)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Dealproductorreciperaw.Remove(db.Dealproductorreciperaw.Find(dealproductid));
//            db.SaveChanges();
//            return true;
//        }
//        [HttpPost]
//        [Route("InventoryGain_Insert")]
//        public bool InventoryGain_Insert(int FKProductId, float Quantity)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> accounts = db.FinanceAccount.ToList();

//            //New purchase Transaction

//            //Calclulated ammount of inventory
//            Product product = db.Product.Find(FKProductId);
//            float productPurchasePrice = (float)product.PurchasePrice;
//            float productTotalAmount = (float)(productPurchasePrice * Quantity);

//            //Inventory(Asset) Transaction
//            FinanceTransaction fti = new FinanceTransaction();
//            fti.Amount = productTotalAmount;
//            fti.Name = "Inventory Gain";
//            fti.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory").FirstOrDefault().Id;
//            fti.DateTime = DateTime.Now;
//            fti.Status = "Posted";
//            fti.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(fti);
//            db.SaveChanges();
//            fti.GroupId = fti.Id;
//            db.Entry(fti).State = EntityState.Modified;
//            db.SaveChanges();


//            //Inventory Gain(Income) Transaction
//            FinanceTransaction ftig = new FinanceTransaction();
//            ftig.Amount = -productTotalAmount;
//            ftig.Name = "Inventory Gain";
//            ftig.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory Gain").FirstOrDefault().Id;
//            ftig.DateTime = DateTime.Now;
//            ftig.Status = "Posted";
//            ftig.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftig);
//            ftig.GroupId = fti.Id;
//            db.SaveChanges();


//            //Product Transaction
//            ProductTransaction pt = new ProductTransaction();
//            pt.FkProductId = FKProductId;
//            pt.FkFinanceTransactionId = fti.Id;
//            pt.Price = productPurchasePrice;
//            pt.Quantity = Quantity;
//            pt.Total = productTotalAmount;
//            db.ProductTransaction.Add(pt);
//            db.SaveChanges();

//            // update inventory on inventory gain 
//            product.Quantity += Quantity;
//            db.Entry(product).State = EntityState.Modified;
//            db.SaveChanges();

//            return true;
//        }
//        [HttpPost]
//        [Route("InventoryLoss_Insert")]
//        public bool InventoryLoss_Insert(int FKProductId, float Quantity)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> accounts = db.FinanceAccount.ToList();

//            //New purchase Transaction

//            //Calclulated ammount of inventory
//            Product product = db.Product.Find(FKProductId);
//            float productPurchasePrice = (float)product.PurchasePrice;
//            float productTotalAmount = (float)(productPurchasePrice * Quantity);

//            //Inventory(Asset) Transaction
//            FinanceTransaction fti = new FinanceTransaction();
//            fti.Amount = -productTotalAmount;
//            fti.Name = "Inventory Loss";
//            fti.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory").FirstOrDefault().Id;
//            fti.DateTime = DateTime.Now;
//            fti.Status = "Posted";
//            fti.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(fti);
//            db.SaveChanges();
//            fti.GroupId = fti.Id;
//            db.Entry(fti).State = EntityState.Modified;
//            db.SaveChanges();


//            //Inventory Gain(Income) Transaction
//            FinanceTransaction ftig = new FinanceTransaction();
//            ftig.Amount = productTotalAmount;
//            ftig.Name = "Inventory Loss";
//            ftig.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory Loss").FirstOrDefault().Id;
//            ftig.DateTime = DateTime.Now;
//            ftig.Status = "Posted";
//            ftig.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftig);
//            ftig.GroupId = fti.Id;
//            db.SaveChanges();


//            //Product Transaction
//            ProductTransaction pt = new ProductTransaction();
//            pt.FkProductId = FKProductId;
//            pt.FkFinanceTransactionId = fti.Id;
//            pt.Price = productPurchasePrice;
//            pt.Quantity = -Quantity;
//            pt.Total = -productTotalAmount;
//            db.ProductTransaction.Add(pt);
//            db.SaveChanges();

//            // update inventory on inventory gain 
//            product.Quantity -= Quantity;
//            db.Entry(product).State = EntityState.Modified;
//            db.SaveChanges();

//            return true;
//        }
//        [Route("productbatch_getAll")]
//        public List<ProductBatch> productbatch_getAll()
//        {
//            MyDbContext db = new MyDbContext();
//            List<ProductBatch> list = db.ProductBatch.Include(a => a.FkProduct).ToList();
//            return list;
//        }
//        public void updateInventoryOnSale(List<SaleItem> list)
//        {
//            new System.Threading.Tasks.Task(() =>
//            {
//                MyDbContext db = new MyDbContext();
//                foreach (SaleItem item in list)
//                {
//                    Product p = db.Product.Find(item.id);
//                    if (p.Type == "Product")
//                    {
//                        p.Quantity -= item.quantity;
//                        db.Entry(p).State = EntityState.Modified;
//                        db.SaveChanges();

//                        string[] color = { "red", "green", "blue", "yellow" };
//                        Random rnd = new Random();
//                        int dice = rnd.Next(1, 4);
//                        if (p.Quantity <= p.LowInventoryNotification)
//                        {
//                            string message = p.Name + " Inventory is Redusing. Remaining quantity is " + p.Quantity + ". Please Make a Purchase Order.";
//                            Notification_insert("Inventory Notice", message, color[dice]);

//                        }
//                    }
//                    else if (p.Type == "Deal")
//                    {
//                        List<Dealproductorreciperaw> dealProducts = db.Dealproductorreciperaw.Where(a => a.FkMainId == p.Id).ToList();
//                        foreach (Dealproductorreciperaw dealProduct in dealProducts)
//                        {
//                            Product productsub = db.Product.Find(dealProduct.FkSubId);
//                            productsub.Quantity -= (dealProduct.Quantity * item.quantity);
//                            db.Entry(productsub).State = EntityState.Modified;

//                            if (p.Quantity <= p.LowInventoryNotification)
//                            {
//                                string message = "Product " + productsub.Name + " Inventory is Redusing. Remaining quantity is " + productsub.Quantity + ". Please Make a Purchase Order.";
//                                Notification_insert("Inventory Notice", message, "yellow");
//                            }

//                        }
//                        db.SaveChanges();
//                    }
//                    else if (p.Type == "Recipe")
//                    {
//                        List<Dealproductorreciperaw> dealProducts = db.Dealproductorreciperaw.Where(a => a.FkMainId == p.Id).ToList();
//                        foreach (Dealproductorreciperaw dealProduct in dealProducts)
//                        {
//                            Product productsub = db.Product.Find(dealProduct.FkSubId);
//                            productsub.Quantity -= (dealProduct.Quantity * item.quantity);
//                            db.Entry(productsub).State = EntityState.Modified;
//                        }
//                        db.SaveChanges();
//                    }
//                    else if (p.Type == "Service")
//                    {

//                    }



//                    //List<ProductBatch> productbatches = db.ProductBatch.Where(a => a.FkProductId == item.id).ToList();
//                    //ProductBatch defaultbatch = productbatches.FirstOrDefault();
//                    //defaultbatch.Quantity -= item.quantity;
//                    //db.Entry(defaultbatch).State = EntityState.Modified;
//                    //db.SaveChanges();
//                }
//            }).Start();

//        }
//        public void updateInventoryOnSaleReturn(List<SaleItem> list)
//        {
//            MyDbContext db = new MyDbContext();
//            foreach (SaleItem item in list)
//            {
//                Product p = db.Product.Find(item.id);
//                if (p.Type == "Product")
//                {
//                    p.Quantity += item.quantity;
//                    db.Entry(p).State = EntityState.Modified;
//                    db.SaveChanges();
//                }
//                else if (p.Type == "Deal")
//                {
//                    List<Dealproductorreciperaw> dealProducts = db.Dealproductorreciperaw.Where(a => a.FkMainId == p.Id).ToList();
//                    foreach (Dealproductorreciperaw dealProduct in dealProducts)
//                    {
//                        Product productsub = db.Product.Find(dealProduct.FkSubId);
//                        productsub.Quantity += (dealProduct.Quantity * item.quantity);
//                        db.Entry(productsub).State = EntityState.Modified;
//                    }
//                    db.SaveChanges();
//                }
//                else if (p.Type == "Recipe")
//                {
//                    List<Dealproductorreciperaw> dealProducts = db.Dealproductorreciperaw.Where(a => a.FkMainId == p.Id).ToList();
//                    foreach (Dealproductorreciperaw dealProduct in dealProducts)
//                    {
//                        Product productsub = db.Product.Find(dealProduct.FkSubId);
//                        productsub.Quantity += (dealProduct.Quantity * item.quantity);
//                        db.Entry(productsub).State = EntityState.Modified;
//                    }
//                    db.SaveChanges();
//                }
//                else if (p.Type == "Service")
//                {

//                }

//                //List<ProductBatch> productbatches = db.ProductBatch.Where(a => a.FkProductId == item.id).ToList();
//                //ProductBatch defaultbatch = productbatches.FirstOrDefault();
//                //defaultbatch.Quantity -= item.quantity;
//                //db.Entry(defaultbatch).State = EntityState.Modified;
//                //db.SaveChanges();
//            }
//        }
//        public void updateInventoryOnPurchase(List<SaleItem> list)
//        {
//            MyDbContext db = new MyDbContext();
//            foreach (SaleItem item in list)
//            {
//                //updating product quantity
//                Product p = db.Product.Find(item.id);
//                p.Quantity += item.quantity;
//                db.Entry(p).State = EntityState.Modified;
//                db.SaveChanges();


//                //updating bach quantity
//                //List<ProductBatch> productbatches = db.ProductBatch.Where(a => a.FkProductId == item.id).ToList();
//                //if (productbatches.Count == 0)
//                //{
//                //    //new batch if no batch exists
//                //    ProductBatch batch = new ProductBatch();
//                //    batch.Batch = "Default Batch of " + p.Name;
//                //    batch.FkProductId = p.Id;
//                //    batch.Quantity = item.quantity;
//                //    db.ProductBatch.Add(batch);
//                //    db.SaveChanges();

//                //}
//                //else
//                //{
//                //    ProductBatch defaultbatch = productbatches.FirstOrDefault();
//                //    defaultbatch.Quantity += item.quantity;
//                //    db.Entry(defaultbatch).State = EntityState.Modified;
//                //    db.SaveChanges();
//                //}

//            }

//        }
//        public void updateInventoryOnPurchaseReturn(List<SaleItem> list)
//        {
//            MyDbContext db = new MyDbContext();
//            foreach (SaleItem item in list)
//            {
//                //updating product quantity
//                Product p = db.Product.Find(item.id);
//                p.Quantity -= item.quantity;
//                db.Entry(p).State = EntityState.Modified;
//                db.SaveChanges();
//            }

//        }
//        #endregion Product


//        #region Accounts
//        [Route("finance_account_getall")]
//        public dynamic finance_account_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            var data = from d in db.FinanceAccount.Include(a => a.FkParent).ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           FinanceAccountType = d.FinanceAccountType,
//                           FkParentId = d.FkParentId,
//                           FkParent_Name = d.FkParent == null ? "" : d.FkParent.Name,
//                       };
//            return data.ToList();
//        }
//        [Route("finance_account_insert")]
//        public int finance_account_insert(FinanceAccount a)
//        {
//            MyDbContext db = new MyDbContext();
//            db.FinanceAccount.Add(a);
//            db.SaveChanges();
//            return a.Id;
//        }
//        [Route("finance_account_update")]
//        public int finance_account_update(FinanceAccount a)
//        {
//            MyDbContext db = new MyDbContext();
//            db.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            db.SaveChanges();
//            return a.Id;
//        }
//        [HttpPost]
//        [Route("finance_transaction_getAll")]
//        public dynamic finance_transaction_getAll(string FinanceAccountType = "", string FinanceAccount = "", DateTime? FromDate = null, DateTime? ToDate = null)
//        {
//            MyDbContext db = new MyDbContext();
//            List<FinanceTransaction> list = db.FinanceTransaction.Include(a => a.FkFinanceAccount).Include(a => a.FkAspnetusers).ToList();
//            if (FinanceAccountType != "")
//            {
//                list = list.Where(a => a.FkFinanceAccount.FinanceAccountType == FinanceAccountType).ToList();
//            }
//            if (FinanceAccount != "")
//            {
//                list = list.Where(a => a.FkFinanceAccount.Name == FinanceAccount).ToList();
//            }
//            if (FromDate != null)
//            {
//                DateTime StartTimeOfFromDate = ((DateTime)FromDate).Date;
//                list = list.Where(a => a.DateTime >= StartTimeOfFromDate).ToList();
//            }
//            if (ToDate != null)
//            {
//                DateTime EndTimeOfToDate = ((DateTime)ToDate).Date.AddDays(1).AddTicks(-1);
//                list = list.Where(a => a.DateTime <= EndTimeOfToDate).ToList();
//            }
//            var data = from d in list
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           Amount = d.Amount,
//                           DateTime = ((DateTime)d.DateTime).ToString("dd/MM/yyyy"),
//                           GroupId = d.GroupId,
//                           UserType = d.UserType,
//                           UserId = d.UserId,
//                           ChildOf = d.ChildOf,
//                           Status = d.Status,
//                           FkFinanceAccountId = d.FkFinanceAccountId,
//                           FkFinanceAccount_Name = d.FkFinanceAccount == null ? "" : d.FkFinanceAccount.Name,
//                           FkAspnetusersId = d.FkAspnetusersId,
//                           FkAspnetusers_Name = d.FkAspnetusers == null ? "" : d.FkAspnetusers.UserName,
//                           PaymentMethod = d.PaymentMethod == null ? "" : d.PaymentMethod,
//                           ReferenceNumber = d.ReferenceNumber == null ? "" : d.ReferenceNumber,
//                           Bank = d.Bank == null ? "" : d.Bank,
//                           Branch = d.Branch == null ? "" : d.Branch,
//                           ChequeDate = d.ChequeDate,
//                           OtherDetail = d.OtherDetail == null ? "" : d.OtherDetail,
//                           OherDetails2 = d.OherDetails2 == null ? "" : d.OherDetails2
//                       };
//            return data.Reverse().ToList();
//        }
//        [Route("finance_transaction_getById")]
//        public dynamic finance_transaction_getById(int Id)
//        {
//            MyDbContext db = new MyDbContext();
//            FinanceTransaction d = db.FinanceTransaction.Where(a => a.Id == Id).Include(a => a.FkFinanceAccount).Include(a => a.FkAspnetusers).FirstOrDefault();
//            if (d == null)
//            {
//                return false;
//            }
//            else
//            {
//                var data = new
//                {
//                    Id = d.Id,
//                    Name = d.Name,
//                    Amount = d.Amount,
//                    DateTime = ((DateTime)d.DateTime).ToString("dd/MM/yyyy"),
//                    GroupId = d.GroupId,
//                    UserType = d.UserType,
//                    UserId = d.UserId,
//                    ChildOf = d.ChildOf,
//                    Status = d.Status,
//                    FkFinanceAccountId = d.FkFinanceAccountId,
//                    FkFinanceAccount_Name = d.FkFinanceAccount == null ? "" : d.FkFinanceAccount.Name,
//                    FkAspnetusersId = d.FkAspnetusersId,
//                    FkAspnetusers_Name = d.FkAspnetusers == null ? "" : d.FkAspnetusers.UserName,
//                    PaymentMethod = d.PaymentMethod,
//                    ReferenceNumber = d.ReferenceNumber,
//                    Bank = d.Bank,
//                    Branch = d.Branch,
//                    ChequeDate = d.ChequeDate,
//                    OtherDetail = d.OtherDetail,
//                    OherDetails2 = d.OherDetails2,

//                };
//                return data;
//            }
//        }
//        [Route("expence_insert")]
//        public int expence_insert(FinanceTransaction a)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();

//            //New Expence Transaction
//            FinanceTransaction ftexpence = new FinanceTransaction();
//            ftexpence.Amount = a.Amount;
//            ftexpence.Name = a.Name;
//            ftexpence.FkFinanceAccountId = a.FkFinanceAccountId;
//            ftexpence.DateTime = DateTime.Now;
//            ftexpence.Status = "Posted";
//            ftexpence.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftexpence);
//            db.SaveChanges();
//            ftexpence.GroupId = ftexpence.Id;
//            db.Entry(ftexpence).State = EntityState.Modified;
//            db.SaveChanges();


//            //New Expence Transaction
//            FinanceTransaction ftdeduct = new FinanceTransaction();
//            ftdeduct.Amount = -a.Amount;
//            ftdeduct.Name = "Payed Expence no " + ftexpence.Id;
//            // for adding expence we need a paying account. i am using child of filed for get paying account. i am not using custom model. else i am using same finance_transaction model 
//            ftdeduct.FkFinanceAccountId = a.ChildOf;
//            ftdeduct.DateTime = DateTime.Now;
//            ftdeduct.Status = "Posted";
//            ftdeduct.GroupId = ftexpence.Id;
//            ftdeduct.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftdeduct);
//            db.SaveChanges();
//            return ftexpence.Id;
//        }
//        [Route("assets_insert")]
//        public int assets_insert(FinanceTransaction a)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();

//            //New Expence Transaction
//            FinanceTransaction ftexpence = new FinanceTransaction();
//            ftexpence.Amount = a.Amount;
//            ftexpence.Name = a.Name;
//            ftexpence.FkFinanceAccountId = a.FkFinanceAccountId;
//            ftexpence.DateTime = DateTime.Now;
//            ftexpence.Status = "Posted";
//            ftexpence.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftexpence);
//            db.SaveChanges();
//            ftexpence.GroupId = ftexpence.Id;
//            db.Entry(ftexpence).State = EntityState.Modified;
//            db.SaveChanges();


//            //New Expence Transaction
//            FinanceTransaction ftdeduct = new FinanceTransaction();
//            ftdeduct.Amount = -a.Amount;
//            ftdeduct.Name = "Payed Asset no " + ftexpence.Id;
//            // for adding expence we need a paying account. i am using child of filed for get paying account. i am not using custom model. else i am using same finance_transaction model 
//            ftdeduct.FkFinanceAccountId = a.ChildOf;
//            ftdeduct.DateTime = DateTime.Now;
//            ftdeduct.Status = "Posted";
//            ftdeduct.GroupId = ftexpence.Id;
//            ftdeduct.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftdeduct);
//            db.SaveChanges();
//            return ftexpence.Id;
//        }
//        [Route("income_insert")]
//        public int income_insert(FinanceTransaction a)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();

//            //New Expence Transaction
//            FinanceTransaction ftexpence = new FinanceTransaction();
//            ftexpence.Amount = -a.Amount;
//            ftexpence.Name = a.Name;
//            ftexpence.FkFinanceAccountId = a.FkFinanceAccountId;
//            ftexpence.DateTime = DateTime.Now;
//            ftexpence.Status = "Posted";
//            ftexpence.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftexpence);
//            db.SaveChanges();
//            ftexpence.GroupId = ftexpence.Id;
//            db.Entry(ftexpence).State = EntityState.Modified;
//            db.SaveChanges();


//            //New Expence Transaction
//            FinanceTransaction ftdeduct = new FinanceTransaction();
//            ftdeduct.Amount = a.Amount;
//            ftdeduct.Name = "Payment against Income  " + ftexpence.Id;
//            // for adding expence we need a paying account. i am using child of filed for get paying account. i am not using custom model. else i am using same finance_transaction model 
//            ftdeduct.FkFinanceAccountId = a.ChildOf;
//            ftdeduct.DateTime = DateTime.Now;
//            ftdeduct.Status = "Posted";
//            ftdeduct.GroupId = ftexpence.Id;
//            ftdeduct.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftdeduct);
//            db.SaveChanges();
//            return ftexpence.Id;
//        }
//        [Route("equity_insert")]
//        public int equity_insert(FinanceTransaction a)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();

//            //New Expence Transaction
//            FinanceTransaction ftexpence = new FinanceTransaction();
//            ftexpence.Amount = -a.Amount;
//            ftexpence.Name = a.Name;
//            ftexpence.FkFinanceAccountId = a.FkFinanceAccountId;
//            ftexpence.DateTime = DateTime.Now;
//            ftexpence.Status = "Posted";
//            ftexpence.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftexpence);
//            db.SaveChanges();
//            ftexpence.GroupId = ftexpence.Id;
//            db.Entry(ftexpence).State = EntityState.Modified;
//            db.SaveChanges();


//            //New Expence Transaction
//            FinanceTransaction ftdeduct = new FinanceTransaction();
//            ftdeduct.Amount = a.Amount;
//            ftdeduct.Name = "Payment against Equity no " + ftexpence.Id;
//            // for adding expence we need a paying account. i am using child of filed for get paying account. i am not using custom model. else i am using same finance_transaction model 
//            ftdeduct.FkFinanceAccountId = a.ChildOf;
//            ftdeduct.DateTime = DateTime.Now;
//            ftdeduct.Status = "Posted";
//            ftdeduct.GroupId = ftexpence.Id;
//            ftdeduct.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftdeduct);
//            db.SaveChanges();
//            return ftexpence.Id;
//        }
//        [Route("product_transaction_getAll")]
//        public dynamic product_transaction_getAll(int TransactionId = 0)
//        {
//            MyDbContext db = new MyDbContext();
//            List<ProductTransaction> list;
//            if (TransactionId != 0)
//            {
//                list = db.ProductTransaction.Where(a => a.FkFinanceTransactionId == TransactionId).Include(a => a.FkProduct).ToList();
//            }
//            else
//            {
//                list = db.ProductTransaction.Include(a => a.FkProduct).ToList();
//            }

//            var data = from d in list
//                       select new
//                       {
//                           Id = d.Id,
//                           Price = d.Price,
//                           Quantity = d.Quantity,
//                           Total = d.Total,
//                           FkFinanceTransactionId = d.FkFinanceTransactionId,
//                           ProductBatchId = d.ProductBatchId,
//                           FkProductId = d.FkProductId,
//                           FkProduct_Name = d.FkProduct == null ? "" : d.FkProduct.Name,
//                       };
//            return data.ToList();
//        }
//        [HttpPost]
//        [Route("NewSale")]
//        public dynamic NewSale(SaleModel SaleModel)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> accounts = db.FinanceAccount.ToList();

//            //New Sale Transaction
//            FinanceTransaction ftsale = new FinanceTransaction();
//            ftsale.Amount = -SaleModel.TotalBill;
//            ftsale.Name = "New Sale";
//            ftsale.FkFinanceAccountId = accounts.Where(a => a.Name == "Products Sale").FirstOrDefault().Id;
//            if (SaleModel.CustomerId != 0)
//            {
//                ftsale.UserId = SaleModel.CustomerId;
//            }
//            ftsale.UserType = "Customer";
//            ftsale.DateTime = DateTime.Now;
//            ftsale.Status = "Posted";
//            ftsale.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftsale);
//            db.SaveChanges();
//            ftsale.GroupId = ftsale.Id;
//            db.Entry(ftsale).State = EntityState.Modified;
//            db.SaveChanges();


//            // if Discount Given then new discount transaction
//            if (SaleModel.DiscountedBill < SaleModel.TotalBill)
//            {
//                //New Discount Transaction against sale
//                FinanceTransaction ftdiscount = new FinanceTransaction();
//                ftdiscount.Amount = SaleModel.TotalBill - SaleModel.DiscountedBill;
//                ftdiscount.Name = "Discount against Sale no " + ftsale.Id;
//                ftdiscount.FkFinanceAccountId = accounts.Where(a => a.Name == "Discounts").FirstOrDefault().Id;
//                ftdiscount.DateTime = DateTime.Now;
//                ftdiscount.Status = "Posted";
//                ftdiscount.GroupId = ftsale.Id;
//                ftdiscount.FkAspnetusersId = UserId;
//                db.FinanceTransaction.Add(ftdiscount);
//                db.SaveChanges();
//            }



//            //New Payment Transaction against sale . if customer is paying some money
//            if (SaleModel.TotalPayment > 0)
//            {
//                FinanceTransaction ftpayment = new FinanceTransaction();
//                ftpayment.Amount = SaleModel.TotalPayment;
//                ftpayment.Name = "Payment against Sale no " + ftsale.Id;
//                ftpayment.FkFinanceAccountId = accounts.Where(a => a.Name == "Cash").FirstOrDefault().Id;
//                if (SaleModel.CustomerId != 0)
//                {
//                    ftpayment.UserId = SaleModel.CustomerId;
//                }
//                ftpayment.UserType = "Customer";
//                ftpayment.DateTime = DateTime.Now;
//                ftpayment.Status = "Posted";
//                ftpayment.GroupId = ftsale.Id;
//                ftpayment.FkAspnetusersId = UserId;
//                db.FinanceTransaction.Add(ftpayment);
//                db.SaveChanges();
//            }


//            // New AR Transaction if Ledger is true
//            if (SaleModel.Ledger == true)
//            {
//                FinanceTransaction ftar = new FinanceTransaction();
//                ftar.Amount = SaleModel.DiscountedBill - SaleModel.TotalPayment;
//                ftar.Name = "New AR against Sale no " + ftsale.Id; ;
//                ftar.FkFinanceAccountId = accounts.Where(a => a.Name == "Account Receivables").FirstOrDefault().Id;
//                if (SaleModel.CustomerId != 0)
//                {
//                    ftar.UserId = SaleModel.CustomerId;
//                }
//                ftar.UserType = "Customer";
//                ftar.DateTime = DateTime.Now;
//                ftar.Status = "Posted";
//                ftar.FkAspnetusersId = UserId;
//                ftar.GroupId = ftsale.Id;
//                db.FinanceTransaction.Add(ftar);
//                db.SaveChanges();
//            }



//            // new cost of goods sold variable 
//            float CostOfGoodsSold = 0;
//            foreach (SaleItem item in SaleModel.SaleList)
//            {

//                ProductTransaction pt = new ProductTransaction();
//                pt.FkProductId = item.id;
//                pt.FkFinanceTransactionId = ftsale.Id;
//                pt.Price = item.price;
//                pt.Quantity = -item.quantity;
//                pt.Total = ((item.price - item.discount) * -item.quantity);
//                db.ProductTransaction.Add(pt);
//                db.SaveChanges();
//                CostOfGoodsSold += (float)db.Product.Find(item.id).PurchasePrice * item.quantity;
//            }


//            // new cost of goods transaction against sale
//            FinanceTransaction ftcgs = new FinanceTransaction();
//            ftcgs.Amount = CostOfGoodsSold;
//            ftcgs.Name = "CGS against Sale no " + ftsale.Id; ;
//            ftcgs.FkFinanceAccountId = accounts.Where(a => a.Name == "Cost Of Goods Sold").FirstOrDefault().Id;
//            ftcgs.DateTime = DateTime.Now;
//            ftcgs.Status = "Posted";
//            ftcgs.FkAspnetusersId = UserId;
//            ftcgs.GroupId = ftsale.Id;
//            db.FinanceTransaction.Add(ftcgs);
//            db.SaveChanges();


//            // new inventory detct transaction against against sale
//            FinanceTransaction ftid = new FinanceTransaction();
//            ftid.Amount = -CostOfGoodsSold;
//            ftid.Name = "Inventory detuct against Sale no " + ftsale.Id; ;
//            ftid.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory").FirstOrDefault().Id;
//            ftid.DateTime = DateTime.Now;
//            ftid.Status = "Posted";
//            ftid.FkAspnetusersId = UserId;
//            ftid.GroupId = ftsale.Id;
//            db.FinanceTransaction.Add(ftid);
//            db.SaveChanges();


//            updateInventoryOnSale(SaleModel.SaleList);
//            return ftsale.Id;
//        }
//        [HttpPost]
//        [Route("NewPurchase")]
//        public bool NewPurchase(SaleModel SaleModel)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> accounts = db.FinanceAccount.ToList();

//            //New purchase Transaction
//            FinanceTransaction ftpurchase = new FinanceTransaction();
//            ftpurchase.Amount = SaleModel.TotalBill;
//            ftpurchase.Name = "New Purchase";
//            ftpurchase.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory").FirstOrDefault().Id;
//            ftpurchase.UserId = SaleModel.CustomerId;
//            ftpurchase.UserType = "Vendor";
//            ftpurchase.DateTime = DateTime.Now;
//            ftpurchase.Status = "Posted";
//            ftpurchase.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftpurchase);
//            db.SaveChanges();
//            ftpurchase.GroupId = ftpurchase.Id;
//            db.Entry(ftpurchase).State = EntityState.Modified;
//            db.SaveChanges();



//            //New Payment Transaction against sale . if we are paying some money
//            if (SaleModel.TotalPayment > 0)
//            {
//                FinanceTransaction ftpayment = new FinanceTransaction();
//                ftpayment.Amount = -(SaleModel.TotalPayment);
//                ftpayment.Name = "New Payment against Purchase no " + ftpurchase.Id;
//                ftpayment.FkFinanceAccountId = SaleModel.FinanceAccountId;
//                ftpayment.UserId = SaleModel.CustomerId;
//                ftpayment.UserType = "Vendor";
//                ftpayment.DateTime = DateTime.Now;
//                ftpayment.Status = "Posted";
//                ftpayment.GroupId = ftpurchase.Id;
//                ftpayment.FkAspnetusersId = UserId;
//                db.FinanceTransaction.Add(ftpayment);
//                db.SaveChanges();
//            }


//            // New AP Transaction if TotalRemaining has ammount
//            if (SaleModel.Ledger == true)
//            {
//                FinanceTransaction ftap = new FinanceTransaction();
//                ftap.Amount = -(SaleModel.TotalBill - SaleModel.TotalPayment);
//                ftap.Name = "New AP against Purchase no " + ftpurchase.Id; ;
//                ftap.FkFinanceAccountId = accounts.Where(a => a.Name == "Account Payable").FirstOrDefault().Id;
//                ftap.UserId = SaleModel.CustomerId;
//                ftap.UserType = "Vendor";
//                ftap.DateTime = DateTime.Now;
//                ftap.Status = "Posted";
//                db.FinanceTransaction.Add(ftap);
//                ftap.GroupId = ftpurchase.Id;
//                ftap.FkAspnetusersId = UserId;
//                db.SaveChanges();
//            }

//            foreach (SaleItem item in SaleModel.SaleList)
//            {
//                ProductTransaction pt = new ProductTransaction();
//                pt.FkProductId = item.id;
//                pt.FkFinanceTransactionId = ftpurchase.Id;
//                pt.Price = item.price;
//                pt.Quantity = item.quantity;
//                pt.Total = (item.price * item.quantity);
//                db.ProductTransaction.Add(pt);
//                db.SaveChanges();
//            }
//            updateInventoryOnPurchase(SaleModel.SaleList);

//            return true;
//        }
//        [Route("closing_getall")]
//        public dynamic closing_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            var data = from d in db.Closing.Include(a => a.FkAspnetusers).ToList()
//                       select new
//                       {
//                           Id = d.Id,
//                           DateTime = ((DateTime)d.DateTime).ToString("yyyy-MM-dd"),
//                           Comment = d.Comment,
//                           Income = d.Income,
//                           Expence = d.Expence,
//                           ClosingBalance = d.ClosingBalance,
//                           FkAspnetusersId = d.FkAspnetusersId,
//                           FkAspnetusers_Name = d.FkAspnetusers == null ? "" : d.FkAspnetusers.UserName,
//                           Note1 = d.Note1,
//                           Note2 = d.Note2,
//                           Note3 = d.Note3,
//                           Note4 = d.Note4,
//                           Note5 = d.Note5,
//                           Note6 = d.Note6,
//                           Note7 = d.Note7,
//                           Note8 = d.Note8,
//                           Note9 = d.Note9

//                       };
//            return data.Reverse().ToList();
//        }
//        [Route("closing_insert")]
//        public int closing_insert(Closing a)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            a.FkAspnetusersId = UserId;
//            db.Closing.Add(a);
//            db.SaveChanges();
//            return a.Id;
//        }
//        [HttpPost]
//        [Route("Closing_LoadAmounts")]
//        public dynamic Closing_LoadAmounts(DateTime dateTime)
//        {
//            MyDbContext db = new MyDbContext();
//            DateTime StartOfDate = dateTime.Date;
//            DateTime EndOfDate = dateTime.Date.AddDays(1).AddTicks(-1);
//            DateTime PreviousDateStart = StartOfDate.AddDays(-1);
//            float CashPlus = 0;
//            CashPlus = (float)db.FinanceTransaction.Where(a => (a.DateTime >= StartOfDate) && (a.DateTime <= EndOfDate)).Where(a => (a.FkFinanceAccount.Name == "Cash") && (a.Amount > 0)).ToList().Sum(a => a.Amount);

//            float CashMinus = 0;
//            CashMinus = (float)db.FinanceTransaction.Where(a => (a.DateTime >= StartOfDate) && (a.DateTime <= EndOfDate)).Where(a => (a.FkFinanceAccount.Name == "Cash") && (a.Amount < 0)).ToList().Sum(a => a.Amount);

//            Closing PreviousDayClosing = db.Closing.Where(a => (a.DateTime >= PreviousDateStart) && (a.DateTime <= StartOfDate)).FirstOrDefault();
//            float PreviousDayClosingBalance = 0;
//            if (PreviousDayClosing != null)
//            {
//                PreviousDayClosingBalance = (float)PreviousDayClosing.ClosingBalance;
//            }
//            return new { CashPlus = CashPlus, CashMinus = CashMinus, PreviousDayClosingBalance = PreviousDayClosingBalance };
//        }
//        [Route("SaleReturn")]
//        public dynamic SaleReturn(SaleModel SaleModel)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> accounts = db.FinanceAccount.ToList();
//            //Return Sale Transaction
//            FinanceTransaction ftsale = new FinanceTransaction();
//            ftsale.Amount = SaleModel.TotalBill;
//            ftsale.Name = "Return Sale # " + SaleModel.TransactionId;
//            ftsale.FkFinanceAccountId = accounts.Where(a => a.Name == "Products Sale").FirstOrDefault().Id;
//            if (SaleModel.CustomerId != 0)
//            {
//                ftsale.UserId = SaleModel.CustomerId;
//            }
//            ftsale.UserType = "Customer";
//            ftsale.DateTime = DateTime.Now;
//            ftsale.Status = "Posted";
//            ftsale.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftsale);
//            db.SaveChanges();
//            ftsale.GroupId = ftsale.Id;
//            db.Entry(ftsale).State = EntityState.Modified;
//            db.SaveChanges();

//            // New AP Transaction if Ledger is true . else we will do cash detuct transaction
//            if (SaleModel.Ledger == true)
//            {
//                FinanceTransaction ftar = new FinanceTransaction();
//                ftar.Amount = -SaleModel.TotalBill;
//                ftar.Name = "AP against retun Sale # " + ftsale.Id;
//                ftar.FkFinanceAccountId = accounts.Where(a => a.Name == "Account Payable").FirstOrDefault().Id;
//                if (SaleModel.CustomerId != 0)
//                {
//                    ftar.UserId = SaleModel.CustomerId;
//                }
//                ftar.UserType = "Customer";
//                ftar.DateTime = DateTime.Now;
//                ftar.Status = "Posted";
//                ftar.FkAspnetusersId = UserId;
//                ftar.GroupId = ftsale.Id;
//                db.FinanceTransaction.Add(ftar);
//                db.SaveChanges();
//            }
//            else
//            {
//                // this transaction is for because we are returing ammount to customer
//                FinanceTransaction ftpayment = new FinanceTransaction();
//                ftpayment.Amount = SaleModel.TotalPayment;
//                ftpayment.Name = "Payment against return sale # " + ftsale.Id;
//                ftpayment.FkFinanceAccountId = SaleModel.FinanceAccountId;
//                if (SaleModel.CustomerId != 0)
//                {
//                    ftpayment.UserId = SaleModel.CustomerId;
//                }
//                ftpayment.UserType = "Customer";
//                ftpayment.DateTime = DateTime.Now;
//                ftpayment.Status = "Posted";
//                ftpayment.FkAspnetusersId = UserId;
//                ftpayment.GroupId = ftsale.Id;
//                db.FinanceTransaction.Add(ftpayment);
//                db.SaveChanges();
//            }

//            // new cost of goods sold variable 
//            float CostOfGoodsSold = 0;
//            foreach (SaleItem item in SaleModel.SaleList)
//            {

//                ProductTransaction pt = new ProductTransaction();
//                pt.FkProductId = item.id;
//                pt.FkFinanceTransactionId = ftsale.Id;
//                pt.Price = item.price;
//                pt.Quantity = item.quantity;
//                pt.Total = ((item.price - item.discount) * item.quantity);
//                db.ProductTransaction.Add(pt);
//                db.SaveChanges();
//                CostOfGoodsSold += (float)pt.Total;
//            }


//            // new minus cost of goods transaction against sale return
//            FinanceTransaction ftcgs = new FinanceTransaction();
//            ftcgs.Amount = -CostOfGoodsSold;
//            ftcgs.Name = "CGS against Return Sale # " + ftsale.Id;
//            ftcgs.FkFinanceAccountId = accounts.Where(a => a.Name == "Cost Of Goods Sold").FirstOrDefault().Id;
//            ftcgs.DateTime = DateTime.Now;
//            ftcgs.Status = "Posted";
//            ftcgs.FkAspnetusersId = UserId;
//            ftcgs.GroupId = ftsale.Id;
//            db.FinanceTransaction.Add(ftcgs);
//            db.SaveChanges();


//            // new inventory plus transaction against against sale
//            FinanceTransaction ftid = new FinanceTransaction();
//            ftid.Amount = CostOfGoodsSold;
//            ftid.Name = "Inventory against Return Sale # " + ftsale.Id; ;
//            ftid.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory").FirstOrDefault().Id;
//            ftid.DateTime = DateTime.Now;
//            ftid.Status = "Posted";
//            ftid.FkAspnetusersId = UserId;
//            ftid.GroupId = ftsale.Id;
//            db.FinanceTransaction.Add(ftid);
//            db.SaveChanges();

//            updateInventoryOnSaleReturn(SaleModel.SaleList);
//            return ftsale.Id;
//        }
//        [Route("PurchaseReturn")]
//        public dynamic PurchaseReturn(SaleModel SaleModel)
//        {
//            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> accounts = db.FinanceAccount.ToList();
//            //Return Sale Transaction
//            FinanceTransaction ftsale = new FinanceTransaction();
//            ftsale.Amount = -SaleModel.TotalBill;
//            ftsale.Name = "Return Purchase # " + SaleModel.TransactionId;
//            ftsale.FkFinanceAccountId = accounts.Where(a => a.Name == "Inventory").FirstOrDefault().Id;
//            ftsale.UserId = SaleModel.CustomerId;
//            ftsale.UserType = "Vendor";
//            ftsale.DateTime = DateTime.Now;
//            ftsale.Status = "Posted";
//            ftsale.FkAspnetusersId = UserId;
//            db.FinanceTransaction.Add(ftsale);
//            db.SaveChanges();
//            ftsale.GroupId = ftsale.Id;
//            db.Entry(ftsale).State = EntityState.Modified;
//            db.SaveChanges();
//            // New AR Transaction if Ledger is true . else we will do cash detuct transaction
//            if (SaleModel.Ledger == true)
//            {
//                FinanceTransaction ftar = new FinanceTransaction();
//                ftar.Amount = SaleModel.TotalBill;
//                ftar.Name = "AR against return Purchase # " + ftsale.Id;
//                ftar.FkFinanceAccountId = accounts.Where(a => a.Name == "Account Receivables").FirstOrDefault().Id;
//                ftar.UserId = SaleModel.CustomerId;
//                ftar.UserType = "Vendor";
//                ftar.DateTime = DateTime.Now;
//                ftar.Status = "Posted";
//                ftar.FkAspnetusersId = UserId;
//                ftar.GroupId = ftsale.Id;
//                db.FinanceTransaction.Add(ftar);
//                db.SaveChanges();
//            }
//            else
//            {
//                // this transaction is for because we are receiving ammount to vendor
//                FinanceTransaction ftpayment = new FinanceTransaction();
//                ftpayment.Amount = SaleModel.TotalPayment;
//                ftpayment.Name = "Payment against return purchase # " + ftsale.Id;
//                ftpayment.FkFinanceAccountId = SaleModel.FinanceAccountId;
//                ftpayment.UserId = SaleModel.CustomerId;
//                ftpayment.UserType = "Vendor";
//                ftpayment.DateTime = DateTime.Now;
//                ftpayment.Status = "Posted";
//                ftpayment.FkAspnetusersId = UserId;
//                ftpayment.GroupId = ftsale.Id;
//                db.FinanceTransaction.Add(ftpayment);
//                db.SaveChanges();
//            }

//            foreach (SaleItem item in SaleModel.SaleList)
//            {
//                ProductTransaction pt = new ProductTransaction();
//                pt.FkProductId = item.id;
//                pt.FkFinanceTransactionId = ftsale.Id;
//                pt.Price = item.price;
//                pt.Quantity = -item.quantity;
//                pt.Total = ((item.price - item.discount) * -item.quantity);
//                db.ProductTransaction.Add(pt);
//                db.SaveChanges();
//            }

//            updateInventoryOnPurchaseReturn(SaleModel.SaleList);
//            return ftsale.Id;
//        }
//        [Route("salepurchase_getAll")]
//        public dynamic salepurchase_getAll(int UserId = 0, string Type = "Sale", DateTime? FromDate = null, DateTime? ToDate = null)
//        {
//            MyDbContext db = new MyDbContext();
//            List<FinanceTransaction> list;
//            if (Type == "Sale")
//            {
//                if (UserId != 0)
//                {
//                    list = db.FinanceTransaction.Where(a => a.UserType == "Customer").Where(a => a.UserId == UserId).Where(a => a.FkFinanceAccount.Name == "Products Sale").Include(a => a.FkFinanceAccount).Include(a => a.FkAspnetusers).ToList();

//                }
//                else
//                {
//                    list = db.FinanceTransaction.Where(a => a.UserType == "Customer").Where(a => a.FkFinanceAccount.Name == "Products Sale").Include(a => a.FkFinanceAccount).Include(a => a.FkAspnetusers).ToList();

//                }
//            }
//            else
//            {
//                if (UserId != 0)
//                {
//                    list = db.FinanceTransaction.Where(a => a.UserType == "Vendor").Where(a => a.UserId == UserId).Where(a => a.FkFinanceAccount.Name == "Inventory").Include(a => a.FkFinanceAccount).Include(a => a.FkAspnetusers).ToList();

//                }
//                else
//                {
//                    list = db.FinanceTransaction.Where(a => a.UserType == "Vendor").Where(a => a.FkFinanceAccount.Name == "Inventory").Include(a => a.FkFinanceAccount).Include(a => a.FkAspnetusers).ToList();
//                }
//            }
//            if (FromDate != null)
//            {
//                DateTime StartTimeOfFromDate = ((DateTime)FromDate).Date;
//                list = list.Where(a => a.DateTime >= StartTimeOfFromDate).ToList();
//            }
//            if (ToDate != null)
//            {
//                DateTime EndTimeOfToDate = ((DateTime)ToDate).Date.AddDays(1).AddTicks(-1);
//                list = list.Where(a => a.DateTime <= EndTimeOfToDate).ToList();
//            }
//            if (Type == "Sale")
//            {
//                var data = from d in list
//                           select new
//                           {
//                               Id = d.Id,
//                               Name = d.Name,
//                               Amount = d.Amount,
//                               DateTime = ((DateTime)d.DateTime).ToString("dd/MM/yyyy hh:mm tt"),
//                               GroupId = d.GroupId,
//                               UserType = d.UserType,
//                               UserId = d.UserId,
//                               AspUserName = d.FkAspnetusers.UserName,
//                               ChildOf = d.ChildOf,
//                               Status = d.Status,
//                               FkFinanceAccountId = d.FkFinanceAccountId,
//                               FkFinanceAccount_Name = d.FkFinanceAccount == null ? "" : d.FkFinanceAccount.Name,
//                               FkAspnetusersId = d.FkAspnetusersId,
//                               FkAspnetusers_Name = d.FkAspnetusers == null ? "" : d.FkAspnetusers.UserName,
//                               PaymentMethod = d.PaymentMethod,
//                               ReferenceNumber = d.ReferenceNumber,
//                               Bank = d.Bank,
//                               Branch = d.Branch,
//                               ChequeDate = d.ChequeDate,
//                               OtherDetail = d.OtherDetail,
//                               OherDetails2 = d.OherDetails2,
//                               UserName = d.UserId == null ? "" : db.Customer.Find(d.UserId).Name,

//                           };
//                return data;
//            }
//            else
//            {
//                var data = from d in list
//                           select new
//                           {
//                               Id = d.Id,
//                               Name = d.Name,
//                               Amount = d.Amount,
//                               DateTime = ((DateTime)d.DateTime).ToString("dd/MM/yyyy"),
//                               GroupId = d.GroupId,
//                               UserType = d.UserType,
//                               UserId = d.UserId,
//                               ChildOf = d.ChildOf,
//                               Status = d.Status,
//                               FkFinanceAccountId = d.FkFinanceAccountId,
//                               FkFinanceAccount_Name = d.FkFinanceAccount == null ? "" : d.FkFinanceAccount.Name,
//                               FkAspnetusersId = d.FkAspnetusersId,
//                               FkAspnetusers_Name = d.FkAspnetusers == null ? "" : d.FkAspnetusers.UserName,
//                               PaymentMethod = d.PaymentMethod,
//                               ReferenceNumber = d.ReferenceNumber,
//                               Bank = d.Bank,
//                               Branch = d.Branch,
//                               ChequeDate = d.ChequeDate,
//                               OtherDetail = d.OtherDetail,
//                               OherDetails2 = d.OherDetails2,
//                               UserName = d.UserId == null ? "" : db.Vendor.Find(d.UserId).Name,

//                           };
//                return data;
//            }
//        }
//        [Route("user_ledger")]
//        public dynamic user_ledger(int UserId, string UserType)
//        {
//            MyDbContext db = new MyDbContext();
//            List<FinanceTransaction> list = db.FinanceTransaction.Where(a => a.UserType == UserType).Where(a => a.UserId == UserId).Include(a => a.FkFinanceAccount).ToList();
//            if (UserType == "Customer")
//            {
//                list = list.Where(a => ((a.FkFinanceAccount.Name != "Account Payable") && (a.FkFinanceAccount.Name != "Account Receivables"))).ToList();
//            }
//            else
//            {
//                list = list.Where(a => ((a.FkFinanceAccount.Name != "Account Payable") && (a.FkFinanceAccount.Name != "Account Receivables"))).ToList();

//            }

//            var data = from d in list
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           Amount = d.Amount,
//                           DateTime = ((DateTime)d.DateTime).ToString("dd/MM/yyyy"),
//                           GroupId = d.GroupId,
//                           UserType = d.UserType,
//                           UserId = d.UserId,
//                           ChildOf = d.ChildOf,
//                           Status = d.Status,
//                           FkFinanceAccountId = d.FkFinanceAccountId,
//                           FkFinanceAccount_Name = d.FkFinanceAccount == null ? "" : d.FkFinanceAccount.Name,
//                           FkAspnetusersId = d.FkAspnetusersId,
//                           FkAspnetusers_Name = d.FkAspnetusers == null ? "" : d.FkAspnetusers.UserName,
//                           PaymentMethod = d.PaymentMethod,
//                           ReferenceNumber = d.ReferenceNumber,
//                           Bank = d.Bank,
//                           Branch = d.Branch,
//                           ChequeDate = d.ChequeDate,
//                           OtherDetail = d.OtherDetail,
//                           OherDetails2 = d.OherDetails2,

//                       };
//            return data.ToList();
//        }
//        [Route("addpayment")]
//        public bool addpayment(FinanceTransaction a)
//        {
//            string AspUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> accounts = db.FinanceAccount.ToList();
//            float negativeOrPositive = 1;
//            if (a.ChildOf == 1)
//            {
//                negativeOrPositive -= 2;
//            }
//            if (a.UserType == "Customer")
//            {

//                //new payment trasaction
//                FinanceTransaction ftpayment = new FinanceTransaction();
//                ftpayment.Amount = (negativeOrPositive) * a.Amount;
//                ftpayment.Name = a.Name;
//                ftpayment.FkFinanceAccountId = a.FkFinanceAccountId;
//                ftpayment.UserId = a.UserId;
//                ftpayment.UserType = "Customer";
//                ftpayment.DateTime = DateTime.Now;
//                ftpayment.Status = "Posted";
//                ftpayment.FkAspnetusersId = AspUserId;
//                db.FinanceTransaction.Add(ftpayment);
//                db.SaveChanges();
//                ftpayment.GroupId = ftpayment.Id;
//                db.Entry(ftpayment).State = EntityState.Modified;
//                db.SaveChanges();


//                FinanceTransaction ftar = new FinanceTransaction();
//                ftar.Amount = (negativeOrPositive) * -a.Amount;
//                ftar.Name = "AR against Payment # " + ftpayment.Id;
//                ftar.FkFinanceAccountId = accounts.Where(b => b.Name == "Account Receivables").FirstOrDefault().Id;
//                ftar.UserId = a.UserId;
//                ftar.UserType = "Customer";
//                ftar.DateTime = DateTime.Now;
//                ftar.Status = "Posted";
//                ftar.FkAspnetusersId = AspUserId;
//                ftar.GroupId = ftpayment.GroupId;
//                db.FinanceTransaction.Add(ftar);
//                db.SaveChanges();
//            }
//            // in case of vendor
//            else
//            {

//                //new payment trasaction
//                FinanceTransaction ftpayment = new FinanceTransaction();
//                ftpayment.Amount = (negativeOrPositive) * -a.Amount;
//                ftpayment.Name = a.Name;
//                ftpayment.FkFinanceAccountId = a.FkFinanceAccountId;
//                ftpayment.UserId = a.UserId;
//                ftpayment.UserType = "Vendor";
//                ftpayment.DateTime = DateTime.Now;
//                ftpayment.Status = "Posted";
//                ftpayment.FkAspnetusersId = AspUserId;
//                ftpayment.GroupId = ftpayment.GroupId;
//                db.FinanceTransaction.Add(ftpayment);
//                db.SaveChanges();

//                FinanceTransaction ftap = new FinanceTransaction();
//                ftap.Amount = (negativeOrPositive) * a.Amount;
//                ftap.Name = "AP against Payment # " + ftpayment.Id;
//                ftap.FkFinanceAccountId = accounts.Where(b => b.Name == "Account Payable").FirstOrDefault().Id;
//                ftap.UserId = a.UserId;
//                ftap.UserType = "Vendor";
//                ftap.DateTime = DateTime.Now;
//                ftap.Status = "Posted";
//                ftap.FkAspnetusersId = AspUserId;
//                ftap.GroupId = ftpayment.GroupId;
//                db.FinanceTransaction.Add(ftap);
//                db.SaveChanges();
//            }

//            return true;
//        }

//        // this function is not in use, just for example
//        [Route("finance_transaction_getAll_groupby_Month")]
//        public dynamic finance_transaction_getAll_groupby_Month(string FinanceAccount)
//        {
//            MyDbContext db = new MyDbContext();
//            List<FinanceTransaction> list;
//            list = db.FinanceTransaction.Where(a => a.FkFinanceAccount.Name == FinanceAccount).Include(a => a.FkFinanceAccount).ToList();
//            // var groups = list.GroupBy(x => new { Month=x.DateTime.Value.Month, Year = x.DateTime.Value.Year });
//            var trendData =
//             (from d in db.FinanceTransaction.Where(a => a.FkFinanceAccount.Name == FinanceAccount)
//              group d by new
//              {
//                  Year = d.DateTime.Value.Year,
//                  Month = d.DateTime.Value.Month
//              } into g
//              select new
//              {
//                  Year = g.Key.Year,
//                  Month = g.Key.Month,
//                  Total = g.Sum(x => x.Amount)
//              }
//        ).AsEnumerable()
//         .Select(g => new
//         {
//             Period = g.Year + "-" + g.Month,
//             Total = g.Total
//         });
//            return trendData;

//        }
//        [Route("finance_account_getAll_sum_all_transactions")]
//        public dynamic finance_account_getAll_sum_all_transactions()
//        {
//            MyDbContext db = new MyDbContext();
//            List<FinanceAccount> list = db.FinanceAccount.Include(a => a.FinanceTransaction).ToList();
//            var data = from d in list
//                       select new
//                       {
//                           Id = d.Id,
//                           Name = d.Name,
//                           AccountType = d.FinanceAccountType,
//                           Today = (float)d.FinanceTransaction.Where(a => (a.DateTime >= DateTime.Now.Date && a.DateTime <= DateTime.Now.Date.AddDays(1).AddTicks(-1))).Sum(a => a.Amount),
//                           Month = (float)d.FinanceTransaction.Where(a => (a.DateTime >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) && a.DateTime <= DateTime.Now.Date.AddMonths(1).AddDays(-1))).Sum(a => a.Amount),
//                           Total = (float)d.FinanceTransaction.Sum(a => a.Amount)
//                       };

//            //List<Finance_Account_SumAllTransaction> list1 = new List<Finance_Account_SumAllTransaction>();
//            //foreach (FinanceAccount item in list)
//            //{
//            //    Finance_Account_SumAllTransaction i = new Finance_Account_SumAllTransaction();
//            //    i.AccountId = item.Id;
//            //    i.AccountName = item.Name;
//            //    i.AccountType = item.FinanceAccountType;
//            //    i.AccountAmountToday = (float)item.FinanceTransaction.Where(a=>(a.DateTime>=DateTime.Now.Date && a.DateTime <= DateTime.Now.Date.AddDays(1).AddTicks(-1))).Sum(a => a.Amount);
//            //    i.AccountAmountMonth = (float)item.FinanceTransaction.Where(a => (a.DateTime >= new DateTime(DateTime.Now.Year,DateTime.Now.Month,1) && a.DateTime <= DateTime.Now.Date.AddMonths(1).AddDays(-1))).Sum(a => a.Amount);
//            //    i.AccountAmountTotal = (float)item.FinanceTransaction.Sum(a => a.Amount);
//            //    list1.Add(i);
//            //}
//            return data.ToList();
//        }
//        #endregion Account


//        #region Staff

//        [Route("staff_getall")]
//        public List<Aspnetusers> staff_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            return db.Aspnetusers.ToList();
//        }
//        [Route("roles_getall")]
//        public List<Aspnetroles> roles_getall()
//        {
//            MyDbContext db = new MyDbContext();
//            return db.Aspnetroles.ToList();
//        }

//        #endregion Staff

//    }

//    public class SaleModel
//    {
//        public int CustomerId { get; set; }
//        public float TotalPayment { get; set; }
//        public float DiscountedBill { get; set; }
//        public float TotalBill { get; set; }
//        public bool Ledger { get; set; }
//        public List<SaleItem> SaleList { get; set; }
//        public int FinanceAccountId { get; set; } //to be used only in purchase,sale return, purchase return.   not in sale
//        public int TransactionId { get; set; } // to be used in printing, in sale return return

//    }
//    public class SaleItem
//    {
//        public int id { get; set; }
//        public string name { get; set; }
//        public float price { get; set; }
//        public float discount { get; set; }
//        public float quantity { get; set; }
//    }
//}