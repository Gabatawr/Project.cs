create table [Barbers]
(
    [Id] int primary key identity,
    [SurName] nvarchar(max),
    [Name] nvarchar(max),
    [SecName] nvarchar(max),
    [GenderId] int not null,
    [DateBirth] date,
    [EmploymentDate] date
)