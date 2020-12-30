create view
    newidView
as 
    select newid() as newidResult
go
-------------------------------------------------------------------------------
create function
    RandomInt(@min int, @max int)
    returns int
as
    begin
        declare @randValue int
        select @randValue = checksum(newidResult) from newidView
        return abs(@randValue) % (@max - @min + 1) + @min
    end