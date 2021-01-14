use [master]

declare @dbName nvarchar(max) = 'BookstoreDb'                              -- Database Name
declare @dbPath nvarchar(max) = 'E:\Code\Project-cs\DatabaseApp\Bookstore' -- Database Path

declare @createPath nvarchar(max) = @dbPath + '\Requests\CreateTables.sql'    -- CreateFile.sql [UTF-16 only!]
declare @insertPath nvarchar(max) = @dbPath + '\Requests\InsertTables.sql'    -- InsertFile.sql [UTF-16 only!]

declare @q nvarchar(max)

-- if exist -> drop
set @q-------------------------------------------------------------------------
= 'if db_id(''' + @dbName + ''') is not null'
+    ' begin'
+        ' alter database' + ' [' + @dbName + '] ' + 'set single_user with rollback immediate' + ';'
+        ' drop database' + ' [' + @dbName + '] ' + ';'
+    ' end'
exec(@q)-----------------------------------------------------------------------

-- create
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

-- Create tables and Insert values in file
declare @sqlPath nvarchar(max)-------------------------------------------------
declare @i int = 1
while @i <= 2
    begin
        set @sqlPath = case @i
            when 1 then @createPath
            when 2 then @insertPath
        end
        ---------------------------------------------------
        declare @text nvarchar(max)
        select @q = 'set @textOUT = (select * from openrowset(bulk ''' + @sqlPath + ''', single_nclob) as text)' -- extract
        exec sp_executesql @q, N'@textOUT nvarchar(max) OUTPUT', @textOUT = @text OUTPUT                         -- text query

        set @q = quotename(@dbName) + '.sys.sp_executesql' -- execution of the request 
        exec @q @text                                      -- in the context of the created database
        -------------
        set @i += 1
    end
-------------------------------------------------------------------------------