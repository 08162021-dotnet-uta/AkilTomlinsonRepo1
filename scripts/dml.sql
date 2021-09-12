-- DML = data manipulation language
USE AkilStoreApplicationDB;
GO

--INSERT
INSERT INTO Customer.Customer([Name])
VALUES ('akil'), ('John'), ('Jane');

INSERT INTO Store.Product([Name], Price)
VALUES ('computer', 500), ('monitor', 200);

INSERT INTO Store.Store([Name])
VALUES ('Grocery'), ('Clothing'), ('Jewelery');

-- UPDATE
UPDATE Customer.Customer
SET [Name] = 'John'
WHERE [Name] = 'Akil';

-- DELETE
DELETE Customer.Customer
WHERE [Name] = "akil";

-- SELECT
--- Order of execution
--- FROM
--- WHERE
--- GROUP BY
--- HAVING
--- SELECT 
--- ORDER BY

-- create report on all current customers
SELECT [Name]
FROM Customer.Customer
WHERE Active = 1;

-- create report on most sold products (at least 100)
-- ProductOrder(count(productid))
SELECT ProductId
FROM Store.OrderProduct
GROUP BY ProductId
HAVING count(Product) > 99

-- SET
-- JOIN = ability to relate/compose 2 or more tables based on indexes/keys
--  Which customers bought a monitor?
-- Customer, order, product, orderproduct

SELECT cc.[Name]
FROM Store.Product AS sp
INNER JOIN Store.OrderProduct AS sop ON sop.ProductId = sp.ProductId
LEFT JOIN Store.[Order] AS so ON so.OrderId = sop.OrderId
LEFT JOIN Customer.Customer AS cc ON cc.CustomerId = so.CustomerId
WHERE sp.Name = 'monitor'

-- UNION = ability to relate/compose 2 or more tables based on data types

--STORED PROCEDURE
