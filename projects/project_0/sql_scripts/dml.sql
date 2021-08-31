-- DML = data manipulation language
USE AkilStoreApplicationDB;
GO

--INSERT
INSERT INTO Customer.Customer([Name])
VALUES ("akil"), ("John"), ("Jane");

INSERT INTO Store.Product([Name], Price)
VALUES ("computer", 500), ("monitor", 200);

INSERT INTO Store.Store([Name])
VALUES ("Grocery"), ("Clothing"), ("Jewelery");

-- UPDATE
UPDATE Customer.Customer
SET [Name] = "lika"
WHERE [Name] = "akil";

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

-- UNION = ability to relate/compose 2 or more tables based on data types