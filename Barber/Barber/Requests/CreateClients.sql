create table [Clients]
(
    [Id] int primary key identity,
    [SurName] nvarchar(max),
    [Name] nvarchar(max),
    [SecName] nvarchar(max),
    [GenderId] int not null,
    [Phone] nvarchar(max),
    [Email] nvarchar(max)
)