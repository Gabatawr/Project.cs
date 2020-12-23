-- Журнал продаж: кто-что-сколько-когда
/*
select top 10
    man.[Surname] + ' ' + man.[Name] + ' ' + man.[Secname] as [Full name],
    prod.[Name] as [Product],
    sal.Cnt,
    cast(sal.Moment as date) as [Date sale],
    cast(sal.Moment as time) [Time sale]
from
    Shop_Sales sal
    join Shop_Managers man on sal.ID_manager = man.ID
    join Shop_Products prod on sal.ID_product = prod.ID
order by
    [Date sale],
    [Time sale]
*/

-- Вывести: товар - кол-ва
/*
select
    min(prod.[Name]) as [Name],
    prod.ID,
    sum(sal.Cnt) as [Sales]
from
    Shop_Sales sal
    join Shop_Products prod on sal.ID_product = prod.ID
group by
    prod.[ID]
order by
    [Sales] desc
*/

-- Вывести: Продукт
/*
select
    min(prod.Name),
    sum(sal.Cnt) as [Sold, pcs],
    count(sal.id) as [Checks],
    round(sum(sal.Cnt * prod.Price), 2) as [Sold, money]
from
    Shop_Sales sal
    join Shop_Products prod on prod.ID = sal.ID_product
group by
    prod.ID
*/

--
/*
select Tmp.[Name],
       Tmp.[Sold, pcs],
       Tmp.[Checks],
       Tmp.[Sold, money]
from
    (
        select
            min(prod.Name) as [Name],
            sum(sal.Cnt) as [Sold, pcs],
            count(sal.id) as [Checks],
            round(sum(sal.Cnt * prod.Price), 2) as [Sold, money]
        from
            Shop_Sales sal
            join Shop_Products prod on prod.ID = sal.ID_product
        group by
            prod.ID
    ) as Tmp

union all
    select 'Total',
        sum(sal.Cnt),
        count(sal.id),
        round(sum(sal.Cnt * prod.Price), 2)
    from 
        Shop_Sales sal
        join Shop_Products prod on prod.ID = sal.ID_product
*/

-- Топ 3 товаров по продажам за ноябрь с количеством продаж [name-cnt]
/*
select top 3
    min(prod.Name) as [Product],
    sum(sal.Cnt) as [Count]
from
    Shop_Sales sal
    join Shop_Products prod on sal.ID_product = prod.ID
where
    month(sal.Moment) = 11
group by
    prod.ID
order by
    [Count] desc
*/