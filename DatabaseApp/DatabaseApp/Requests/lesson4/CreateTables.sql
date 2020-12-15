-- Проект "Магазин"

-- Departments ----------------------------------------------------------------
CREATE TABLE Shop_Departments
(
    [ID]   INT          NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL
);

-- Managers -------------------------------------------------------------------
CREATE TABLE Shop_Managers
(
    [ID]          INT          NOT NULL PRIMARY KEY,
    [Surname]     NVARCHAR(50) NOT NULL,
    [Name]        NVARCHAR(50) NOT NULL,
    [Secname]     NVARCHAR(50) NOT NULL,
    [ID_main_dep] INT,
    [ID_sec_dep]  INT,
    [ID_chief]    INT
);

-- Products -------------------------------------------------------------------
CREATE TABLE Shop_Products
(
    [ID]    INT          NOT NULL PRIMARY KEY,
    [Name]  NVARCHAR(50) NOT NULL,
    [Price] FLOAT        NOT NULL
);

-- Sales ----------------------------------------------------------------------
CREATE TABLE Shop_Sales 
(
    [ID]         INT NOT NULL PRIMARY KEY IDENTITY,
    [ID_manager] INT NOT NULL,
    [ID_product] INT NOT NULL,
    [Cnt]        INT NOT NULL,
    [Moment]     DATETIME DEFAULT CURRENT_TIMESTAMP
);