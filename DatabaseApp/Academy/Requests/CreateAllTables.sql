-- Groups ---------------------------------------------------------------------
CREATE TABLE Groups
(
	[ID] INT NOT NULL
		 PRIMARY KEY
	     IDENTITY(1,1)
	,
	[Name] NVARCHAR(10) NOT NULL
		   UNIQUE
		   CHECK ([Name] <> '')
	,
	[Rating] INT NOT NULL
		     CHECK ([Rating] BETWEEN 0 AND 5)
	,
	[Year] INT NOT NULL
		   CHECK ([Year] BETWEEN 1 AND 5)
)
-------------------------------------------------------------------------------

-- Departments ----------------------------------------------------------------
CREATE TABLE Departments
(
	[ID] INT NOT NULL
		 PRIMARY KEY
	     IDENTITY(1,1)
	,
	[Financing] MONEY NOT NULL
				DEFAULT 0
		        CHECK ([Financing] !< 0)
	,
	[Name] NVARCHAR(100) NOT NULL
		   UNIQUE
		   CHECK ([Name] <> '')
)
-------------------------------------------------------------------------------

-- Faculties ------------------------------------------------------------------
CREATE TABLE Faculties
(
	[ID] INT NOT NULL
		 PRIMARY KEY
	     IDENTITY(1,1)
	,
	[Name] NVARCHAR(100) NOT NULL
		   UNIQUE
		   CHECK ([Name] <> '')
)
-------------------------------------------------------------------------------

-- Teachers -------------------------------------------------------------------
CREATE TABLE Teachers
(
	[ID] INT NOT NULL
		 PRIMARY KEY
	     IDENTITY(1,1)
	,
	[EmploymentDate] DATE NOT NULL
					 CHECK ([EmploymentDate] !< '1990-01-01')
	,
	[Name] NVARCHAR(MAX) NOT NULL
		   CHECK ([Name] <> '')
	,
	[Premium] MONEY NOT NULL
			  DEFAULT 0
		      CHECK ([Premium] !< 0)
	,
	[Salary] MONEY NOT NULL
		     CHECK ([Salary] > 0)
	,
	[Surname] NVARCHAR(MAX) NOT NULL
		      CHECK ([Surname] <> '')
)
-------------------------------------------------------------------------------