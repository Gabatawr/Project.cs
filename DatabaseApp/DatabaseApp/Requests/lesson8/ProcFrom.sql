declare @T table (
    Product nvarchar(max) not null,
    [Sum] float not null,
    [Month] int not null
)
insert into @T exec GetSumByProductIdByMonth 1, 1
select * from @T