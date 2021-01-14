-- 1. Показать все книги, количество страниц в которых больше 500, но меньше 650.
--select * from [Books] where [Pages] between 500 and 650

-- 2. Показать все книги, в которых первая буква названия либо «А», либо «З».
--select * from [Books] where [Name] like N'А%' or [Name] like N'З%'

-- 3. Показать все книги жанра «Детектив», количество про­данных книг более 30 экземпляров.
/*
select
    min(bdet.Name) [Name],
    sum(s.Quantity) [Count]
from
    Sales s
    join (
        select
            b.Id,
            b.Name
        from
            Books b
            join Themes t on t.Id = b.ThemeId
        where
            t.Name = N'Детективы'
    ) as bdet on bdet.Id = s.BookId
group by 
    bdet.Id
having
    sum(s.Quantity) > 30
order by
    [Count] asc
*/

-- 4. Показать все книги, в названии которых есть слово «Mic­rosoft», но нет слова «Windows».
--insert into [Books] ([Pages] ,[Price] ,[PublishDate] ,[AuthorId] ,[ThemeId] ,[Name])
--             values (123     ,456     ,'2018-01-01'  ,78         ,9         ,N'The Microsoft Windows'),
--                    (123     ,456     ,'2018-01-01'  ,78         ,9         ,N'The Microsoft story')

--select *
--from [Books]
--where [Name] like N'%Microsoft%' and [Name] not like N'%Windows%'

-- 5. Показать все книги (название, тематика, полное имя автора в одной ячейке), цена одной страницы которых меньше 65 копеек.
/*
select
    b.Name + ' | ' + t.Name + ' | ' + a.Name + ' ' + a.Surname as [Title],
    b.Price / b.Pages as [Cost per one page]
from Books b
     join Themes t on t.Id = b.ThemeId
     join Authors a on a.Id = b.AuthorId
where
    b.Price / b.Pages > 0.65
order by
    [Cost per one page] desc
*/

-- 6. Показать все книги, название которых состоит из 4 слов.
--select [Name] from [Books] where len([Name]) = 4

-- 7. Показать информацию о продажах в следующем виде:
--    ▷ Название книги, но, чтобы оно не содержало букву «А».
--    ▷ Тематика, но, чтобы не «Программирование».
--    ▷ Автор, но, чтобы не «Герберт Шилдт».
--    ▷ Цена, но, чтобы в диапазоне от 10 до 20 гривен.
--    ▷ Количество продаж, но не менее 8 книг.
--    ▷ Название  магазина,  который  продал  книгу,  но  он  не  должен быть в Украине или России.
/*
select
    b.Name, t.Name,
    a.Name + ' ' + a.Surname as Author,
    s.Price, s.Quantity, m.Name
from
    Sales s
    join Books b on b.Id = s.BookId
    join Themes t on t.Id = b.ThemeId
    join Authors a on a.Id = b.AuthorId
    join Shops m on m.Id = s.ShopId
    join Countries c on c.Id = m.CountryId
where
    b.Name not like N'%А%'
    and t.Name not like N'Программирование'
    and a.Name not like N'%Герберт%' and a.Surname not like N'%Шилдт%'
    and b.Price between 10 and 20
    and s.Quantity >= 8
    and c.Name not like N'%Украина%' and c.Name not like N'%Россия%'
*/

-- 8. Показать следующую информацию в два столбца (числа в правом столбце приведены в качестве примера):
--    ▷ Количество авторов: 14
--    ▷ Количество книг: 47
--    ▷ Средняя цена продажи: 85.43 грн.
--    ▷ Среднее количество страниц: 650.6.
/*
declare @t table (
    [Title] nvarchar(max) not null,
    [Count] int not null
)

insert into @T ([Title], [Count])
    values (N'Count Authors', (select count(*) from Authors)),
           (N'Count Books', (select count(*) from Books)),
           (N'Avg Price', (select avg(Price) from Sales)),
           (N'Avg Pages', (select avg(Pages) from Books))

select * from @T
*/

-- 9. Показать  тематики  книг  и  сумму  страниц  всех  книг  по  каждой из них.
/*
select
    min(t.Name) [Theme],
    sum(b.Pages) [Sum pages]
from
    Books b
    join Themes t on t.Id = b.ThemeId
group by
    t.Id
*/

--10. Показать количество всех книг и сумму страниц этих книг по каждому из авторов.
/*
select
    min(a.Name + ' ' + a.Surname) [Author],
    count(b.Id) [Count books],
    sum(b.Pages) [Sum pages]
from
    Books b
    join Authors a on a.Id = b.AuthorId
group by
    a.Id
*/

--11. Показать книгу тематики «Программирование» с наиболь­шим количеством страниц.
/*
select top 1
    *
from Books b
    join Themes t on t.Id = b.ThemeId
where 
    t.Name = N'Детские'
order by
    b.Pages desc
*/

--12. Показать среднее количество страниц по каждой тематике, которое не превышает 400.
/*
select
    min(t.Name) [Theme],
    avg(b.Pages) [Avg pages]
from
    Books b
    join Themes t on t.Id = b.ThemeId
group by
    t.Id
having
    avg(b.Pages) <= 400
order by
    [Avg pages] desc
*/
--13. Показать сумму страниц по каждой тематике, учитывая только книги с количеством страниц более 400, 
--    и чтобы тематики  были  «Программирование»,  «Администриро­вание» и «Дизайн».
/*
select
    min(qb.Name) [Theme],
    sum(qb.Pages) [Sum pages]
from (
    select b.ThemeId, t.Name, b.Pages
    from Books b
         join Themes t on t.Id = b.ThemeId
    where b.Pages > 200
          and (t.Name = N'Программирование' or t.Name = N'Администриро­вание' or t.Name = N'Дизайн' or t.Name = N'Детские')
) as qb
group by
    qb.ThemeId
*/

--14. Показать информацию о работе магазинов: что, где, кем, когда и в каком количестве было продано.
/*
declare @i int = (select count(*) from Shops)
while @i > 0
    begin
        select
            m.Name [Shop],
            b.Name [Book],
            s.SaleDate,
            s.Quantity
        from
            Shops m
            join Sales s on s.ShopId = m.Id
            join Books b on b.Id = s.BookId
        where
            m.Id = @i
        order by
            m.Name asc,
            s.SaleDate asc

        set @i -= 1
    end
*/

--15. Показать самый прибыльный магазин.
/*
select top 1
    min(m.Name) [Shop],
    sum(s.Price * s.Quantity) [Total sum],
    min(c.Name) [Countri]
from
    Shops m
    join Sales s on s.ShopId = m.Id
    join Countries c on c.Id = m.CountryId
group by
    m.Id
order by
    [Total sum] desc
*/