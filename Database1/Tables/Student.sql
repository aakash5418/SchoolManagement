﻿CREATE TABLE Student(
StudentId BIGINT IDENTITY(101,1) PRIMARY KEY,
RollNo VARCHAR(100)NOT NULL UNIQUE,
FirstName VARCHAR(100)NOT NULL,
Lastname VARCHAR(100)NOT NULL,
Gender VARCHAR(10)NOT NULL,
DateOfBirth DATETIME NOT NULL,
DateOfAdmission DATETIME NOT NULL,
DateOfDiscontinue DATETIME,
CreatedDate DATETIME NOT NULL,
ModifiedDate DATETIME
)
