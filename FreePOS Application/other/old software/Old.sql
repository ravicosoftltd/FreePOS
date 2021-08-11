
use master
go
drop database RMSDB
go
CREATE DATABASE RMSDB
GO
use RMSDB 
GO


CREATE TABLE tbl_Sitting(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(20),
)

CREATE TABLE tbl_Supplier(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(20),
	PhoneNo varchar(20),
	[Address] varchar(50),
	Balance float,
)
-- 0 id is for admin ,  1 for sale person, 2  for delivery
CREATE TABLE tbl_StaffCategory(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	[Name] varchar(20))


CREATE TABLE tbl_Customer(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	Name varchar(30),
	[Address] varchar(150),
	PhoneNo varchar(11))


CREATE TABLE tbl_FoodItemCategory(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	Name varchar(50))


CREATE TABLE tbl_KitchenInventoryCategory(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	Name varchar(50))


CREATE TABLE tbl_DepositHead(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	[Name] varchar(30))


CREATE TABLE tbl_ExpenceHead(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	Name varchar(50))


create table tbl_PaymentMode(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Name varchar(50))

--KitchenInventory Quantity will be base unit eg 1ml, 1g, 1 egg, 1g carrot
CREATE TABLE tbl_KitchenInventory(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(50),
	Quantity float,
	MinimumQuantity float,
	PurchasePrice float,
	ExpiryDate DateTime,
	KitchenInventoryCategory_Id int foreign key references tbl_KitchenInventoryCategory(Id)	
)


CREATE TABLE tbl_DetuctInventory(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FoodItem_Id int,
	DeductedQuantity float,
	KitchenInventory_id int foreign key references tbl_KitchenInventory(Id))


CREATE TABLE tbl_ExpenceSubHead(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	Name varchar(50),
	ExpenseHead_Id int foreign key references tbl_ExpenceHead(Id)
)


CREATE TABLE tbl_Expence(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Amount int,
	Comment varchar(50),
	DatenTime DateTime,
	ExpenseHead_Id int foreign key references tbl_ExpenceHead(Id),
	ExpenceSubHead_Id int foreign key references tbl_ExpenceSubHead(Id),
)


CREATE TABLE tbl_FinanceChart(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Date] DateTime,
	OpeningBalance float,
	Sale float,
	Delivery float,
	TotalSale float,
	TotalCash float,
	Deposit float,
	Expence float,
	ClosingBalance float)

--0 id is for admin category
CREATE TABLE tbl_Staff(
	Id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	[Name] varchar(20),
	Designation varchar(20),
	UserName varchar(20),
	[Password] varchar(20),
	CNIC varchar(20),
	PhoneNo varchar(30),
	[Address] varchar(100),
	JoiningDate DateTime,
	LeavingDate DateTime,
	Salary float,
	DutyStart int,
	DutyEnd int,
	Comment varchar(50),
	StaffCategory_Id int foreign key references tbl_StaffCategory(Id))



CREATE TABLE tbl_PurchaseOrder(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Supplier_id int foreign key references tbl_Supplier(Id),
	DatenTime DateTime)



CREATE TABLE tbl_PurchaseOrderItem(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(20),
	Quantity float)



--SaleType (1 for takeaway, 2 for table, 3 for delivery)
CREATE TABLE tbl_Sale(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Date_Time DateTime,
	Amount float,
	SaleType int,
	Discount float,
	Customer_Id int foreign key references tbl_Customer(Id),
	Staff_id int foreign key references tbl_Staff(Id))



CREATE TABLE tbl_FoodItem(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(50),
	SalePrice float,
	ManageInventory bit,
	Recipe varchar(1000),
	Category_Id int foreign key references tbl_FoodItemCategory(Id))



CREATE TABLE tbl_Deal(
	Id int IDENTITY(20001,1) NOT NULL PRIMARY KEY,
	Name varchar(50),
	SalePrice float,
	ManageInventory bit,
	Recipe varchar(1000),
	Category_Id int foreign key references tbl_FoodItemCategory(Id))



CREATE TABLE tbl_DealFoodItem(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Deal_Id int foreign key references tbl_Deal(Id),
	FoodItem_Id int foreign key references tbl_FoodItem(Id))



--both deal and food item will be stored here. dealId will be greater then 20000
CREATE TABLE tbl_SaleItem(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Quantity float,	
	Sale_id int foreign key references tbl_Sale(Id),
	Item_id int)


CREATE TABLE tbl_DeliveryQueue(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Delivered Bit,
	DatenTime DateTime,
	Sale_Id int foreign key references tbl_Sale(Id),
	Customer_Id int foreign key references tbl_Customer(Id),
	DeliveryBoyId int foreign key references tbl_Staff(Id))


CREATE TABLE tbl_Deposit(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Ammount float,
	Comment varchar(30),
	DatenTime DateTime, 
	DepositHead_Id int foreign key references tbl_DepositHead(Id))

	go

--Must Have Data
INSERT INTO tbl_Customer(Name,PhoneNo)
VALUES ('anonymous','00000000000');
INSERT INTO tbl_KitchenInventoryCategory (Name)
VALUES ('Other');
INSERT INTO tbl_StaffCategory(Name)
VALUES ('Administration');
INSERT INTO tbl_StaffCategory(Name)
VALUES ('Sale');
INSERT INTO tbl_StaffCategory(Name)
VALUES ('Delivery');
INSERT INTO tbl_DepositHead(Name)
VALUES ('Default');
INSERT INTO tbl_ExpenceHead(Name)
VALUES ('Default');
INSERT INTO tbl_PaymentMode(Name)
VALUES ('Cash');
INSERT INTO tbl_PaymentMode(Name)
VALUES ('CreditCard');
INSERT INTO tbl_ExpenceSubHead(Name,ExpenseHead_Id)
VALUES ('Default',0);
INSERT INTO tbl_Staff(Name,StaffCategory_Id,UserName,[Password])
VALUES ('Admin',0,'admin','123');
INSERT INTO tbl_FoodItemCategory(Name)
VALUES ('Default');

go
use master
go 