CREATE TABLE Students
(
    ID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Login NVARCHAR(100),
    Gender NVARCHAR(10),
    BirthDate DATE
);

SELECT * FROM Students

SELECT * FROM dbo.Students

SELECT * FROM dbo.Students


SELECT * FROM dbo.Students
ALTER TABLE dbo.Students
ADD BirthDate DATE;

INSERT INTO dbo.Students (ID, Name, Login, Gender, BirthDate)
VALUES
(3,'John Doe','john123','Male','2000-05-10'),
(4,'Anna Smith','anna99','Female','2001-08-21');

SELECT * FROM dbo.Students