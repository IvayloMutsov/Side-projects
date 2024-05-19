CREATE DATABASE Matura;
CREATE TABLE Courses(
Cid INT PRIMARY KEY
,CTitle NVARCHAR(50)
,StartDate DATE
,EndDate DATE
,Instructor NVARCHAR(50)
,NumberParticipants INT);

INSERT INTO Courses
VALUES
(1,'Роботика','2022-10-01','2022-12-22','Петров',10)
,(2,'Математика','2023-11-15','2024-03-31','Колева',22)
,(3,'Изкуства','2022-09-20','2023-01-01','Атанасов',8)
,(4,'Музика','2023-10-01','2023-11-30','Николоова',15)
,(5,'Танци','2023-10-15','2023-12-22','Иванова',20);

UPDATE Courses SET NumberParticipants = 13 WHERE Cid = 3;

SELECT *
FROM Courses
WHERE NumberParticipants > 15;

SELECT 
COUNT(*) AS broi
FROM Courses
WHERE EndDate BETWEEN '2023-01-01' AND '2023-12-31';

SELECT
CTitle
,NumberParticipants
FROM Courses
WHERE EndDate < GETDATE()
ORDER BY CTitle;