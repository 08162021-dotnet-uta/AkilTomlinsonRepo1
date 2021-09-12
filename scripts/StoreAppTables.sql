USE AkilApplicationDB;
GO


    -- char, nchar, varchar, ncvarchar -- tinyint, smallint, int, bigint, money, decimal, numerical

CREATE TABLE Customer
(
    CustomerId INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
);

CREATE TABLE Store
(
    StoreId INT PRIMARY KEY IDENTITY,
    StoreName NVARCHAR(50) NOT NULL
);

CREATE TABLE Product
(
    ProductId INT PRIMARY KEY IDENTITY,
    ProductName NVARCHAR(50) NOT NULL,
    ProductDescription NVARCHAR(100) NOT NULL,
    ProductPrice DECIMAL(19,4) NOT NULL
);

CREATE TABLE [Order]
(
    OrderId INT PRIMARY KEY IDENTITY,
    CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerId),
    StoreId INT NOT NULL FOREIGN KEY REFERENCES Store(StoreId),
    OrderDate DATETIME2(7) NOT NULL 
);

CREATE TABLE OrderProduct
(
    OrderId INT NOT NULL FOREIGN KEY REFERENCES [Order](OrderId),
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Product(ProductId),
    Quantity INT NOT NULL
    PRIMARY KEY (OrderId,ProductId)
);

CREATE TABLE StoreProduct
(
    StoreId INT NOT NULL FOREIGN KEY REFERENCES Store(StoreId),
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Product(ProductId)
    PRIMARY KEY (StoreId,ProductId)

);

-- drop table store
-- drop table product
-- drop table customer
-- drop table [order]
-- drop table orderproduct
-- drop table storeproduct
