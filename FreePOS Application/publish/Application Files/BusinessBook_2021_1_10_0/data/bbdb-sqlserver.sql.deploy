use master
go
drop database bbdb
go
CREATE DATABASE bbdb
GO
use bbdb 
GO

CREATE TABLE [user](
	id int IDENTITY(0,1) NOT NULL PRIMARY KEY,
	[address] varchar(200),
	[name] varchar(20),
	[password] varchar(20),
	username varchar(20),
	phone varchar(30),
	phone2 varchar(30),
	[role] varchar(20) default 'user'
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


	CREATE TABLE product(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	barcode nvarchar(100),
    category varchar(50),
	carrycost float,
    discount float,
    [name] varchar(100),
    purchaseprice float,
    purchaseactive bit,
    quantity float,
    saleprice float,
    saleactive bit,
	--[type] nvarchar(100), -- eg product raw deal
)

	CREATE TABLE subproduct(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	fk_product_product_subproduct int,
	constraint fk_product_product_subproduct foreign key (fk_product_product_subproduct) references product(id),
	fk_subproduct_product_subproduct int,
	constraint fk_subproduct_product_subproduct foreign key (fk_subproduct_product_subproduct) references product(id),
	quantity float,
)


create table financeaccount(
id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
name varchar(30),
type varchar(50),
fk_parent_financeaccount int,
constraint fk_parent_financeaccount foreign key (fk_parent_financeaccount) references financeaccount(id),
);


create table financetransaction(
id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
name varchar(50),
amount float,
status varchar(50),
date datetime,
duedate datetime,
details varchar(200),
fk_createdbyuser_user_financetransaction int,
constraint fk_createdbyuser_user_financetransaction foreign key (fk_createdbyuser_user_financetransaction) references [user](id),
fk_targettouser_user_financetransaction int,
constraint fk_targettouser_user_financetransaction foreign key (fk_targettouser_user_financetransaction) references [user](id),
fk_financeaccount_financeaccount_financetransaction int,
constraint fk_financeaccount_financeaccount_financetransaction foreign key (fk_financeaccount_financeaccount_financetransaction) references financeaccount(id),
);

create table salepurchaseproduct(
id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
price float,
quantity float,
total float,
fk_product_salepurchaseproduct_product int,
constraint fk_product_salepurchaseproduct_product foreign key (fk_product_salepurchaseproduct_product) references product(id),
fk_financetransaction_salepurchaseproduct_financetransaction int,
constraint fk_financetransaction_salepurchaseproduct_financetransaction foreign key (fk_financetransaction_salepurchaseproduct_financetransaction) references financetransaction(id),
);

create table closing(
id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
[date] datetime,
expence float,
income float,
closingbalance float,
comment varchar(200),
fk_user_closing_user int,
constraint fk_user_closing_user foreign key (fk_user_closing_user) references [user](id),
);


SET IDENTITY_INSERT financeaccount ON
/* asset Accounts */
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(101,'bank','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(1011,'meezan bank','asset',101);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(1012,'faisal bank','asset',101);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(102,'cash','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(103,'petty cash','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(104,'undeposited fund','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(105,'account receivable','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(106,'fixed','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(107,'current','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(108,'other','asset',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(109,'inventory','asset',null);
/*liabitity Accounts */
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(201,'notes payable','liabitity',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(202,'account payable','liabitity',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(203,'tax payable','liabitity',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(204,'salary payable','liabitity',null);
/*equity Accounts */
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(301,'owner equity','equity',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(302,'share capital','equity',null);
/*income Accounts */
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(401,'pos sale','income',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(402,'sale','income',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(403,'service sale','income',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(404,'other','income',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(405,'inventory gain','income',null);
/*expence Accounts */
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(501,'operating','expence',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(502,'salary','expence',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(503,'paid tax','expence',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(504,'cgs','expence',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(509,'discount','expence',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(510,'other','expence',null);
insert into financeaccount(id,name,type,fk_parent_financeaccount) values(511,'inventory loss','expence',null);

SET IDENTITY_INSERT financeaccount OFF

--common transactions entries
--sale::   pos sale/sale(-totalbill)   cash(+totalpayment)  account receivable(totalbill - totalpayment)  csg(+cost of goods sold) inventory(-cost of goods sold , name=--inventory--on--sale--)
--customer payment::  some asset account(+totalpayment)  account receivable(-totalpayment)
--purchase::   inventory(+totalbill, name= --inventory--on--purchase--)   cash(-totalpayment)  account payable(-(totalbill - totalpayment))
--vendor payment::  some asset account(-totalpayment)  account payable(+totalpayment)
--expence:: some expence account(+totalpayment)     some asset account(-totalpayment)



--Must Have Data
INSERT INTO [user](name,phone,username,password,role) VALUES ('admin','00000000000','admin','admin@123','admin');
go
use master
go