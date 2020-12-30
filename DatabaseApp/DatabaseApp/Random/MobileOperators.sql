use [RandomDB]
go-----------------------------------------------------------------------------

if object_id(N'MobileOperators', N'U') is not null
begin
    drop table [MobileOperators]
end
go-----------------------------------------------------------------------------

create table [MobileOperators]
(
    [Id] int not null identity primary key,
    [Operator] nvarchar(max) not null check([Operator] <> N'')
)
go-----------------------------------------------------------------------------

insert into [MobileOperators] ([Operator])
                       values (N'Kyivstar'),
                              (N'Vodafone'),
                              (N'Lifecell'),
                              (N'3mob'),
                              (N'PEOPLEnet'),
                              (N'Intertelecom')
go-----------------------------------------------------------------------------