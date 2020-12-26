-------------------------------------------------------------------------------

use [master];
go

if db_id('AcademyDatabase') is not null
begin
    alter database [AcademyDatabase] set single_user with rollback immediate;
    drop database [AcademyDatabase];
end
go

create database [AcademyDatabase] 
on 
( 
    NAME = N'AcademyDatabase_Data', 
    FILENAME = N'E:\Database\Academy\AcademyDatabase_Data.mdf'
)
log on 
(
    NAME = N'AcademyDatabase_Log',
    FILENAME = N'E:\Database\Academy\AcademyDatabase_Log.ldf'
);
go

use [AcademyDatabase];
go

-------------------------------------------------------------------------------

create table [Curators]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(max) not null check ([Name] <> N''),
	[Surname] nvarchar(max) not null check ([Surname] <> N'')
);
go

create table [Departments]
(
	[Id] int not null identity(1, 1) primary key,
	[Building] int not null check ([Building] between 1 and 5),
	[Financing] money not null check ([Financing] >= 0.0) default 0.0,
	[Name] nvarchar(100) not null unique check ([Name] <> N''),
	[FacultyId] int not null
);
go

create table [Faculties]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null unique check ([Name] <> N'')
);
go

create table [Groups]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null unique check ([Name] <> N''),
	[Year] int not null check ([Year] between 1 and 5),
	[DepartmentId] int not null
);
go

create table [GroupsCurators]
(
	[Id] int not null identity(1, 1) primary key,
	[CuratorId] int not null,
	[GroupId] int not null
);
go

create table [GroupsLectures]
(
	[Id] int not null identity(1, 1) primary key,
	[GroupId] int not null,
	[LectureId] int not null
);
go

create table [GroupsStudents]
(
	[Id] int not null identity(1, 1) primary key,
	[GroupId] int not null,
	[StudentId] int not null
);
go

create table [Lectures]
(
	[Id] int not null identity(1, 1) primary key,
	[Date] date not null check ([Date] <= getdate()),
	[SubjectId] int not null,
	[TeacherId] int not null
);
go

create table [Students]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(max) not null check ([Name] <> N''),
	[Rating] int not null check ([Rating] between 0 and 5),
	[Surname] nvarchar(max) not null check ([Surname] <> N'')
);
go

create table [Subjects]
(
	[Id] int not null identity(1, 1) primary key,
	[Name] nvarchar(100) not null unique check ([Name] <> N'')
);
go

create table [Teachers]
(
	[Id] int not null identity(1, 1) primary key,
	[IsProfessor] bit not null default 0,
	[Name] nvarchar(max) not null check ([Name] <> N''),
	[Salary] money not null check ([Salary] > 0.0),
	[Surname] nvarchar(max) not null check ([Surname] <> N'')
);
go

-------------------------------------------------------------------------------

--alter table [Departments]
--add foreign key ([FacultyId]) references [Faculties]([Id]);
--go

--alter table [Groups]
--add foreign key ([DepartmentId]) references [Departments]([Id]);
--go

--alter table [GroupsCurators]
--add foreign key ([CuratorId]) references [Curators]([Id]);
--go

--alter table [GroupsCurators]
--add foreign key ([GroupId]) references [Groups]([Id]);
--go

--alter table [GroupsLectures]
--add foreign key ([GroupId]) references [Groups]([Id]);
--go

--alter table [GroupsLectures]
--add foreign key ([LectureId]) references [Lectures]([Id]);
--go

--alter table [GroupsStudents]
--add foreign key ([GroupId]) references [Groups]([Id]);
--go

--alter table [GroupsStudents]
--add foreign key ([StudentId]) references [Students]([Id]);
--go

--alter table [Lectures]
--add foreign key ([SubjectId]) references [Subjects]([Id]);
--go

--alter table [Lectures]
--add foreign key ([TeacherId]) references [Teachers]([Id]);
--go

-------------------------------------------------------------------------------