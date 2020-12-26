-- 1. Вывести номера корпусов, если суммарный фонд финансирования расположенных в них кафедр превышает 7_500_000.
/*
select
    min(Building) Building,
    sum(Financing) Financing
from
    Departments
group by
    Building
having
    sum(Financing) > 7500000
order by
    Financing desc
*/
-------------------------------------------------------------------------------
-- 2. Вывести названия групп 5-го курса кафедры “Department 1”, которые имеют более 5 лекций в первый месяц.
/*
select
    min(SelectionGroups.Name) [Group Name],
    count(Lectures.Date) [Lectures]
from(
    select
        Groups.Id,
        Groups.Name
    from
        Groups
        join Departments on Departments.Id = Groups.DepartmentId
    where
        Groups.Year = 5
        and Departments.Name = N'Department 1'
)as SelectionGroups
    join GroupsLectures on GroupsLectures.GroupId = SelectionGroups.Id
    left join Lectures on Lectures.Id = GroupsLectures.LectureId
where
    Lectures.Date between '2015-01-01' and '2015-02-01'
group by
    SelectionGroups.Name
having
    count(Lectures.Date) > 5
*/
-------------------------------------------------------------------------------
-- 3. Вывести названия групп, имеющих рейтинг (средний рейтинг всех студентов группы) больше, чем рейтинг группы “Group 1”.
/*
select
    min(Groups.Id) as [Id],
    min(Groups.Name) as [Name],
    avg(Students.Rating) as [Rating]
from
    Groups
    left join GroupsStudents on GroupsStudents.GroupId = Groups.Id
    join Students on Students.Id = GroupsStudents.StudentId
group by
    Groups.Id
having
    avg(Students.Rating) > (
        select 
            avg(Students.Rating) as [AvgRating (Group 1)]
        from
            Groups
            left join GroupsStudents on GroupsStudents.GroupId = Groups.Id
            join Students on Students.Id = GroupsStudents.StudentId
        where Groups.Name = N'Group 1'
        group by
            Groups.Name
    )
order by
    [Id]
*/
-------------------------------------------------------------------------------
-- 4. Вывести фамилии и имена преподавателей, ставка которых выше средней ставки профессоров.
/*
select
    Surname + ' ' + Name as Fullname,
    Salary
from
    Teachers
where
    Salary > (
        select
            avg(Salary)
        from
            Teachers
        where
            IsProfessor = 1
    )
    and IsProfessor = 0
order by
    Salary
*/
-------------------------------------------------------------------------------
-- 5. Вывести названия групп, у которых больше одного куратора.
/*
select
    min(Groups.Name) as [Name],
    count(GroupsCurators.CuratorId) as [Count]
from
    GroupsCurators
    join Groups on Groups.Id = GroupsCurators.GroupId
group by
    Groups.Id
having
    count(GroupsCurators.CuratorId) > 1
order by
    [Count] desc
*/
-------------------------------------------------------------------------------
-- 6. Вывести названия групп, имеющих рейтинг (средний рейтинг всех студентов группы) меньше, чем минимальный рейтинг групп 5-го курса.
/*
select
    min(Groups.Id) as [Id],
    min(Groups.Name) as [Name],
    avg(Students.Rating) as [Rating]
from
    Groups
    left join GroupsStudents on GroupsStudents.GroupId = Groups.Id
    join Students on Students.Id = GroupsStudents.StudentId
group by
    Groups.Id
having
    avg(Students.Rating) < (
        select top 1
            avg(Students.Rating) as [AvgRating (Group 1)]
        from
            Groups
            left join GroupsStudents on GroupsStudents.GroupId = Groups.Id
            join Students on Students.Id = GroupsStudents.StudentId
        where Groups.Year = 5
        group by
            Groups.Id
        order by
            [AvgRating (Group 1)]
    )
order by
    [Id]
*/
-------------------------------------------------------------------------------
-- 7. Вывести названия факультетов, суммарный фонд финансирования кафедр которых больше суммарного фонда финансирования кафедр факультета “Faculty 1”.
/*
select
     min(Faculties.Name) Name,
     sum(Departments.Financing) Financing
from
    Departments
    join Faculties on Faculties.Id = Departments.FacultyId
group by
    Faculties.Id
having
    sum(Departments.Financing) > (
        select
            sum(Departments.Financing) Financing
        from
            Departments
            join Faculties on Faculties.Id = Departments.FacultyId
        group by
            Faculties.Id
        having
            min(Faculties.Name) = N'Faculty 1'
    )
*/
-------------------------------------------------------------------------------
-- 8. Вывести названия дисциплины - количество и полное имя преподавателя, читающего наибольшее количество лекций по ней.
/*
select
    min(TeacherCount.[Subject]) [Subject],
    max(TeacherCount.[Count Teachers]) [Count - Teacher]
from(
    select
        min(Subjects.Id) [SubjectId],
        min(Subjects.Name) [Subject],
        cast(count(Teachers.Id) as nvarchar) + ' - ' + min(Teachers.Name) + ' ' + min(Teachers.Surname) [Count Teachers]    
    from
        Lectures
        join Subjects on Subjects.Id = Lectures.SubjectId
        join Teachers on Teachers.Id = Lectures.TeacherId
    group by
        Subjects.Id,
        Teachers.Id
    order by
        [SubjectId],
        [Count Teachers] desc
        offset 0 rows
)as TeacherCount
group by
    TeacherCount.SubjectId

*/
-------------------------------------------------------------------------------
-- 9. Вывести название дисциплины, по которой читается меньше всего лекций.
/*
select top 1
    min(Subjects.Name) [Subject],
    count(Lectures.Date) [Count]
from
    Lectures
    join Subjects on Subjects.Id = Lectures.SubjectId
group by
    Subjects.Id
order by
    [Count]
*/
-------------------------------------------------------------------------------
-- 10. Вывести количество студентов и читаемых дисциплин на кафедре “Department 1”.
/*
declare @DepartmentName nvarchar(max) = N'Department 1'
select
    @DepartmentName as [Department],
    (
        select
            count(*)
        from(
            select
                GroupsStudents.StudentId [StudentId]
            from
                Departments
                right join Groups on Groups.DepartmentId = Departments.Id
                join GroupsStudents on GroupsStudents.GroupId = Groups.Id
            where
                Departments.Name = @DepartmentName
        )as SelectedStudent
    ) as [Students Count],
    (
        select
            count(*)
        from(
            select distinct
                Lectures.SubjectId [SubjectId]
            from
                Departments
                right join Groups on Groups.DepartmentId = Departments.Id
                join GroupsLectures on GroupsLectures.GroupId = Groups.Id
                join Lectures on Lectures.Id = GroupsLectures.LectureId
                join Subjects on Subjects.Id = Lectures.SubjectId
            where
                Departments.Name = @DepartmentName
        )as SelectedSubject
    ) as [Subject Count]
*/
-------------------------------------------------------------------------------