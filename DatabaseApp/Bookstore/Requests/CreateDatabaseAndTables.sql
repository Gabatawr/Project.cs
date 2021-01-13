use [master]

declare @dbName nvarchar(max) = 'BookstoreDb'                              -- Database Name
declare @dbPath nvarchar(max) = 'E:\Code\Project-cs\DatabaseApp\Bookstore' -- Database Path

declare @sqlPath nvarchar(max) = @dbPath + '\Requests\CreateTables.sql'    -- Path file.sql

declare @q nvarchar(max)
set @q-------------------------------------------------------------------------
= 'if db_id(''' + @dbName + ''') is not null'
+    ' begin'
+        ' alter database' + ' [' + @dbName + '] ' + 'set single_user with rollback immediate' + ';'
+        ' drop database' + ' [' + @dbName + '] ' + ';'
+    ' end'
exec(@q)-----------------------------------------------------------------------

set @q-------------------------------------------------------------------------
= 'create database ' + '[' + @dbName + '] '
+ 'on'
+ '(' 
+    'name = ''' + @dbName + ''','
+    'filename = ''' + @dbPath + '\' + @dbName + '.mdf'''
+ ')'
+ 'log on'
+ '('
+    'name = ''' + @dbName + '_Log' + ''','
+    'filename = ''' + @dbPath + '\' + @dbName + '_Log.ldf'''
+ ')'
exec(@q)-----------------------------------------------------------------------

declare @text nvarchar(max)----------------------------------------------------
select @q = 'set @textOUT = (select BulkColumn from openrowset(bulk ''' + @sqlPath + ''', single_clob) as text)'
exec sp_executesql @q, N'@textOUT nvarchar(max) OUTPUT', @textOUT = @text OUTPUT

set @q = quotename(@dbName) + '.sys.sp_executesql'
exec @q @text------------------------------------------------------------------