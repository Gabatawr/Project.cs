--create function
--    GetMoment()
--    returns datetime -- Скалярные функции - возвращают 1 объект (не таблицу)
--as
--    begin
--        return current_timestamp
--    end

--create function
--    RamdomInt(@min int, @max int)
--    returns int
--as
--    begin
--        return abs(checksum(current_timestamp)) % (@max - @min + 1) + @min
--    end

create function
    GetProductsNames()
    returns table -- Функция табличная - возвращает таблицу
as
    return (
        select 
            Shop_Products.Name
        from 
            Shop_Products
    )