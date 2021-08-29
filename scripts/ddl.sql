-- DDL = data definition language
USE AkilStoreApplicationDB;
GO

-- Create
CREATE DATABASE AkilApplicationDB;
GO
-- USE StoreApplicationDB;
-- GO


CREATE SCHEMA Store;
GO

CREATE SCHEMA Customer;
GO

CREATE TABLE Customer.Customer
(
    -- char, nchar, varchar, ncvarchar
    -- tinyint, smallint, int, bigint, money, decimal, numerical
    CustomerId TINYINT NOT NULL IDENTITY(1,1)
    ,Name NVARCHAR(100) NOT NULL
    ,Active BIT NOT NULL
);

CREATE TABLE Store.Store
(
    StoreId TINYINT NOT NULL IDENTITY(1,1)
    ,Name NVARCHAR(100) NOT NULL
    ,Active BIT NOT NULL
);

CREATE TABLE Store.Product
(
    ProductID TINYINT NOT NULL IDENTITY(1,1)
    ,Name NVARCHAR(100) NOT  NULL
    ,Price MONEY NOT NULL
    ,Active BIT NOT NULL
);

CREATE TABLE Store.[Order]
(
    OrderId SMALLINT NOT NULL IDENTITY(1,1)
    ,CustomerId TINYINT NOT NULL
    ,StoreId TINYINT NOT NULL
    ,OrderDate DATETIME2(7) NOT NULL 
    ,Active BIT NOT NULL
);

CREATE TABLE Store.OrderProduct
(
    OrderProductId SMALLINT NOT NULL IDENTITY(1,1)
    ,OrderId SMALLINT NOT NULL
    ,ProductId SMALLINT NOT NULL
    ,Active BIT NOT NULL
);
-- Alter
ALTER TABLE Customer.Customer
    ADD CONSTRAINT PK_Customer PRIMARY KEY (CustomerId);

ALTER TABLE Store.Store 
    ADD CONSTRAINT PK_Store PRIMARY KEY (StoreId);

ALTER TABLE Store.Product 
    ADD CONSTRAINT PK_Product PRIMARY KEY (ProductId);

ALTER TABLE Store.[Order] 
    ADD CONSTRAINT PK_Order PRIMARY KEY (OrderId);

ALTER TABLE Store.OrderProduct 
    ADD CONSTRAINT PK_OrderProduct PRIMARY KEY (OrderProductId);

ALTER TABLE Store.[Order] 
    ADD CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerId) REFERENCES Customer.Customer(CustomerId);

ALTER TABLE Store.[Order] 
    ADD CONSTRAINT FK_Order_Store FOREIGN KEY (StoreId) REFERENCES Store.Store(StoreId);

ALTER TABLE Store.OrderProduct
    ADD CONSTRAINT FK_OrderProduct_Order FOREIGN KEY (OrderId) REFERENCES Store.[Order](OrderId);

ALTER TABLE Store.OrderProduct
    ADD CONSTRAINT FK_OrderProduct_Product FOREIGN KEY (ProductId) REFERENCES Store.Product(ProductId);

ALTER TABLE Customer.Customer
    ADD CONSTRAINT DF_Customer DEFAULT (1) for Active;

ALTER TABLE Store.Store
    ADD CONSTRAINT DF_Store DEFAULT (1) for Active; 

ALTER TABLE Store.Product
    ADD CONSTRAINT DF_Product DEFAULT (1) for Active;

ALTER TABLE Store.[Order]
    ADD CONSTRAINT DF_Order DEFAULT (1) for Active;

ALTER TABLE Store.OrderProduct
    ADD CONSTRAINT DF_OrderProduct DEFAULT (1) for Active;

ALTER TABLE Store.[Order] 
    ADD CONSTRAINT CK_Order CHECK (OrderDate <= GETDATE());                 

-- Drop
--DROP DATABASE StoreApplicationDB;
--DROP SCHEMA Customer;
--DROP TABLE Customer.Customer;

-- Truncate
TRUNCATE TABLE Customer.Customer;