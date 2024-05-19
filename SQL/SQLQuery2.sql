CREATE DATABASE bookstore

CREATE TABLE authors(
author_id INT PRIMARY KEY
,first_name NVARCHAR(50)
,last_name NVARCHAR(50)
,country NVARCHAR(50));

CREATE TABLE books(
book_id INT PRIMARY KEY
,title NVARCHAR(50)
,genre NVARCHAR(50)
,author_id INT FOREIGN KEY REFERENCES authors(author_id));

INSERT INTO authors VALUES
(1,'John','Green','USA')
,(2,'John','Rowling','UK')
,(3,'Gabriel','Garcia','Colombia')
,(4,'Jane','Austen','UK');

INSERT INTO books VALUES
(1,'The Fault in Our Stars','Young Adult',1)
,(2,'Looking for Alaska','Young Adult',1)
,(3,'Harry Potter and the Sorcerers Stone','Fantasy',2)
,(4,'Harry Potter and the Chaimber of Secrets','Fantasy',2)
,(5,'Love in the Time of Cholera','Romance',3)
,(6,'One Hundred YEars of Solitude','Magical Realism',3)
,(7,'Pride and Prjudice','Romance',4);

SELECT title
FROM books
WHERE author_id = 1;