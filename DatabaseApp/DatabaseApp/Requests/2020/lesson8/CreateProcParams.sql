-- Процедура: по id товара => сумму продаж
--create proc
--    GetSumByProductIdByMonth
--    @p_id int
--as
--    select
--        sum(Shop_Sales.Cnt * Shop_Products.Price)
--    from
--        Shop_Sales
--        join Shop_Products on Shop_Products.ID = Shop_Sales.ID_product
--    where
--        Shop_Products.ID = @p_id

--create proc
--    GetSumByProductIdByMonth
--    @p_id int,
--    @month int
--as
--    select
--        min(Shop_Products.Name) as Product,
--        sum(Shop_Sales.Cnt * Shop_Products.Price) as [Sum],
--        @month as [Month]
--    from
--        Shop_Sales
--        join Shop_Products on Shop_Products.ID = Shop_Sales.ID_product
--    where
--        Shop_Products.ID = @p_id
--        and month(Shop_Sales.Moment) = @month

-- Pagination - разбиение на страницы (для отображения)
-- Задача: разбить товары по 5 штук - GetProductPage N
create proc 
    GetProductPage
    @page int,
    @size int
as 
    begin
        select
            *
        from
            Shop_Products
        order by ID 
            offset @size * (@page - 1) rows
            fetch next @size rows only
    end