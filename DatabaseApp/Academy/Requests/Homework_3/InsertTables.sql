declare @_FacultiesNumber      int = abs(checksum(newid())) % 50 + 10
declare @_DepartmentsNumber    int = abs(checksum(newid())) % @_FacultiesNumber * 5 + @_FacultiesNumber
declare @_SubjectsNumber       int = abs(checksum(newid())) % @_DepartmentsNumber * 5 + @_DepartmentsNumber * 5
declare @_TeachersNumber       int = abs(checksum(newid())) % @_SubjectsNumber + @_SubjectsNumber * 0.5

declare @_GroupsNumber         int = abs(checksum(newid())) % @_DepartmentsNumber * 10 + @_DepartmentsNumber * 10
declare @_LecturesNumber       int = abs(checksum(newid())) % @_SubjectsNumber + @_SubjectsNumber * 0.75
declare @_GroupsLecturesNumber int = abs(checksum(newid())) % @_LecturesNumber + @_GroupsNumber * 2

declare @index int


truncate table [Faculties] ----------------------------------------------------
set @index = 1
while @index <= @_FacultiesNumber 
    begin
        insert into [Faculties] ([Name])
            values (N'Faculty ' + cast(@index as nvarchar))
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Departments] --------------------------------------------------
set @index = 1
while @index <= @_DepartmentsNumber 
    begin
        insert into [Departments] ([Name], [Financing], [FacultyId])
            values
            (
                N'Department ' + cast(@index as nvarchar),
                cast(abs(checksum(newid())) % 10000 + 10000 as money),
                abs(checksum(newid())) % @_FacultiesNumber + 1
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Subjects] -----------------------------------------------------
set @index = 1
while @index <= @_SubjectsNumber 
    begin
        insert into [Subjects] ([Name])
            values (N'Subject ' + cast(@index as nvarchar))
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Teachers] -----------------------------------------------------
set @index = 1
while @index <= @_TeachersNumber 
    begin
        insert into [Teachers] ([Name], [Surname], [Salary])
            values
            (
                N'Teacher ' + cast(@index as nvarchar),
                N'Surname ' + cast(@index as nvarchar),
                cast(abs(checksum(newid())) % 1000 + 1000 as money)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Groups] -------------------------------------------------------
set @index = 1
while @index <= @_GroupsNumber 
    begin
        insert into [Groups] ([Name], [Year], [DepartmentId])
            values
            (
                N'Group ' + cast(@index as nvarchar),
                abs(checksum(newid())) % 5 + 1,
                abs(checksum(newid())) % @_DepartmentsNumber + 1
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Lectures] -----------------------------------------------------
set @index = 1
while @index <= @_LecturesNumber 
    begin
        insert into [Lectures] ([LectureRoom], [SubjectId], [TeacherId])
            values
            (
                N'Room ' + cast(abs(checksum(newid())) % @index as nvarchar),
                abs(checksum(newid())) % @_SubjectsNumber + 1,
                abs(checksum(newid())) % @_TeachersNumber + 1
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [GroupsLectures] -----------------------------------------------
set @index = 1
while @index <= @_GroupsLecturesNumber 
    begin
        insert into [GroupsLectures] ([DayOfWeek], [LectureId], [GroupId])
            values
            (
                abs(checksum(newid())) % 5 + 1,
                abs(checksum(newid())) % @_LecturesNumber + 1,
                abs(checksum(newid())) % @_GroupsNumber + 1
            )
        set @index += 1
    end
-------------------------------------------------------------------------------