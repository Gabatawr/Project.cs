use [master];
go-----------------------------------------------------------------------------

if db_id('Sportstore') is not null
        begin
        alter database [Sportstore] set single_user with rollback immediate;
        drop database [Sportstore];
    end
go-----------------------------------------------------------------------------

create database [Sportstore]
on
( 
    NAME = N'Sportstore_Data', 
    FILENAME = N'E:\Database\Homework\Sportstore\Sportstore_Data.mdf'
)
log on
(
    NAME = N'Sportstore_Log',
    FILENAME = N'E:\Database\Homework\Sportstore\Sportstore_Log.ldf'
)
go-----------------------------------------------------------------------------

use [Sportstore];
go-----------------------------------------------------------------------------

create table [Genders]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N'')
)
go-----------------------------------------------------------------------------

create table [Clients]
(
    [Id] int not null identity primary key,
    [Surname] nvarchar(max) not null check([Surname] <> N''),
    [Name] nvarchar(max) not null check([Name] <> N''),
    [Secname] nvarchar(max),
    [GenderId] int,
    [Phone] nvarchar(max) not null check([Phone] <> N''),
    [Email] nvarchar(max) not null check([Email] <> N''),
    [IsSubscriber] bit not null,
    [Discount] float not null check([Discount] >= 0)
)
go-----------------------------------------------------------------------------

create table [Positions]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N'')
)
go-----------------------------------------------------------------------------

create table [Managers]
(
    [Id] int not null identity primary key,
    [Surname] nvarchar(max) not null check([Surname] <> N''),
    [Name] nvarchar(max) not null check([Name] <> N''),
    [Secname] nvarchar(max) not null check([Secname] <> N''),
    [GenderId] int not null,
    [PositionId] int not null,
    [Salary] money not null check([Salary] > 0),
    [EmploymentDate] date not null check([EmploymentDate] <= getdate()),
)
go-----------------------------------------------------------------------------

create table [Products]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N''),
    [Type] nvarchar(max) not null check([Type] <> N''),
    [Sectype] nvarchar(max) check([Sectype] <> N''),
    [Count] int not null check ([Count] >= 0),
    [Fabricator] nvarchar(max) not null check([Fabricator] <> N''),
    [CostPrice] money not null check([CostPrice] >= 0),
    [SellingPrice] money not null check([SellingPrice] >= 0)
)
go-----------------------------------------------------------------------------

create table [Sales]
(
    [Id] int not null identity primary key,
    [ProductId] int not null,
    [Count] int not null check([Count] > 0),
    [Price] money not null check([Price] > 0),
    [Moment] datetime not null check([Moment] <= getdate()),
    [ManagerId] int not null,
    [ClientId] int not null
)
go-----------------------------------------------------------------------------