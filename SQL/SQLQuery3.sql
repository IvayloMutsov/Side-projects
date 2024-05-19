CREATE TABLE Courses(
ID INT PRIMARY KEY
,Course_Title NVARCHAR(100)
,Course_Teacher NVARCHAR(100)
,[Hours] INT
,Course_date DATE);

INSERT INTO Courses VALUES
(1,'��������� ����','���� ��������',30,'2022-12-20')
,(2,'��������� ����','�������� ���������',60,'2022-12-27')
,(3,'������������ �� Java','����� �����',60,'2023-01-11')
,(4,'���������','������� �����',30,'2023-01-11')
,(5,'��������� �� �����','������� �����',60,'2023-01-20');

SELECT
Course_Title,[Hours]
FROM Courses
WHERE Course_Teacher LIKE '%�����%';

SELECT COUNT(*)
FROM Courses
WHERE Course_date LIKE '%2023%';

SELECT
Course_Title,[Hours]
FROM Courses
GROUP BY Course_Title,[Hours]
HAVING (SELECT AVG([Hours])FROM Courses) < [Hours];

DELETE FROM Courses WHERE [Hours] < 60;