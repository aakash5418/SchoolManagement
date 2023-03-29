CREATE TABLE Class(
ClassId BIGINT IDENTITY(1,1)PRIMARY KEY,
ClassName VARCHAR(20)NOT NULL,
Section VARCHAR(2)NOT NULL,
AcademicId BIGINT  FOREIGN KEY REFERENCES Academic(AcademicId),
CONSTRAINT unique_class_const UNIQUE(AcademicId,ClassName,Section),
CreatedDate DATETIME NOT NULL,
ModifiedDate DATETIME)