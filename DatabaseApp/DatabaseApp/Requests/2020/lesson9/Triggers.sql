-- Triggers - Обработчики событий в базе данных ( Handler / Listener )
-- В БД события - 3 типа: DML, DDL, DCL
-- Наиболее популярные - DML, события: insert / delete / update (delete->insert)
-- Обработчик - Разновидность процедуры - подпрограмма, запускаемая по факту события (автоматически, СУБД)

-- Зачем?
-- 1. Кольтроль данных (например логин-пароль уникальны в паре)
-- 2. Аккумулирование (ведение статистики)
-- 3. Обеспечение целостности (каскадное удаление)

-- Синтаксис
-- Задача: вести статистику общей суммы продаж

-- 1. Создать таблицу-аккумулятор( Shop_acc_sales(id, cnt, sum) )
--create table Shop_acc_sales (
--    [Id]  int   not null primary key,
--    [Cnt] int   not null check([Cnt] >= 0),
--    [Sum] money not null check([Sum] >= 0)
--)

-- Подготовка - начальное заполнение
--insert into Shop_acc_sales
--values(
--    1,
--    (select sum(Cnt) from Shop_Sales),
--    (select sum(Cnt * Price) from Shop_Sales join Shop_Products on Shop_Products.ID = Shop_Sales.ID_product)
--)

-- 2. Создать тригер
--create trigger    -- Команда
--    Sales_add     -- Имя
--    on Shop_Sales -- Цель
--    after insert  -- События (после insert)
--as
--    update Shop_acc_sales 
--    set [Cnt] = [Cnt] + (select Cnt from inserted),
--        [Sum] = [Sum] + (select Cnt * Price from inserted join Shop_Products on Shop_Products.ID = inserted.ID_product)
--    where id = 1

--create trigger
--    Sales_del
--    on Shop_Sales
--    after delete -- for
--as
--    update Shop_acc_sales 
--    set [Cnt] = [Cnt] - (select Cnt from deleted),
--        [Sum] = [Sum] - (select Cnt * Price from deleted join Shop_Products on Shop_Products.ID = deleted.ID_product)
--    where id = 1

--create trigger
--    Sales_update
--    on Shop_Sales
--    after update
--as
--    update Shop_acc_sales 
--    set [Cnt] = [Cnt] - (select Cnt from deleted) 
--                      + (select Cnt from inserted),
--        [Sum] = [Sum] - (select Cnt * Price from deleted join Shop_Products on Shop_Products.ID = deleted.ID_product)
--                      + (select Cnt * Price from inserted join Shop_Products on Shop_Products.ID = inserted.ID_product)
--    where id = 1

-- "Универсальный" тригер на все события
create trigger
    Sales_acc
    on Shop_Sales
    for insert, delete, update -- все события
as
    update Shop_acc_sales
    set [Cnt] = [Cnt] - coalesce((select Cnt from deleted), 0) 
                      + coalesce((select Cnt from inserted), 0),
        [Sum] = [Sum] - coalesce((select Cnt * Price from deleted join Shop_Products on Shop_Products.ID = deleted.ID_product), 0)
                      + coalesce((select Cnt * Price from inserted join Shop_Products on Shop_Products.ID = inserted.ID_product), 0)
    where Id = 1