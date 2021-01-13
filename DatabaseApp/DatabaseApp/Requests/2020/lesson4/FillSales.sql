set nocount on -- off msg counter

declare @index int = 0
while @index < 10000
    begin
        insert into Shop_Sales (ID_manager, ID_product, Cnt, Moment)
        values 
        (
            (select top 1 ID from Shop_Managers order by NEWID()),            -- random ID_manager
            (select top 1 ID from Shop_Products order by NEWID()),            -- random ID_product
            (select abs(checksum(newid())) % 10 + 1),                         -- random cnt 1-10
            (select dateadd(day, abs(checksum(newid())) % 360, '2020-01-01')  -- random day
                  + dateadd(minute, abs(checksum(newid())) % 600 + 540 , 0))  -- random minute from 9:00 (540min) + 10h (600min)
        )
        set @index += 1
    end