-- Tables, Queries, Data types
-- Tables - main form of data storage (DB)
-- In databases every data - tables ( number - table 1x1 )

-- SQL - case insensitive SELECT = select = Select
-- Senseitiveness smtms - for names [Users] != [users]
-- recomendation: names and COMMANDS - in different Cases

CREATE TABLE [data_types_demo] ( -- [] - name brachets
	[id] INT NOT NULL PRIMARY KEY, -- INT - integer type, NULL - no data
	num INT NULL, -- integer, allow NULL
	numt TINYINT, -- byte
	numb BIGINT, -- 64 bit
	numf FLOAT, -- float point - NULL as default
	price MONEY, -- ! MSSQL
	birthdate DATE NOT NULL, -- 'YYYY-MM-DD' '2020-12-09'
	moment_of_registration DATETIME DEFAULT CURRENT_TIMESTAMP, -- '2020-12-09 18:48:10.25'
	name_en VARCHAR( 32 ), -- up to 32 sym (ASCII)
	name_ua NVARCHAR( 32 ), -- up to 32 sym (Unicode) ! MSSQL
	pass_hash CHAR ( 32 ), -- = 32 sym (ASCII)
	article TEXT -- Large text ~ char*
)