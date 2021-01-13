create table [Authors]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N''),
    [Surname] nvarchar(max) not null check([Surname] <> N''),
    [CountryId] int not null
)----------------------------------------------------------

create table [Books]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N''),
    [Pages] int not null check([Pages] > 0),
    [Price] money not null check([Price] > 0),
    [PublishDate] date not null check([PublishDate] <= getdate()),
    [AuthorId] int not null,
    [ThemeId] int not null
)----------------------------------------------------------

create table [Countries]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(50) not null check([Name] <> N'') unique
)----------------------------------------------------------

create table [Sales]
(
    [Id] int not null identity primary key,
    [Price] money not null check([Price] > 0),
    [Quantity] int not null check([Quantity] >= 0),
    [SaleDate] date not null default getdate(),
    [BookId] int not null,
    [ShopId] int not null,
)----------------------------------------------------------

create table [Shops]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N''),
    [CountryId] int not null
)----------------------------------------------------------

create table [Themes]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N'')
)----------------------------------------------------------