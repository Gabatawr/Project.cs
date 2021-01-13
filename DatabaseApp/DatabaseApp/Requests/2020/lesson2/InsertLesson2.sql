-- INSERT INTO lesson2 VALUES (1, 2, 3, '2020-12-08', 'String 1', N'String Unicode')

-- INSERT INTO lesson2 (id, num1) -- recommended
--              VALUES (2 , 10  )
-- INSERT INTO lesson2 (str1      , num1, id) -- recommended
--              VALUES ('String 3', 11  , 3 )

-- Task : include in table data:
-- (8, 12, null, '2019-12-01', null, 'Привет!')
-- (18, 80, 33, '2019-12-01', null, 'Привет!')
-- (80, 12, 44, null, '123', 'Привет!')

INSERT INTO lesson2 (id, num1, num2, moment      , str1 , str2      )
             VALUES (8,  12  , NULL, '2019-12-01', NULL , N'Привет!'),
                    (18, 80  , 33  , '2019-12-01', NULL , N'Привет!'),
                    (80, 12  , 44  , NULL        , '123', N'Привет!')