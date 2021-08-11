SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

CREATE DATABASE IF NOT EXISTS `bbdb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `bbdb`;

CREATE TABLE `financeaccount` (
  `id` int(11) NOT NULL,
  `name` varchar(30) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `fk_parent_in_financeaccount` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `financeaccount` (`id`, `name`, `type`, `fk_parent_in_financeaccount`) VALUES
(101, 'bank', 'asset', NULL),
(102, 'cash', 'asset', NULL),
(103, 'petty cash', 'asset', NULL),
(104, 'undeposited fund', 'asset', NULL),
(105, 'account receivable', 'asset', NULL),
(106, 'fixed', 'asset', NULL),
(107, 'current', 'asset', NULL),
(108, 'other', 'asset', NULL),
(109, 'inventory', 'asset', NULL),
(201, 'notes payable', 'liabitity', NULL),
(202, 'account payable', 'liabitity', NULL),
(203, 'tax payable', 'liabitity', NULL),
(204, 'salary payable', 'liabitity', NULL),
(301, 'owner equity', 'equity', NULL),
(302, 'share capital', 'equity', NULL),
(401, 'pos sale', 'income', NULL),
(402, 'sale', 'income', NULL),
(403, 'service sale', 'income', NULL),
(404, 'other', 'income', NULL),
(405, 'inventory gain', 'income', NULL),
(501, 'operating', 'expence', NULL),
(502, 'salary', 'expence', NULL),
(503, 'paid tax', 'expence', NULL),
(504, 'cgs', 'expence', NULL),
(509, 'discount', 'expence', NULL),
(510, 'other', 'expence', NULL),
(511, 'inventory loss', 'expence', NULL),
(1011, 'meezan bank', 'asset', 101),
(1012, 'faisal bank', 'asset', 101);

CREATE TABLE `financetransaction` (
  `id` int(11) NOT NULL,
  `name` varchar(60) DEFAULT NULL,
  `amount` float DEFAULT NULL,
  `status` varchar(15) DEFAULT NULL,
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `details` varchar(200) DEFAULT NULL,
  `fk_user_createdby_in_financetransaction` int(11) DEFAULT NULL,
  `fk_user_targetto_in_financetransaction` int(11) DEFAULT NULL,
  `fk_financeaccount_in_financetransaction` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `product` (
  `id` int(11) NOT NULL,
  `barcode` varchar(100) DEFAULT NULL,
  `category` varchar(50) DEFAULT NULL,
  `carrycost` float DEFAULT NULL,
  `discount` float DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `purchaseprice` float DEFAULT NULL,
  `purchaseactive` bit(1) DEFAULT NULL,
  `quantity` float DEFAULT NULL,
  `saleprice` float DEFAULT NULL,
  `saleactive` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/* in case of product has subproducts, its quantity will not be updated on sale purchase, only its subproducts inventory will be updated, it is better approach for handling inventory of deal in case of  purchase purchase */
/* total num of product sale/purchase will be fetched through productsalepurchase product */
/* for sale like super store (1pcs of rio bicuit, 12pcs of rio buiscuits) we need extra table like unitstable*/


CREATE TABLE `productsub` (
  `id` int(11) NOT NULL,
  `fk_product_main_in_productsub` int(11) DEFAULT NULL,
  `fk_product_sub_in_productsub` int(11) DEFAULT NULL,
  `quantity` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `productsalepurchase` (
  `id` int(11) NOT NULL,
  `price` float DEFAULT NULL,
  `quantity` float DEFAULT NULL,
  `total` float DEFAULT NULL,
  `fk_product_in_productsalepurchase` int(11) DEFAULT NULL,
  `fk_financetransaction_in_productsalepurchase` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `softwaresetting` (
  `id` int(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `valuetype` varchar(50) DEFAULT NULL,
  `stringvalue` varchar(100) DEFAULT NULL,
  `intvalue` int(11) DEFAULT NULL,
  `boolvalue` bit(1) DEFAULT NULL,
  `floatvalue` float DEFAULT NULL,
  `datevalue` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/* pre defined softwaresetting ravicosoftuserid, ravicosoftusername,ravicosoftuserpassword,ravicosoftbusinessbookmembershipplan,ravicosoftsmsplan,apiendpoint */

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `address` varchar(200) DEFAULT NULL,
  `name` varchar(20) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `username` varchar(20) DEFAULT NULL,
  `phone` varchar(30) DEFAULT NULL,
  `phone2` varchar(30) DEFAULT NULL,
  `role` varchar(20) DEFAULT 'user'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `user` (`id`, `address`, `name`, `password`, `username`, `phone`, `phone2`, `role`) VALUES
(1, NULL, 'admin', 'admin@123', 'admin', '00000000000', NULL, 'admin');

CREATE TABLE `inventorylog` (
  `id` int(11) NOT NULL,
  `date` datetime DEFAULT CURRENT_TIMESTAMP,
  `note` varchar(200) DEFAULT NULL,
  `quantity` float DEFAULT NULL,
  `fk_product_in_inventorylog` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/* quantity will be plus in case of purchase and minus in case of sale */


CREATE TABLE `cashclosing` (
  `id` int(11) NOT NULL,
  `closingbalance` float DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `expence` float DEFAULT NULL,
  `note` varchar(200) DEFAULT NULL,
  `sale` float DEFAULT NULL,
  `fk_user_in_cashclosing` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


ALTER TABLE `financeaccount`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_parent_in_financeaccount` (`fk_parent_in_financeaccount`);

