use [RandomDB]
go-----------------------------------------------------------------------------

if object_id(N'MobileOperatorCodes', N'U') is not null
begin
    drop table [MobileOperatorCodes]
end
go-----------------------------------------------------------------------------

create table [MobileOperatorCodes]
(
    [Id] int not null identity primary key,
    [Code] int not null check([Code] between 10 and 99),
    [OperatorId] int not null
)
go-----------------------------------------------------------------------------

insert into [MobileOperatorCodes] ([OperatorId], [Code])
                           values (1           , 39),
                                  (1           , 67),
                                  (1           , 68),
                                  (1           , 96),
                                  (1           , 97),
                                  (1           , 98),

                                  (2           , 50),
                                  (2           , 66),
                                  (2           , 95),
                                  (2           , 99),

                                  (3           , 63),
                                  (3           , 93),

                                  (4           , 91),

                                  (5           , 92),

                                  (6           , 94)
go-----------------------------------------------------------------------------