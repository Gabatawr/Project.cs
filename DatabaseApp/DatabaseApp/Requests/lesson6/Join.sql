-- Продажи (товаров) по департаменту за сегодня
-- dep <- man -> sales <- product
/*
select distinct
    dep.[Name]  [Отдел],
    prod.[Name] [Товар]
from
    Shop_Sales            sal
    join Shop_Managers    man  on man.ID  = sal.ID_manager
    join Shop_Departments dep  on dep.ID  = man.ID_main_dep
    join Shop_Products    prod on prod.ID = sal.ID_product
where
    cast(sal.Moment as date) = '2020-12-17'
order by
    [Отдел],
    [Товар]
*/
/*
select
    tmp.[Отдел],
    count(tmp.[Товар]) as [Товаров]
from
(
    select distinct
        dep.[Name]  as [Отдел],
        prod.[Name] as [Товар]
    from
        Shop_Sales sal
        join Shop_Managers    man  on man.ID  = sal.ID_manager
        join Shop_Departments dep  on dep.ID  = man.ID_main_dep
        join Shop_Products    prod on prod.ID = sal.ID_product
        join 
        (
            select distinct
                dep.[Name]  as [Отдел],
                prod.[Name] as [Товар]
            from
                Shop_Sales sal
                join Shop_Managers    man  on man.ID  = sal.ID_manager
                join Shop_Departments dep  on dep.ID  = man.ID_main_dep
                join Shop_Products    prod on prod.ID = sal.ID_product
            where
                cast(sal.Moment as date) = '2020-12-17'
        ) as tmp2 on tmp2.[Отдел] = dep.[Name]
    where
        cast(sal.Moment as date) = '2020-12-16'
) as tmp

group by
    tmp.[Отдел]
*/

-- Товары (наименованиея), проданные за сегодня
/*
select distinct
    prod.Name
from
    Shop_Sales sal
    join Shop_Products prod on prod.ID = sal.ID_product
where
    cast(sal.Moment as date) = cast( current_timestamp as date)
*/
-- Товары - продано шт за сегодня
/*
select
    prod.Name,
    coalesce(today.Sold, 0) as today_Sold,
    coalesce(yesterday.Sold, 0) as yesterday_Sold
from
    Shop_Products as prod
    left join
    (
        select 
            sal.ID_product,
            sum(sal.Cnt) as Sold
        from
            Shop_Sales sal
        where
            cast(sal.Moment as date) = cast(current_timestamp as date)
        group by
            sal.ID_product
    ) as today on today.ID_product = prod.ID
    left join
    (
        select 
            sal.ID_product,
            sum(sal.Cnt) as Sold
        from
            Shop_Sales sal
        where
            cast(sal.Moment as date) = cast(dateadd(day, -1, current_timestamp) as date)
        group by
            sal.ID_product
    ) as yesterday on yesterday.ID_product = prod.ID
*/

-- FIO man - sum(sold) today

select
    man.Surname + ' ' + man.Name + ' ' + man.Secname as [Fullname],
    coalesce(tmp.[Sum], 0) as [Sum]

from
    Shop_Managers man
    left join
    (
        select
            sal.ID_manager,
            sum(sal.Cnt * prod.Price) as [Sum]
        from
            Shop_Sales sal
            join Shop_Products prod on prod.ID = sal.ID_product
        where
            cast(sal.Moment as date) 
                between cast(dateadd(day, -3,current_timestamp) as date) 
                and     cast(dateadd(day,  3,current_timestamp) as date)
        group by
            sal.ID_manager
    ) as tmp on tmp.ID_manager = man.ID

order by
    [Sum] desc