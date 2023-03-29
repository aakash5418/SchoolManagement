CREATE TABLE AcademicStudent(
AcademicStudentId BIGINT IDENTITY(1,1)PRIMARY KEY,
StudentId BIGINT FOREIGN KEY REFERENCES Student(StudentId),
AcademicId BIGINT FOREIGN KEY REFERENCES Academic(AcademicId),
ClassId BIGINT FOREIGN KEY REFERENCES Class(ClassId),
GroupId BIGINT FOREIGN KEY REFERENCES Groups(GroupId)
CONSTRAINT unique_IsPass_const UNIQUE(StudentId,AcademicId,ClassId,GroupId),
IsPassed INT NOT NULL,
CreatedDate DATETIME NOT NULL,
ModifiedDate DATETIME)