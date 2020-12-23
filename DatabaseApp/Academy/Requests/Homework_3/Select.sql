-- 1. Вывести количество преподавателей кафедры “Department 1”.
/*
select
    count(_TeachersName._Name) as [Count]
from
(
    select distinct
        _Teachers.Name as _Name
    from
        [GroupsLectures] _GroupsLectures
        join
        (
            select
                _Groups.Id as _Id
            from
                [Groups] _Groups
                join [Departments] _Departments on _Departments.Id = _Groups.DepartmentId
            where _Departments.Name = N'Department 1'
        ) as _GroupsId on _GroupsId._Id = _GroupsLectures.GroupId
        join [Lectures] _Lectures on _Lectures.Id = _GroupsLectures.LectureId
        join [Teachers] _Teachers on _Teachers.Id = _Lectures.TeacherId
) as _TeachersName
*/
-------------------------------------------------------------------------------
-- 2. Вывести количество лекций, которые читает преподаватель “Teacher 1”.
/*
select
    count(*)
from
    Lectures _Lectures
    join Teachers _Teachers on _Teachers.Id = _Lectures.TeacherId
where
    _Teachers.Name = N'Teacher 1'
*/
-------------------------------------------------------------------------------
-- 3. Вывести количество занятий, проводимых в аудитории “Room 7”.
/*
select
    count(*)
from
    Lectures
where
    LectureRoom = N'Room 7'
*/
-------------------------------------------------------------------------------
-- 4. Вывести названия аудиторий и количество лекций, проводимых в них.
/*
select
    min(LectureRoom) as LectureRoom,
    sum(SubjectId) as LessonCount
from
    Lectures
group by
    LectureRoom
order by
    LessonCount desc
*/
-------------------------------------------------------------------------------
-- 5. Вывести количество групп, посещающих лекции преподавателя “Teacher 2”.
/*
select
    count(*) as CountGroups
from (
    select distinct
        _Groups.Name
    from
        GroupsLectures _GroupsLectures
        join Groups   _Groups   on _Groups.Id   = _GroupsLectures.GroupId
        join Lectures _Lectures on _Lectures.Id = _GroupsLectures.LectureId
        join Teachers _Teachers on _Teachers.Id = _Lectures.TeacherId
    where
        _Teachers.Name = N'Teacher 2'
) as tmp
*/
-------------------------------------------------------------------------------
-- 6. Вывести среднюю ставку преподавателей факультета “Faculty 1”.
/*
select
    round(avg(Salary), 2) as AgvSalary
from (
    select
        min(_Teachers.Id) as Id,
        max(_Teachers.Salary) as Salary
    from
        GroupsLectures   _GroupsLectures
        join Groups      _Groups      on _Groups.Id      = _GroupsLectures.GroupId
        join Lectures    _Lectures    on _Lectures.Id    = _GroupsLectures.LectureId
        join Teachers    _Teachers    on _Teachers.Id    = _Lectures.TeacherId
        join Departments _Departments on _Departments.Id = _Groups.DepartmentId
        join Faculties   _Faculties   on _Faculties.Id   = _Departments.FacultyId
    where
        _Faculties.Name = N'Faculty 1'
    group by
        _Teachers.Id
) as tmp
*/
-------------------------------------------------------------------------------
-- 7. Вывести минимальное и максимальное количество занятий среди всех кафедр.
/*
select
    *
from (
    select 
        min(_Departments.Name) as [Department Name],
        count(_Lectures.SubjectId) as [Count Subject]
    from
        GroupsLectures   _GroupsLectures
        join Groups      _Groups      on _Groups.Id      = _GroupsLectures.GroupId
        join Lectures    _Lectures    on _Lectures.Id    = _GroupsLectures.LectureId
        join Departments _Departments on _Departments.Id = _Groups.DepartmentId
    group by
        _Departments.Name
) as tmp
where 
    tmp.[Count Subject] = (
        select
            min(tmp.[Count Subject])
        from (
            select 
                min(_Departments.Name) as [Department Name],
                count(_Lectures.SubjectId) as [Count Subject]
            from
                GroupsLectures   _GroupsLectures
                join Groups      _Groups      on _Groups.Id      = _GroupsLectures.GroupId
                join Lectures    _Lectures    on _Lectures.Id    = _GroupsLectures.LectureId
                join Departments _Departments on _Departments.Id = _Groups.DepartmentId
            group by
                _Departments.Name
        ) as tmp
    )
    or
    tmp.[Count Subject] = (
        select
            max(tmp.[Count Subject])
        from (
            select 
                min(_Departments.Name) as [Department Name],
                count(_Lectures.SubjectId) as [Count Subject]
            from
                GroupsLectures   _GroupsLectures
                join Groups      _Groups      on _Groups.Id      = _GroupsLectures.GroupId
                join Lectures    _Lectures    on _Lectures.Id    = _GroupsLectures.LectureId
                join Departments _Departments on _Departments.Id = _Groups.DepartmentId
            group by
                _Departments.Name
        ) as tmp
    )
*/
-------------------------------------------------------------------------------
-- 8. Вывести средний фонд финансирования кафедр.
/*
select
    avg(Financing) as [Avg Financing]
from
    Departments
*/
-------------------------------------------------------------------------------
-- 9. Вывести полные имена преподавателей и количество читаемых ими дисциплин.
/*
select
    min(_Teachers.Surname + ' ' + _Teachers.Name) as Fullname,
    count(_Subjects.Id) as [Count Subjects]
from
    Lectures as _Lectures
    right join Teachers as _Teachers on _Teachers.Id = _Lectures.TeacherId
    left  join Subjects as _Subjects on _Subjects.Id = _Lectures.SubjectId
group by
    _Teachers.Id
order by
    [Count Subjects] desc
*/
-------------------------------------------------------------------------------
-- 10. Вывести количество лекций в каждый день недели.
/*
select
    min([DayOfWeek]) as [DayOfWeek],
    count(LectureId) as [CountLectures]
from
    GroupsLectures
group by
    [DayOfWeek]
order by
    [DayOfWeek]
*/
-------------------------------------------------------------------------------
-- 11. Вывести номера аудиторий и количество кафедр, чьи лекции в них читаются.
/*
select
    min(RoomDepartment.LectureRoom) as Room,
    count(RoomDepartment.DepartmentId) as CountDepartments
from (
    select distinct
        LectureRoom,
        Departments.Id as DepartmentId
    from
        GroupsLectures
        right join Lectures    on Lectures.Id    = GroupsLectures.LectureId
        left  join Groups      on Groups.Id      = GroupsLectures.GroupId
        left  join Departments on Departments.Id = Groups.DepartmentId
) as RoomDepartment
group by
    LectureRoom
order by
    CountDepartments desc
*/
-------------------------------------------------------------------------------
-- 12. Вывести названия факультетов и количество дисциплин, которые на них читаются.
/*
select
    min(FacultySubject.FacultieName) as FacultieName,
    count(FacultySubject.SubjectId) as CountSubjects
from (
    select distinct
        Faculties.Name as FacultieName,
        Lectures.SubjectId as SubjectId
    from
        GroupsLectures
        join Lectures    on Lectures.Id    = GroupsLectures.LectureId
        join Groups      on Groups.Id      = GroupsLectures.GroupId
        join Departments on Departments.Id = Groups.DepartmentId
        join Faculties   on Faculties.Id   = Departments.FacultyId
) as FacultySubject
group by
    FacultySubject.FacultieName
order by
    CountSubjects desc
*/
-------------------------------------------------------------------------------
-- 13. Вывести количество лекций для каждой пары преподаватель-аудитория.
/*
select
    min(TeacherRoomLecture.TeacherRoom) as TeacherRoom,
    count(TeacherRoomLecture.LectureId) as CountLectures
from (
    select distinct
        Teachers.Name + ' ' + Lectures.LectureRoom as TeacherRoom,
        Lectures.Id as LectureId
    from
        GroupsLectures
        right join Lectures on Lectures.Id = GroupsLectures.LectureId
        left  join Teachers on Teachers.Id = Lectures.TeacherId    
) as TeacherRoomLecture
group by
    TeacherRoomLecture.TeacherRoom
*/
-------------------------------------------------------------------------------