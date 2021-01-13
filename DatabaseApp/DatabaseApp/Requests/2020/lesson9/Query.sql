--insert into Shop_Sales (ID_manager, ID_product, Cnt)
--                values (1, 2, 10)

--delete from Shop_Sales where ID = (select top 1 ID from Shop_Sales order by ID desc)

update Shop_Sales
set Cnt = 110
where ID = (select top 1 ID from Shop_Sales order by ID desc)

select top 1 *
from Shop_Sales
order by ID desc

select *
from Shop_acc_sales