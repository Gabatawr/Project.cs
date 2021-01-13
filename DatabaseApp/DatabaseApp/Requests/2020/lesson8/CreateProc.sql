-- Хранимые процедуры (Stored Procedures) 
--  - запросы, хранимые под определенным именем
--  - разновидность подпрограмм

create procedure -- create proc
    GetManagers  -- имя процедуры
as
-- Тело процедуры
begin -- не обязательно
    select
        Surname + ' ' + Name + ' ' + Secname as Fullname
    from
        Shop_Managers
    order by
        Fullname
end   -- не обязательно