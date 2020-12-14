truncate table [Departments] --------------------------------------------------
declare 
    @minFin int = 5000, 
    @maxFin int = 45001 -- max 50_000

insert into [Departments] ([Financing], [Name])
                   values (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Software Development'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Data Science'),

                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Аналітичної хімії та аналітичної токсикології'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Аптечної технології ліків'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Біологічної хімії'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Біотехнології'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Ботаніки'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Ветеринарної медицини та фармації'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Заводської технології ліків'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Іноземних мов'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Клінічної лабораторної діагностики'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Клінічної фармакології та клінічної фармації'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Косметології і аромології'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Медичної хімії'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Мікробіології, вірусології та імунології'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Менеджменту та публічного адміністрування'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Неорганічної та фізичної хімії'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Нормальної та патологічної фізіології'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Організації та економіки фармації'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Органічної хімії'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Освітніх та iнформаційних технологій'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Соціальної фармації'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Технології ліків'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Технології фармацевтичних препаратів'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Товарознавства'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Управління, економіки та забезпечення якості у фармації'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Фармацевтичного менеджменту та маркетингу'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Фармакології та фармакотерапії'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Фармакогнозії'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Фармацевтичної хімії'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Фізичної реабілітації та здоров’я'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Філософії та соціології'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Хімії природних сполук і нутриціології'),
                          (cast(rand(checksum(newid())) * @maxFin as money) + @minFin, N'Фундаментальної та мовної підготовки');
go --------------------------------------------------------------------------------

truncate table [Faculties] --------------------------------------------------------
insert into [Faculties] ([Name]                                               , [Dean])
                 values (N'Computer Science'                                  , N'Kashyrin Artem Sergeevich'),

                        (N'Фармацевтичний факультет'                          , N'Кузнєцова Вікторія Юріївна'),
                        (N'Факультет фармацевтичних технологій та менеджменту', N'Живора Наталія Василівна'),
                        (N'Факультет медико-фармацевтичних технологій'        , N'Набока Ольга Іванівна'),
                        (N'Факультет з підготовки іноземних громадян'         , N'Калайчева Світлана Георгіївна');
go --------------------------------------------------------------------------------

truncate table [Groups] -----------------------------------------------------------
declare 
    @numberGroup int = cast(rand(checksum(newid())) * 400 as int) + 200,
    @ratingGroup int,
    @yearGroup int,

@indexGroup int = 1
while @indexGroup <= @numberGroup
    begin
        set @ratingGroup = cast(rand(checksum(newid())) * (5 + 1) as int)
        set @yearGroup = cast(rand(checksum(newid())) * (4 + 1) as int) + 1

        insert into [Groups] ([Name]                , [Rating]    , [Year])
                      values (N'Группа ' + cast(@indexGroup as nvarchar(3)), @ratingGroup, @yearGroup)
        set @indexGroup = @indexGroup + 1
    end;
go
-----------------------------------------------------------------------------------

truncate table [Teachers] ---------------------------------------------------------
declare 
    @numberTeacher int = cast(rand(checksum(newid())) * (120 + 1) as int) + 80, -- max 200
    @isPro bit, @isAss bit, 
    @salaryMinTeacher int = 200, @salaryMaxTeacher int = 2000,
    @dateFrom date = '1990-01-01', @dateTo date = cast(current_timestamp as date),
    @indexTeacher int = 1

while @indexTeacher <= @numberTeacher
    begin
        if cast(rand(checksum(newid())) * (10 + 1) as int) <= 3
            begin
                set @isPro = 1 
                set @isAss = 0
            end
        else
            begin
                set @isPro = 0 
                set @isAss = 1
            end

        insert into [Teachers] ([Name], [Surname], [Position], [IsProfessor], [IsAssistant], [Salary], [Premium], [EmploymentDate])
        values 
        (
            N'TeacherName ' + cast(@indexTeacher as nvarchar(3)),
            N'TeacherSurname ' + cast(@indexTeacher as nvarchar(3)),
            N'TeacherPosition ' + cast(@indexTeacher as nvarchar(3)),
            @isPro, @isAss,
            round(cast(rand(checksum(newid())) * @salaryMaxTeacher as money) + @salaryMinTeacher, 2),
            round(cast(rand(checksum(newid())) * (1000 + 1) as money), 2),
            dateadd(day, rand(checksum(newid()))*(1 + datediff(day, @dateFrom, @dateTo)), @dateFrom)
        )

        set @indexTeacher = @indexTeacher + 1
    end;
go ----------------------------------------------------------------------------