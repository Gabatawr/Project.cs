use [RandomDB]
go-----------------------------------------------------------------------------

if object_id(N'Genders', N'U') is not null
begin
    drop table [Genders]
end
go-----------------------------------------------------------------------------

create table [Genders]
(
    [Id] int not null identity primary key,
    [Name] nvarchar(max) not null check([Name] <> N'')
)
go-----------------------------------------------------------------------------

insert into [Genders] ([Name])
               values (N'Male'),
                      (N'Female'),
                      (N'Multi')
go-----------------------------------------------------------------------------