USE AkilApplicationDB
GO
--create an insert statement for one product
CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY,
ProductName varchar(50) NOT NULL,
ProductDescription varchar(100) NOT NULL,
ProductPrice decimal(19,4) NOT NULL);

--create an insert statement for one customer
CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL);

-- be ready to create an order with at least
CREATE TABLE ItemizedOrders(
ItemizedId uniqueidentifier NOT NULL DEFAULT newid() PRIMARY KEY,
OrderId uniqueidentifier NOT NULL,
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
OrderDate date NOT NULL);

INSERT INTO Products (ProductName, ProductDescription, ProductPrice)
VALUES ('Pillow', 'Satin Pillow', '24.99');
INSERT INTO Products (ProductName, ProductDescription, ProductPrice)
VALUES ('Box Srping', 'Queen sized', '99.99');
INSERT INTO Products (ProductName, ProductDescription, ProductPrice)
VALUES ('Mattress', 'Queen sized memory foam mattress', '999.99');

INSERT INTO Customers (FirstName, LastName)
VALUES ( 'John', 'Doe');


SELECT *
FROM Products

SELECT *
FROM Customers

SELECT *
FROM ItemizedOrders

SELECT AVG(ProductPrice)
FROM Products;

Insert into ItemizedOrders (OrderId, CustomerId, ProductId, OrderDate)
VALUES ('d6ff6edb-e010-4a42-8a3b-bbbb07838a7f', 1, 25, GETDATE())

Insert into ItemizedOrders (OrderId, CustomerId, ProductId, OrderDate)
VALUES ('d6ff6edb-e010-4a42-8a3b-bbbb07838a7f', 1, 26, GETDATE())

Insert into ItemizedOrders (OrderId, CustomerId, ProductId, OrderDate)
VALUES ('d6ff6edb-e010-4a42-8a3b-bbbb07838a7f', 1, 11, GETDATE())




-- Customer ID 1, Products 25, 26, 11