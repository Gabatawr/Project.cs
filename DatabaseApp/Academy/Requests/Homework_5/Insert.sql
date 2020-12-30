declare @CountClients  int = RandomDB.dbo.RandomInt(1024, 10240)
declare @CountManagers int = RandomDB.dbo.RandomInt(@CountClients / 128, @CountClients / 16)
declare @CountProducts int = RandomDB.dbo.RandomInt(@CountClients / 64, @CountClients / 8)
declare @CountSales    int = RandomDB.dbo.RandomInt(@CountClients, @CountClients * 8)
-------------------------------------------------------------------------------
select
    @CountClients   as Clients,
    @CountManagers  as Managers,
    @CountProducts  as Products,
    @CountSales     as Sales
-------------------------------------------------------------------------------
declare @index int
set nocount on
-------------------------------------------------------------------------------

truncate table [Genders] ------------------------------------------------------
insert into [Genders] ([Name])
               values (N'Male'),
                      (N'Female')
-------------------------------------------------------------------------------

truncate table [Clients] ------------------------------------------------------
set @index = 1
while @index <= @CountClients
    begin
        declare @gender int = (select top 1 g.Id from Genders as g order by newid())
        -------------------------------------------------------
        insert into [Clients] ([Surname], [Name], [Secname], [GenderId], [Phone], [Email], [IsSubscriber], [Discount])
            values 
            (
                (select top 1 r.Name from RandomDB.dbo.Surnames as r order by newid()),
                (select top 1 r.Name from RandomDB.dbo.Names    as r where r.GenderId = @gender order by newid()),
                (select top 1 r.Name from RandomDB.dbo.Secnames as r where r.GenderId = @gender order by newid()),
                @gender,
                N'+380' 
                + cast((select top 1 r.Code from RandomDB.dbo.MobileOperatorCodes as r 
                        where r.OperatorId between 1 and 3 order by newid()) as nvarchar(max))
                + cast(RandomDB.dbo.RandomInt(1000000, 9999999) as nvarchar(max)),
                N'@mail',
                RandomDB.dbo.RandomInt(0, 1),
                cast(RandomDB.dbo.RandomInt(0, 20) as float) + (cast(RandomDB.dbo.RandomInt(0, 99) as float) / 100)
            )
        -------------------------------------------------------
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Positions] ----------------------------------------------------
insert into [Positions] ([Name])
                 values (N'Director'),
                        (N'Accountant'),
                        (N'Purchasing Manager'),
                        (N'Category manager'),
                        (N'Project manager'),
                        (N'Content manager'),
                        (N'Internet marketer'),
                        (N'PPC Specialist'),
                        (N'SEO specialist'),
                        (N'Copywriter'),
                        (N'SMM specialist'),
                        (N'Designer'),
                        (N'Sales Manager'),
                        (N'Order manager'),
                        (N'Storekeeper'),
                        (N'Courier'),
                        (N'Software developer')
-------------------------------------------------------------------------------

truncate table [Managers] -----------------------------------------------------
set @index = 1
declare @CountPositions int = (select count(*) from Positions)
while @index <= @CountManagers
    begin
        set @gender = (select top 1 g.Id from Genders as g order by newid())
        -------------------------------------------------------
        insert into [Managers] ([Surname], [Name], [Secname], [GenderId], [PositionId], [Salary], [EmploymentDate])
            values
            (
                (select top 1 r.Name from RandomDB.dbo.Surnames as r order by newid()),
                (select top 1 r.Name from RandomDB.dbo.Names    as r where r.GenderId = @gender order by newid()),
                (select top 1 r.Name from RandomDB.dbo.Secnames as r where r.GenderId = @gender order by newid()),
                @gender,
                RandomDB.dbo.RandomInt(1, @CountPositions),
                cast(RandomDB.dbo.RandomInt(6000, 20000) as money),
                dateadd(day, RandomDB.dbo.RandomInt(0, 1800), '2015-01-01')
            )
        -------------------------------------------------------
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Products] -----------------------------------------------------
set @index = 1
while @index <= @CountProducts
    begin
        declare @tmpSellingPrice money = cast(RandomDB.dbo.RandomInt(100, 10000) as money)
        -------------------------------------------------------
        insert into [Products] ([Name], [Type], [Sectype], [Count], [Fabricator], [CostPrice], [SellingPrice])
            values
            (
                N'Product ' + cast(@index as nvarchar(max)),
                N'Type ' + cast(RandomDB.dbo.RandomInt(1, @CountProducts) as nvarchar(max)),
                N'Sectype ' + cast(RandomDB.dbo.RandomInt(1, 16) as nvarchar(max)),
                RandomDB.dbo.RandomInt(0, 100),
                N'Fabricator ' + cast(RandomDB.dbo.RandomInt(1, 32) as nvarchar(max)),
                @tmpSellingPrice * (cast(RandomDB.dbo.RandomInt(70, 90) as float) / 100),
                @tmpSellingPrice
            )
        -------------------------------------------------------
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Sales] --------------------------------------------------------
set @index = 1
while @index <= @CountSales
    begin
        declare @tmpIdProduct int = RandomDB.dbo.RandomInt(1, @CountProducts)
        declare @tmpCountSales int = RandomDB.dbo.RandomInt(1, 10)
        -------------------------------------------------------
        insert into [Sales] ([ProductId], [Count], [Price], [Moment], [ManagerId], [ClientId])
            values
            (
                @tmpIdProduct,
                @tmpCountSales,
                (select SellingPrice from Products where Id = @tmpIdProduct),
                dateadd(minute, RandomDB.dbo.RandomInt(540, 1080), dateadd(day, RandomDB.dbo.RandomInt(0, 1600), '2015-04-01')),
                RandomDB.dbo.RandomInt(1, @CountManagers),
                RandomDB.dbo.RandomInt(1, @CountClients)
            )
        -------------------------------------------------------
        set @index += 1
    end
-------------------------------------------------------------------------------