-- Bakery Orders
INSERT INTO [Order] (CustomerId, StoreId, OrderDate)
VALUES (1,1,GETDATE()), (2,1,GETDATE()), (3,1,GETDATE())

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (2,4,2), (2,5,1)

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (3,3,2), (3,2,1), (3,1,1)

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (4,2,2), (4,5,1)

--Clothing Orders
INSERT INTO [Order] (CustomerId, StoreId, OrderDate)
VALUES (1,2,GETDATE()), (2,2,GETDATE()), (3,2,GETDATE())

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (5,7,2), (5,8,1)

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (6,10,1), (6,9,1), (6,7,1)

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (7,6,2), (7,10,1)

--Jewelery Orders
INSERT INTO [Order] (CustomerId, StoreId, OrderDate)
VALUES (1,3,GETDATE()), (2,3,GETDATE()), (3,3,GETDATE())

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (8,12,1), (8,15,1)

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (9,15,2), (9,14,1), (9,11,1)

INSERT INTO OrderProduct (OrderId, ProductId, Quantity)
VALUES (10,13,1), (10,11,1), (10,12,1)


SELECT * FROM [Order]
SELECT * FROM OrderProduct
SELECT * FROM Product
SELECT * FROM Store