ALTER TABLE `financetransaction`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_user_createdby_in_financetransaction` (`fk_user_createdby_in_financetransaction`),
  ADD KEY `fk_user_targetto_in_financetransaction` (`fk_user_targetto_in_financetransaction`),
  ADD KEY `fk_financeaccount_in_financetransaction` (`fk_financeaccount_in_financetransaction`);

ALTER TABLE `product`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `productsub`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_product_main_in_productsub` (`fk_product_main_in_productsub`),
  ADD KEY `fk_product_sub_in_productsub` (`fk_product_sub_in_productsub`);

ALTER TABLE `productsalepurchase`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_product_in_productsalepurchase` (`fk_product_in_productsalepurchase`),
  ADD KEY `fk_financetransaction_in_productsalepurchase` (`fk_financetransaction_in_productsalepurchase`);


ALTER TABLE `softwaresetting`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);
  
  
ALTER TABLE `inventorylog`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_product_in_inventorylog` (`fk_product_in_inventorylog`);
  
  
ALTER TABLE `cashclosing`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_user_in_cashclosing` (`fk_user_in_cashclosing`);


ALTER TABLE `financeaccount`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1013;

ALTER TABLE `financetransaction`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
  
ALTER TABLE `productsub`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `productsalepurchase`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `softwaresetting`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
  
ALTER TABLE `inventorylog`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
  
ALTER TABLE `cashclosing`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;


ALTER TABLE `financeaccount`
  ADD CONSTRAINT `fk_parent_in_financeaccount` FOREIGN KEY (`fk_parent_in_financeaccount`) REFERENCES `financeaccount` (`id`);

ALTER TABLE `financetransaction`
  ADD CONSTRAINT `fk_user_createdby_in_financetransaction` FOREIGN KEY (`fk_user_createdby_in_financetransaction`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `fk_financeaccount_in_financetransaction` FOREIGN KEY (`fk_financeaccount_in_financetransaction`) REFERENCES `financeaccount` (`id`),
  ADD CONSTRAINT `fk_user_targetto_in_financetransaction` FOREIGN KEY (`fk_user_targetto_in_financetransaction`) REFERENCES `user` (`id`);

ALTER TABLE `productsub`
  ADD CONSTRAINT `fk_product_main_in_productsub` FOREIGN KEY (`fk_product_main_in_productsub`) REFERENCES `product` (`id`),
  ADD CONSTRAINT `fk_product_sub_in_productsub` FOREIGN KEY (`fk_product_sub_in_productsub`) REFERENCES `product` (`id`);

ALTER TABLE `productsalepurchase`
  ADD CONSTRAINT `fk_financetransaction_in_productsalepurchase` FOREIGN KEY (`fk_financetransaction_in_productsalepurchase`) REFERENCES `financetransaction` (`id`),
  ADD CONSTRAINT `fk_product_in_productsalepurchase` FOREIGN KEY (`fk_product_in_productsalepurchase`) REFERENCES `product` (`id`);

ALTER TABLE `inventorylog`
  ADD CONSTRAINT `fk_product_in_inventorylog` FOREIGN KEY (`fk_product_in_inventorylog`) REFERENCES `product` (`id`);
  
ALTER TABLE `cashclosing`
  ADD CONSTRAINT `fk_user_in_cashclosing` FOREIGN KEY (`fk_user_in_cashclosing`) REFERENCES `user` (`id`);
  

COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
