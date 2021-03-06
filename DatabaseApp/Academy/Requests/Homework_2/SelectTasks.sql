﻿-- 1. Вывести таблицу кафедр, но расположить ее поля в обратном порядке.
/*
select 
    [Name], [Financing], [Id]
from 
    [Departments]
*/ ----------------------------------------------------------------------------
-- 2. Вывести названия групп и их рейтинги,
--    используя в качестве названий выводимых полей “Group Name” и “Group Rating” соответственно.
/*
select
    [Name] as [Group Name], [Rating] as [Group Rating]
from
    [Groups]
*/ ----------------------------------------------------------------------------
-- 3. Вывести для преподавателей их фамилию, процент ставки по отношению к надбавке
--    и процент ставки по отношениюк зарплате (сумма ставки и надбавки).
/*
select
    [Surname],
    cast(round((Salary / Premium * 100), 2) as nvarchar) + '%' as [Percent one],
    cast(round(((Salary / (Salary + Premium)) * 100), 2) as nvarchar) + '%' as [Percent two]
from
    [Teachers]
*/ ----------------------------------------------------------------------------
-- 4. Вывести таблицу факультетов в виде одного поля
--    в следующем формате: “The dean of faculty [faculty] is [dean].”.
/*
select
    'The dean of faculty "' + [Name] + '" is ' + [Dean] as [Dean of the Faculty]
from
    [Faculties]
*/ ----------------------------------------------------------------------------
-- 5. Вывести фамилии преподавателей, которые являются профессорами и ставка которых превышает 1050.
/*
select
    [Surname]
from
    [Teachers]
where
    [IsProfessor] = 1
    and [Salary] > 1050
*/ ----------------------------------------------------------------------------
-- 6. Вывести названия кафедр, фонд финансирования которых меньше 11000 или больше 25000.
/*
select 
    [Name]
from 
    [Departments]
where
    [Financing] < 11000 
    or [Financing] > 25000
*/ ----------------------------------------------------------------------------
-- 7. Вывести названия факультетов кроме факультета “Computer Science”.
/*
select
    [Name]
from
    [Faculties]
where
    [Name] <> 'Computer Science'
*/ ----------------------------------------------------------------------------
-- 8. Вывести фамилии и должности преподавателей, которыене являются профессорами.
/*
select
    [Surname], [Position]
from
    [Teachers]
where
    [IsProfessor] = 1
*/ ----------------------------------------------------------------------------
-- 9. Вывести  фамилии, должности, ставки и надбавки ассистентов, у которых надбавка в диапазоне от 160 до 550.
/*
select
    [Surname], [Position], [Salary], [Premium]
from
    [Teachers]
where
    [IsAssistant] = 1
    and [Premium] between 160 and 550
*/ ----------------------------------------------------------------------------
-- 10. Вывести фамилии и ставки ассистентов.
/*
select
    [Surname], [Salary]
from
    [Teachers]
where
    [IsAssistant] = 1
*/ ----------------------------------------------------------------------------
-- 11. Вывести фамилии и должности преподавателей, которыебыли приняты на работу до 01.01.2000.
/*
select
    [Surname], [Position]
from
    [Teachers]
where
    [EmploymentDate] < '2000-01-01'
*/ ----------------------------------------------------------------------------
-- 12. Вывести названия кафедр, которые в алфавитном порядке располагаются до кафедры “Software Development”.
--     Выводимое поле должно иметь название “Name of Department”.
/*
select 
    [Name] as [Name of Department]
from 
    [Departments]
where
    [Name] < 'Software Development'
order by 
    [Name]
*/ ----------------------------------------------------------------------------
-- 13. Вывести фамилии ассистентов, имеющих зарплату (сумма ставки и надбавки) не более 1200.
/*
select
    [Surname]
from
    [Teachers]
where
    [IsAssistant] = 1
    and (Salary + Premium) < 1200
*/ ----------------------------------------------------------------------------
-- 14. Вывести названия групп  5-го курса, имеющих рейтинг в диапазоне от 2 до 4.
/*
select
    [Name]
from
    [Groups]
where
    [Year] = 5
    and [Rating] between 2 and 4
*/ ----------------------------------------------------------------------------
-- 15. Вывести фамилии ассистентов со ставкой меньше 550 или надбавкой меньше 200.
/*
select
    [Surname], [Salary], [Premium]
from
    [Teachers]
where
    [IsAssistant] = 1
    and [Salary] < 550
    or [Premium] < 200
*/ ----------------------------------------------------------------------------