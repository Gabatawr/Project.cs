-- manager - main department --------------------------------------------------
/*
select
    dep.[Name],
    mng.[Surname]
from
    Shop_Managers as mng
    join Shop_Departments as dep on mng.[ID_main_dep] = dep.[ID]
    -- join (inner join) - only для совпадений (с обоих сторон)
order by
    dep.[ID]
*/ ----------------------------------------------------------------------------

-- manager -- second department -----------------------------------------------
/*
select
    mng.[Surname],
    coalesce(dep.[Name], '-')
from
    Shop_Managers as mng
    left join Shop_Departments as dep on mng.[ID_sec_dep] = dep.[ID]
    -- left join - priority left table (mng all - dep совпадение или null)
    -- right join - priority right table
order by
    dep.[ID]
*/ ----------------------------------------------------------------------------

-- HW select: manager fullname, main dep, second dep (or '-') -----------------
--/*
select
    mng.[Surname] + ' ' + mng.[Name] + ' ' + mng.[Secname] as [Full name],
    dep_m.[Name]                                           as [Main dep],
    coalesce(dep_s.[Name], '-')                            as [Second dep]
from
    Shop_Managers as mng
    left join Shop_Departments as dep_m on mng.[ID_main_dep] = dep_m.[ID]
    left join Shop_Departments as dep_s on mng.[ID_sec_dep] = dep_s.[ID]
order by
    dep_m.[ID]
--*/ ----------------------------------------------------------------------------