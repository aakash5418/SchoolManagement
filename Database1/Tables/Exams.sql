﻿CREATE  TABLE Exams(
ExamId BIGINT IDENTITY(1001,1)PRIMARY KEY,
ExamType VARCHAR(20) NOT NULL,
AcademicId BIGINT FOREIGN KEY REFERENCES Academic(AcademicId)
CONSTRAINT unique_Exam_const UNIQUE(AcademicId,ExamType),
CreatedDate DATETIME NOT NULL,
ModifiedDate DATETIME)
