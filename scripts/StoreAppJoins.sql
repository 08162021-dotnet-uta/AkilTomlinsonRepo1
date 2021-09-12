--Store Orders
--Bakery
select [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
from Customer
inner join [Order]
on [Order].CustomerId = Customer.CustomerId
inner join OrderProduct
on [Order].OrderId = OrderProduct.OrderId
inner join Product
on Product.ProductId = OrderProduct.ProductId
where StoreId = 1;
--Clothing
select [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
from Customer
inner join [Order]
on [Order].CustomerId = Customer.CustomerId
inner join OrderProduct
on [Order].OrderId = OrderProduct.OrderId
inner join Product
on Product.ProductId = OrderProduct.ProductId
where StoreId = 2;
--Jewelery
select [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
from Customer
inner join [Order]
on [Order].CustomerId = Customer.CustomerId
inner join OrderProduct
on [Order].OrderId = OrderProduct.OrderId
inner join Product
on Product.ProductId = OrderProduct.ProductId
where StoreId = 3;

-- Store Products
select Store.StoreName, Product.ProductName, Product.ProductPrice
from Store
inner join StoreProduct
on StoreProduct.StoreId = Store.StoreId
inner join Product
on Product.ProductId = StoreProduct.ProductId
where StoreName = 'Bakery'

select Store.StoreName, Product.ProductName, Product.ProductPrice
from Store
inner join StoreProduct
on StoreProduct.StoreId = Store.StoreId
inner join Product
on Product.ProductId = StoreProduct.ProductId
where StoreName = 'ClothingStore'

select Store.StoreName, Product.ProductName, Product.ProductPrice
from Store
inner join StoreProduct
on StoreProduct.StoreId = Store.StoreId
inner join Product
on Product.ProductId = StoreProduct.ProductId
where StoreName = 'JeweleryStore'

--Customer Order
--Jawn
select [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
from Customer
inner join [Order]
on [Order].CustomerId = Customer.CustomerId
inner join OrderProduct
on [Order].OrderId = OrderProduct.OrderId
inner join Product
on Product.ProductId = OrderProduct.ProductId
where Customer.CustomerId = 1;
--Charles
select [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
from Customer
inner join [Order]
on [Order].CustomerId = Customer.CustomerId
inner join OrderProduct
on [Order].OrderId = OrderProduct.OrderId
inner join Product
on Product.ProductId = OrderProduct.ProductId
where Customer.CustomerId = 2;
--Dom
select [Order].OrderId, Customer.FirstName, Product.ProductName, Product.ProductPrice, OrderProduct.Quantity
from Customer
inner join [Order]
on [Order].CustomerId = Customer.CustomerId
inner join OrderProduct
on [Order].OrderId = OrderProduct.OrderId
inner join Product
on Product.ProductId = OrderProduct.ProductId
where Customer.CustomerId = 3;