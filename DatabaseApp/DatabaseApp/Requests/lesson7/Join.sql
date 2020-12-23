-- Объединения

-- Chief ----------------------------------------------------------------------
--select
--    *
--from
--    Shop_Managers
--where
--    ID_chief is null

-- Worker - Chief -------------------------------------------------------------
--select
--    man_worker.Surname + ' ' + man_worker.Name + ' ' + man_worker.Secname as Worker,
--    man_chief.Surname + ' ' + man_chief.Name + ' ' + man_chief.Secname as Chief
--from
--    Shop_Managers man_worker
--    join Shop_Managers man_chief on man_chief.ID = man_worker.ID_chief

-- (All) Workers - Chief ------------------------------------------------------
--select
--    concat(man_worker.Surname, ' ', man_worker.Name, ' ', man_worker.Secname) 
--        as Worker,

--    coalesce(man_chief.Surname + ' ' + man_chief.Name + ' ' + man_chief.Secname, '-') 
--        as Chief
--from
--    Shop_Managers man_worker
--    left join Shop_Managers man_chief on man_chief.ID = man_worker.ID_chief

-- Chief - Count workers ------------------------------------------------------
--select
--    min(man_chief.Surname + ' ' + man_chief.Name + ' ' + man_chief.Secname) as Chief,
--    count(man_worker.ID) as Workers
--from
--    Shop_Managers man_chief
--    join Shop_Managers man_worker on man_worker.ID_chief = man_chief.ID
--group by
--    man_chief.ID
--order by 
--    Workers desc

-- MegaChief ------------------------------------------------------------------
--select
--    coalesce(man1.Surname + ' ' + man1.Name + ' ' + man1.Secname, '-') as man1,
--    coalesce(man2.Surname + ' ' + man2.Name + ' ' + man2.Secname, '-') as man2,
--    coalesce(man3.Surname + ' ' + man3.Name + ' ' + man3.Secname, '-') as man3,
--    coalesce(man4.Surname + ' ' + man4.Name + ' ' + man4.Secname, '-') as man4,
--    coalesce(man5.Surname + ' ' + man5.Name + ' ' + man5.Secname, '-') as man5
--from
--    Shop_Managers man1
--    left join Shop_Managers man2 on man2.ID_chief = man1.ID
--    left join Shop_Managers man3 on man3.ID_chief = man2.ID
--    left join Shop_Managers man4 on man4.ID_chief = man3.ID
--    left join Shop_Managers man5 on man5.ID_chief = man4.ID
--order by
--    5 desc, 4 desc, 3 desc, 2 desc, 1 desc

-- Having ---------------------------------------------------------------------
--select
--    min(man_chief.Surname + ' ' + man_chief.Name + ' ' + man_chief.Secname) as Chief,
--    count(man_worker.ID) as Workers
--from
--    Shop_Managers man_chief
--    join Shop_Managers man_worker on man_worker.ID_chief = man_chief.ID
--group by
--    man_chief.ID
--having
--    count(man_chief.ID) > 1
--order by
--    Workers desc

-- Вывести всех сотрудников - кол-во подчиненных или 0
--select
--    min(man_chief.Surname + ' ' + man_chief.Name + ' ' + man_chief.Secname) as Chief,
--    count(man_worker.ID) as Workers
--from
--    Shop_Managers man_chief
--    left join Shop_Managers man_worker on man_worker.ID_chief = man_chief.ID
--group by
--    man_chief.ID
----having
----    count(man_worker.ID) = 0
--order by
--    Workers desc

-- Самый прибыльный отдел
select top 1
    max(_Departments.Name) as Department,
    round(sum(_Products.Price * _Sales.Cnt), 2) as Total
from
    Shop_Sales _Sales
    join Shop_Managers    _Managers    on _Managers.ID    = _Sales.ID_manager
    join Shop_Departments _Departments on _Departments.ID = _Managers.ID_main_dep
    join Shop_Products    _Products    on _Products.ID    = _Sales.ID_product
group by 
    _Departments.ID
order by
    Total desc