CREATE TABLE Courses(
ID INT PRIMARY KEY
,Course_Title NVARCHAR(100)
,Course_Teacher NVARCHAR(100)
,[Hours] INT
,Course_date DATE);

INSERT INTO Courses VALUES
(1,'Английски език','Иван Атанасов',30,'2022-12-20')
,(2,'Английски език','Светлана Стефанова',60,'2022-12-27')
,(3,'Програмиране на Java','Петър Колев',60,'2023-01-11')
,(4,'Алгоритми','Светлин Киров',30,'2023-01-11')
,(5,'Структури от данни','Светлин Киров',60,'2023-01-20');

SELECT
Course_Title,[Hours]
FROM Courses
WHERE Course_Teacher LIKE '%Киров%';

SELECT COUNT(*)
FROM Courses
WHERE Course_date LIKE '%2023%';

SELECT
Course_Title,[Hours]
FROM Courses
GROUP BY Course_Title,[Hours]
HAVING (SELECT AVG([Hours])FROM Courses) < [Hours];

DELETE FROM Courses WHERE [Hours] < 60;