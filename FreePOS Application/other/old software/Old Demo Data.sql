use RMSDB 
GO

insert into tbl_Customer(Name,Address,PhoneNo)values('Atta','Tajbagh Lahore','03024759550')
insert into tbl_Customer(Name,Address,PhoneNo)values('Kamran','Hussain park Lahore','03024759551')
insert into tbl_Customer(Name,Address,PhoneNo)values('Usman','Gulberg Lahore','03024759552')
insert into tbl_Customer(Name,Address,PhoneNo)values('Imran','Defence Lahore','03024759553')



insert into tbl_FoodItemCategory(Name) values ('Zinger Burger');
insert into tbl_FoodItemCategory(Name) values ('Chicken Burger');
insert into tbl_FoodItemCategory(Name) values ('Shawarma');
insert into tbl_FoodItemCategory(Name) values ('Drinks');
insert into tbl_FoodItemCategory(Name) values ('Food Fries');
insert into tbl_FoodItemCategory(Name) values ('Paratha');
insert into tbl_FoodItemCategory(Name) values ('BBQ');
insert into tbl_FoodItemCategory(Name) values ('Ice Creams');



INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'zinger burger ', 2, 150, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken burger', 2, 110, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'zinger shawarma', 2, 130, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken shawarma', 3, 100, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken tikka small', 3, 250, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken tikka medium', 3, 420, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken tikka large', 3, 700, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken fajita small', 3, 250, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken fajita medium', 3, 420, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken fajita large', 3, 700, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken tandori samll', 3, 280, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken tandori medium', 3, 450, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken tandori large', 3, 720, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'lizania small', 3, 300, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'lizania medium', 3, 480, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'lizania large', 3, 750, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'3 brothers special small', 3, 300, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'3 brothers special  medium', 3, 480, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'3 brothers special large', 3, 750, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'regular drinks ', 4, 30, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'half ltr', 4, 55, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'1 ltr drinks', 4, 80, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'1.5 ltr drinks ', 4, 100, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'drinking water (s)', 4, 30, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'drinking water (l)', 4, 70, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'regular fries ', 2, 50, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'large fries ', 2, 70, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'family fries ', 2, 140, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'10 pc nuggets', 2, 180, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'5 pc nuggets', 2, 100, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'10 pc wings', 2, 190, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'5 pc wings', 2, 100, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken pcs', 2, 90, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'biryani', 3, 150, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken pratha roll', 3, 120, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'zinger pratha roll', 2, 150, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken supreme pizza small', 3, 300, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken supreme pizza medium', 3, 480, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken supreme pizza large', 3, 750, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken achari pizza  small', 3, 280, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken achari pizza  medium ', 3, 480, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chicken achari pizza large ', 3, 750, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'3 brothers special shake', 6, 199, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'berry special', 6, 199, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'cold coffee', 6, 190, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'oreo shake', 6, 179, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'kit kat shake', 6, 179, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'pina colada', 6, 179, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'pine apple shake', 6, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'fresh lime', 6, 59, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'mango shake', 7, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'strawberry shake', 7, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'chocolate shake', 7, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'kulfa shake', 7, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'tutti fruti shake', 7, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'vanilla shake', 7, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'pista shake', 7, 149, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'1 scope ice cream', 8, 40, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'2 scope ice cream', 8, 70, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'3 scope ice cream', 8, 110, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'4 scope ice cream', 8, 140, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'half ltr ice cream', 8, 170, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'1 ltr ice cream', 8, 320, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'extra toping large', 3, 90, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'extra toping medium', 3, 60, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'extra toping small', 3, 40, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'drink 2.25', 4, 130, 0, NULL)
INSERT [dbo].[tbl_FoodItem] ([Name], [Category_Id], [SalePrice], [ManageInventory], [Recipe]) VALUES (N'Delivery charges', 0, 50, 0, NULL)



INSERT [dbo].[tbl_Deal] ([Name], [SalePrice], [ManageInventory], [Category_Id]) VALUES (N'deal 1', 170, 0, 0)
INSERT [dbo].[tbl_Deal] ([Name], [SalePrice], [ManageInventory], [Category_Id]) VALUES (N'deal 2', 250, 0, 0)
INSERT [dbo].[tbl_Deal] ([Name], [SalePrice], [ManageInventory], [Category_Id]) VALUES (N'deal 3', 220, 0, 0)
INSERT [dbo].[tbl_Deal] ([Name], [SalePrice], [ManageInventory], [Category_Id]) VALUES (N'deal 3', 220, 0, 0)




INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20001, 1)
INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20001, 20)
INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20002, 1)
INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20002, 20)
INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20002, 37)
INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20003, 1)
INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20003, 20)
INSERT [dbo].[tbl_DealFoodItem] ([Deal_Id], [FoodItem_Id]) VALUES (20003, 26)



insert into tbl_KitchenInventoryCategory(Name) values ('Ice-Creams');
insert into tbl_KitchenInventoryCategory(Name) values ('Buns');
insert into tbl_KitchenInventoryCategory(Name) values ('Breads');
insert into tbl_KitchenInventoryCategory(Name) values ('Chicken');
insert into tbl_KitchenInventoryCategory(Name) values ('Drinks');
insert into tbl_KitchenInventoryCategory(Name) values ('Vegetables');



insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Vanilla',10,2,400,'5-10-2019',1);
insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Stawberry',10,2,400,'6-11-2018',1);
insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Chicken Bonless',15,3,3000,'9-16-2017',3);
insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Potatoes',8,1,500,'9-9-2017',5);
insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Sprtie',20,6,4000,'8-26-2017',4);
insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Pepsi',20,7,4000,'8-26-2017',4);
insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Burger Buns',50,10,5000,'6-23-2018',1);
insert into tbl_KitchenInventory(Name,Quantity,MinimumQuantity,PurchasePrice,ExpiryDate,KitchenInventoryCategory_Id) 
values ('Chicken Bread',50,10,4000,'1-24-2018',2);





insert into tbl_FinanceChart([Date],OpeningBalance,Sale,Delivery,TotalSale,TotalCash,Deposit,Expence,ClosingBalance)
values ('5-5-2017',25000,15000,1000,156000,100000,4000,200,140000);
insert into tbl_FinanceChart([Date],OpeningBalance,Sale,Delivery,TotalSale,TotalCash,Deposit,Expence,ClosingBalance)
values ('5-6-2017',15000,64100,4000,163320,156000,3000,500,250000);
insert into tbl_FinanceChart([Date],OpeningBalance,Sale,Delivery,TotalSale,TotalCash,Deposit,Expence,ClosingBalance)
values ('5-6-2017',20000,365420,500,66000,45000,1500,400,26000);
insert into tbl_FinanceChart([Date],OpeningBalance,Sale,Delivery,TotalSale,TotalCash,Deposit,Expence,ClosingBalance)
values ('5-7-2017',23000,17000,1300,126000,102000,3500,1000,64000);
insert into tbl_FinanceChart([Date],OpeningBalance,Sale,Delivery,TotalSale,TotalCash,Deposit,Expence,ClosingBalance)
values ('5-8-2017',15700,10050,1900,196000,10500,5200,1600,14500);
insert into tbl_FinanceChart([Date],OpeningBalance,Sale,Delivery,TotalSale,TotalCash,Deposit,Expence,ClosingBalance)
values ('5-9-2017',23500,151100,700,262220,135000,5000,1800,145000);




insert into tbl_StaffCategory (Name) values ('Marketing');
insert into tbl_StaffCategory (Name) values ('Sweeper');
insert into tbl_StaffCategory (Name) values ('Accountant');
insert into tbl_StaffCategory (Name) values ('Cashier');
insert into tbl_StaffCategory (Name) values ('Store Keeper');
insert into tbl_StaffCategory (Name) values ('Waiter');
insert into tbl_StaffCategory (Name) values ('Cook');
insert into tbl_StaffCategory (Name) values ('Manager');


insert into tbl_Staff (Name,UserName,[Password],CNIC,PhoneNo,[Address],JoiningDate,Salary,DutyStart,DutyEnd,Comment,StaffCategory_Id)
values('Fawad','fawadii','1254','32622132513','0326564652','Lahore','5-5-2017',20000,8,2,' ',0);
insert into tbl_Staff (Name,UserName,[Password],CNIC,PhoneNo,[Address],JoiningDate,Salary,DutyStart,DutyEnd,Comment,StaffCategory_Id)
values('Jameel','jammeel','15232','32622132513','0326564652','Mianwali','9-16-2015',2000,8,2,' ',1);
insert into tbl_Staff (Name,UserName,[Password],CNIC,PhoneNo,[Address],JoiningDate,Salary,DutyStart,DutyEnd,Comment,StaffCategory_Id)
values('Shakeel','gori','215456','32622132513','0326564652','Karachi','4-16-2012',30000,8,2,' ',2);
insert into tbl_Staff (Name,UserName,[Password],CNIC,PhoneNo,[Address],JoiningDate,Salary,DutyStart,DutyEnd,Comment,StaffCategory_Id)
values('Ali','gori','215456','32622132513','0326564652','Karachi','4-16-2012',30000,8,2,' ',2);
insert into tbl_Staff (Name,UserName,[Password],CNIC,PhoneNo,[Address],JoiningDate,Salary,DutyStart,DutyEnd,Comment,StaffCategory_Id)
values('Aslam','hamza104','1254','32622132513','0326564652','Karachi','3-21-2016',18000,8,2,' ',3);
insert into tbl_Staff (Name,UserName,[Password],CNIC,PhoneNo,[Address],JoiningDate,Salary,DutyStart,DutyEnd,Comment,StaffCategory_Id)
values('Hamza Ashraf','hamza104','1254','32622132513','0326564652','Karachi','3-21-2016',18000,8,2,' ',3);
insert into tbl_Staff (Name,UserName,[Password],CNIC,PhoneNo,[Address],JoiningDate,Salary,DutyStart,DutyEnd,Comment,StaffCategory_Id)
values('Hamza Ashraf','hamza104','1254','32622132513','0326564652','Karachi','3-21-2016',18000,8,2,' ',4);



use master
go