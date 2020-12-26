declare @CountFaculties      int = dbo.RandomInt(10, 25)
declare @CountDepartments    int = dbo.RandomInt(@CountFaculties * 5, @CountFaculties * 10)

declare @CountGroups         int = dbo.RandomInt(@CountDepartments * 16, @CountDepartments * 24)

declare @CountTeachers       int = dbo.RandomInt(@CountGroups * 0.25, @CountGroups * 0.5)
declare @CountCurators       int = dbo.RandomInt(@CountTeachers * 0.25, @CountTeachers * 0.75)
declare @CountGroupsCurators int = @CountGroups

declare @CountStudents       int = dbo.RandomInt(@CountGroups * 8, @CountGroups * 16)
declare @CountGroupsStudents int = @CountStudents

declare @CountSubjects       int = dbo.RandomInt(@CountDepartments * 10, @CountDepartments * 20)
declare @CountLectures       int = dbo.RandomInt(@CountSubjects * 256, @CountSubjects * 512)
declare @CountGroupsLectures int = dbo.RandomInt(@CountSubjects * 64, @CountSubjects * 128)
-------------------------------------------------------------------------------
select
    @CountFaculties      as Faculties,
    @CountDepartments    as Departments,
    @CountGroups         as Groups,
    @CountTeachers       as Teachers,
    @CountCurators       as Curators,
    @CountGroupsCurators as GroupsCurators,
    @CountStudents       as Students,
    @CountGroupsStudents as GroupsStudents,
    @CountSubjects       as Subjects,
    @CountLectures       as Lectures,
    @CountGroupsLectures as GroupsLectures
-------------------------------------------------------------------------------
declare @index int
set nocount on
-------------------------------------------------------------------------------

truncate table [Faculties] ----------------------------------------------------
set @index = 1
while @index <= @CountFaculties
    begin
        insert into [Faculties] ([Name])
            values (N'Faculty ' + cast(@index as nvarchar))
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Departments] --------------------------------------------------
set @index = 1
while @index <= @CountDepartments
    begin
        insert into [Departments] ([Name], [Financing], [FacultyId], [Building])
            values
            (
                N'Department ' + cast(@index as nvarchar),
                cast(dbo.RandomInt(100000, 1000000) as money),
                dbo.RandomInt(1, @CountFaculties),
                dbo.RandomInt(1, 5)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Groups] -------------------------------------------------------
set @index = 1
while @index <= @CountGroups
    begin
        insert into [Groups] ([Name], [Year], [DepartmentId])
            values
            (
                N'Group ' + cast(@index as nvarchar),
                dbo.RandomInt(1, 5),
                dbo.RandomInt(1, @CountDepartments)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Teachers] -----------------------------------------------------
set @index = 1
while @index <= @CountTeachers
    begin
        insert into [Teachers] ([Name], [Surname], [Salary], [IsProfessor])
            values
            (
                N'TeacherName ' + cast(@index as nvarchar),
                N'TeacherSurname ' + cast(@index as nvarchar),
                cast(dbo.RandomInt(5000, 10000) as money),
                cast(dbo.RandomInt(0, 1) as bit)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Curators] -----------------------------------------------------
set @index = 1
while @index <= @CountCurators
    begin
        insert into [Curators] ([Name], [Surname])
            values
            (
                N'CuratorsName ' + cast(@index as nvarchar),
                N'CuratorsSurname ' + cast(@index as nvarchar)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [GroupsCurators] -----------------------------------------------
set @index = 1
while @index <= @CountGroupsCurators
    begin
        insert into [GroupsCurators] ([GroupId], [CuratorId])
            values
            (
                @index,
                dbo.RandomInt(1, @CountCurators)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Students] -----------------------------------------------------
set @index = 1
while @index <= @CountStudents
    begin
        insert into [Students] ([Name], [Surname], [Rating])
            values
            (
                N'StudentName ' + cast(@index as nvarchar),
                N'SurnameSurname ' + cast(@index as nvarchar),
                dbo.RandomInt(0, 5)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [GroupsStudents] -----------------------------------------------
set @index = 1
while @index <= @CountGroupsStudents
    begin
        insert into [GroupsStudents] ([StudentId], [GroupId])
            values
            (
                @index,
                dbo.RandomInt(1, @CountGroups)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Subjects] -----------------------------------------------------
set @index = 1
while @index <= @CountSubjects 
    begin
        insert into [Subjects] ([Name])
            values (N'Subject ' + cast(@index as nvarchar))
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [Lectures] -----------------------------------------------------
declare @date date
set @index = 1
while @index <= @CountLectures
    begin
        ---------------------------------------------------
        set @date = dateadd(day, dbo.RandomInt(0, 1825), '2015-01-01')
        while datepart(dw, @date) between 6 and 7
            begin
                set @date = dateadd(day, dbo.RandomInt(0, 1825), '2015-01-01')
            end
        ---------------------------------------------------
        insert into [Lectures] ([SubjectId], [TeacherId], [Date])
            values
            (
                dbo.RandomInt(1, @CountSubjects),
                dbo.RandomInt(1, @CountTeachers),
                @date
            )
        ---------------------------------------------------
        set @index += 1
    end
-------------------------------------------------------------------------------

truncate table [GroupsLectures] -----------------------------------------------
set @index = 1
while @index <= @CountGroupsLectures
    begin
        insert into [GroupsLectures] ([LectureId], [GroupId])
            values
            (
                dbo.RandomInt(1, @CountLectures),
                dbo.RandomInt(1, @CountGroups)
            )
        set @index += 1
    end
-------------------------------------------------------------------------------