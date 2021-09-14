CREATE PROCEDURE OrdersStore1
AS
SELECT [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
FROM Customer
INNER JOIN [Order]
ON [Order].CustomerId = Customer.CustomerId
INNER JOIN OrderProduct
ON [Order].OrderId = OrderProduct.OrderId
INNER JOIN Product
ON Product.ProductId = OrderProduct.ProductId
WHERE StoreId = 1;

EXEC OrdersStore1

SELECT [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity, Store.StoreId, StoreName
FROM Customer
INNER JOIN [Order]
ON [Order].CustomerId = Customer.CustomerId
INNER JOIN OrderProduct
ON [Order].OrderId = OrderProduct.OrderId
INNER JOIN Product
ON Product.ProductId = OrderProduct.ProductId
INNER JOIN Store
ON Store.StoreId = [Order].StoreId
WHERE Store.StoreId = 1;

CREATE VIEW ViewOrdersStore1
AS
SELECT [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
FROM Customer
INNER JOIN [Order]
ON [Order].CustomerId = Customer.CustomerId
INNER JOIN OrderProduct
ON [Order].OrderId = OrderProduct.OrderId
INNER JOIN Product
ON Product.ProductId = OrderProduct.ProductId
WHERE StoreId = 1;

SELECT * FROM ViewOrdersStore1

CREATE VIEW ViewStoreOrders
AS
SELECT StoreId, Customer.CustomerId, [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
FROM Customer
INNER JOIN [Order]
ON [Order].CustomerId = Customer.CustomerId
INNER JOIN OrderProduct
ON [Order].OrderId = OrderProduct.OrderId
INNER JOIN Product
ON Product.ProductId = OrderProduct.ProductId;

SELECT * FROM ViewStoreOrders

Create VIEW ViewStoreProducts
AS
SELECT Store.StoreId, Product.ProductId, Store.StoreName, Product.ProductName, ProductDescription, Product.ProductPrice
FROM Store
INNER JOIN StoreProduct
ON StoreProduct.StoreId = Store.StoreId
INNER JOIN Product
ON Product.ProductId = StoreProduct.ProductId
