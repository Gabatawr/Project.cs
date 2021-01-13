-- SELECT Queries

-- Select all
-- SELECT * FROM Users

-- Select: Name - Stars (Without id, birthdate)
-- SELECT [Name], [Stars] FROM Users

-- Titles: 'User name' - 'Rating'
-- SELECT [Name] AS 'User name', [Stars] AS 'Rating' FROM Users

-- Concat: 'Username - Rating'
-- SELECT CONCAT([Name], ' - ', [Stars]) AS 'User - Rating' FROM Users

-- WHERE - data filter -- analog for IF
-- stars > 5:
/*
SELECT 
	[Name] AS [User name],
	[Stars]
FROM
	Users
WHERE
	[Stars] >= 5
	AND [Birthdate] > '1990-1-1'
*/

-- equals / not equals
/*
SELECT 
	[Name] AS [User name],
	[Stars]
FROM
	Users
WHERE
	NOT [Stars] = 3 -- equals - '=', not equals '<>' / '!=' / NOT [~] = *
*/

-- Sorting: ORDER BY
/*
SELECT
	*
FROM
	Users
WHERE
	[Stars] > 1
ORDER BY 
	[Name] DESC -- ASC (ascending order - default)
*/

-- Result limit
-- Top 3 by rating
/*
SELECT TOP 3
	*
FROM
	Users
ORDER BY
	[Stars] DESC
*/

-- WHERE NULL: ! ANY statement with NULL equals NULL: NULL = NULL -> NULL; NULL != NULL -> NULL
/*
SELECT
	*
FROM
	Users
WHERE
	[Stars] IS NOT NULL -- IS NULL
*/

-- Multiple sorting
-- Sort by rating, then names
/*
SELECT
	[Name],
	COALESCE([Stars], 0) AS [Rating] -- null-COALESCE(gold, silver, bronze, 0) -> first argument not null
FROM
	Users
ORDER BY
	[Stars] DESC,
	[Name]  ASC
*/

-- Aggregators: MAX, MIN, SUM, AVG, COUNT
/*
SELECT
	COUNT(ID)      AS [Count],

	MIN(Birthdate) AS [Older],
	MAX(Stars)     AS [Max Rating],

	SUM(Stars)     AS [Sum Rating],

	ROUND(AVG(CAST(Stars AS FLOAT)), 2) AS [Avg Rating]
FROM
	Users
*/

-- Sub queries
-- Select users with rating more than aberage
/*
SELECT
	*
FROM
	Users
WHERE
	Stars > (SELECT AVG(Stars) FROM Users)
*/

-- Show users from younger to older
/*
SELECT
	*
FROM
	Users
ORDER BY
	Birthdate DESC
*/

-- Show users borned from 1998 to 2002 (including)
/*
SELECT
	*
FROM
	Users
WHERE
  -- Birthdate BETWEEN '1998-01-01' AND '2002-12-31'
	 Year(Birthdate) BETWEEN 1998 AND 2002
*/

-- Show users by birthdate month
/*
SELECT
	*
FROM
	Users
ORDER BY
	MONTH(Birthdate)
*/

-- Show 2 oldest users
/*
SELECT TOP 2
	*
FROM
	Users
ORDER BY
	Birthdate
*/

-- Show quantity of users with more than 7 stars
/*
SELECT
	COUNT(ID)
FROM
	Users
WHERE
	Stars > 7 -- IS NULL
*/

