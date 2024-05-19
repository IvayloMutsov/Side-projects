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
(1,'��������','2022-10-01','2022-12-22','������',10)
,(2,'����������','2023-11-15','2024-03-31','������',22)
,(3,'��������','2022-09-20','2023-01-01','��������',8)
,(4,'������','2023-10-01','2023-11-30','���������',15)
,(5,'�����','2023-10-15','2023-12-22','�������',20);

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