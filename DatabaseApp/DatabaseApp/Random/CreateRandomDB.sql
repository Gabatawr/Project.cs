use [master]
go-----------------------------------------------------------------------------

if db_id(N'RandomDB') is not null
    begin
        alter database [RandomDB] set single_user with rollback immediate;
        drop database [RandomDB];
    end
go-----------------------------------------------------------------------------

create database [RandomDB]
on
( 
    NAME = N'RandomDB_Data', 
    FILENAME = N'E:\Database\Random\RandomDB_Data.mdf'
)
log on
(
    NAME = N'RandomDB_Log',
    FILENAME = N'E:\Database\Random\RandomDB_Log.ldf'
)
go-----------------------------------------------------------------------------